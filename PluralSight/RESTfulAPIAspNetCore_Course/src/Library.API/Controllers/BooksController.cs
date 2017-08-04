using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Entities;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using Library.API.Models;

namespace Library.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    public class BooksController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public BooksController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetBooksForAuthor(Guid authorId)
        {
            //
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var booksFromRepo = _libraryRepository.GetBooksForAuthor(authorId);
            var booksFromAuthor = Mapper.Map<IEnumerable<BookDto>>(booksFromRepo);

            return Ok(booksFromAuthor);
        }

        [HttpGet("{id}", Name = "GetBookForAuthor")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid id)
        {
            //
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookForAuthorFromRepo = _libraryRepository.GetBookForAuthor(authorId, id);
            if (bookForAuthorFromRepo == null)
            {
                return NotFound();
            }

            var bookFromAuthor = Mapper.Map<BookDto>(bookForAuthorFromRepo);
            return Ok(bookFromAuthor);


        }

        [HttpPost]
        public IActionResult CreateBookForAuthor(Guid authorId, 
            [FromBody] BookForCreationDto book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookEntity = Mapper.Map<Book>(book);
            _libraryRepository.AddBookForAuthor(authorId, bookEntity);
            if (!_libraryRepository.Save())
            {
                throw new Exception($"Creating a book for author: {authorId} failed on save.");
            }

            var bookToReturn = Mapper.Map<BookDto>(bookEntity);

            return CreatedAtRoute("GetBookForAuthor",
                new {authorId = authorId, id = bookToReturn.Id},
                bookToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookForAuthor(Guid authorId, Guid id)
        {
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookForAuthorFromRepo = _libraryRepository.GetBookForAuthor(authorId, id);
            if (bookForAuthorFromRepo == null)
            {
                return NotFound($"No Author or book found for Author: {authorId}");
            }

            _libraryRepository.DeleteBook(bookForAuthorFromRepo);
            if (!_libraryRepository.Save())
            {
                throw new Exception($"Deleting book {id} for author {authorId} failed on save.");
            }

            // Successful but there's now no content
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookForAuthor(Guid authorId, Guid id,
            [FromBody] BookForUpdateDto book)
        {
            if (book == null)
            {
                return BadRequest(); //400
            }

            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookForAuthorFromRepo = _libraryRepository.GetBookForAuthor(authorId, id);
            /*
             UPSERTING HERE!!!!!
             */
            if (bookForAuthorFromRepo == null)
            {
                //return NotFound($"No Author or book found for Author: {authorId}");
                
                // UPSERTING if it does not exist to UPDATE with PUT
                var bookToAdd = Mapper.Map<Book>(book);
                // Consumer passed a Guid
                bookToAdd.Id = id;
                _libraryRepository.AddBookForAuthor(authorId, bookToAdd);
                if (!_libraryRepository.Save())
                {
                    throw new Exception($"Upserting Book for {id} for author {authorId} failed on save.");
                }
                var bookToReturnFromUpsert = Mapper.Map<BookDto>(bookToAdd);
                return CreatedAtRoute("GetBookForAuthor",
                    new {authorId = authorId, id = bookToReturnFromUpsert.Id},
                    bookToReturnFromUpsert);

            }

            //map
            Mapper.Map(book, bookForAuthorFromRepo);
            // apply update
            _libraryRepository.UpdateBookForAuthor(bookForAuthorFromRepo);
            if (!_libraryRepository.Save())
            {
                throw new Exception($"Book {id} could not be updated on save.");
            }

            //// map back to entity if required
            //// return NoContent(); OR
            //var bookToReturn = Mapper.Map<BookDto>(bookForAuthorFromRepo);
            //return CreatedAtRoute("GetBookForAuthor",
            //    new { authorId = authorId, id = bookToReturn.Id },
            //    bookToReturn);
            return NoContent(); // 204 No Content

        }
    }
}
