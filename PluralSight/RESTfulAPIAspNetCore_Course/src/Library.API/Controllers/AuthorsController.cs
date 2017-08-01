using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            // throw new Exception("FUCK");

            if (authorFromRepo == null) return NotFound();

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}
