using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Library.API.Entities;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();

            // Automapper
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

            //// Manually Mapping
            //var authors = authorsFromRepo.Select(author => new AuthorDto
            //{
            //    Id = author.Id,
            //    Name = $"{author.FirstName} {author.LastName}",
            //    Genre = author.Genre,
            //    Age = author.DateOfBirth.GetCurrentAge()
            //}).ToList();
            return new JsonResult(authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            // throw new Exception("FUCK");

            if (authorFromRepo == null) return NotFound();

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            var authorEntity = Mapper.Map<Author>(author);

            _libraryRepository.AddAuthor(authorEntity);
            if (!_libraryRepository.Save())
            {
                throw new Exception("Creating an Author failed on save.");
                //return StatusCode(500, "A problem occured adding your Author");
            }

            var authorToReturn = Mapper.Map<AuthorDto>(authorEntity);

            // EW: Route name is from GetAuthor's Route declaration
            return CreatedAtRoute("GetAuthor",
                new {id = authorToReturn.Id},
                authorToReturn);
        }
    }
}
