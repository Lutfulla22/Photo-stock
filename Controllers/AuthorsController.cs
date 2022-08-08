using Microsoft.AspNetCore.Mvc;
using Test.Entities;
using Test.Mapper;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewAuthor author)
        {
            var result = await _authorService.CreateAsync(author.ToEntity());

            if (result.IsSuccess)
            {
                return Ok(result.Author);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _authorService.GetAllAsync());

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => Ok(await _authorService.GetAsync(id));

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] NewAuthor author)
        {
            var entity = author.ToEntity();
            entity.Id = id;
            var result = await _authorService.UpdateAsync(entity);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
            => Ok(await _authorService.DeletAsync(id));
    }
}