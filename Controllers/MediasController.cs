using Microsoft.AspNetCore.Mvc;
using Test.Entities;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediasController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] NewMedia media)
        {
            var images = media.Data.Select(f =>
            {
                using var stream = new MemoryStream();
                f.CopyTo(stream);
                return new Media(data: stream.ToArray());
            }).ToList();

            var result = await _mediaService.InsertAsync(images);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var medias = await _mediaService.GetAllAsync();
            var json = medias.Select(m => new
            {
                Id = m.Id,
                Data = m.Data
            });

            return Ok(json);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => Ok(await _mediaService.GetAsync(id));

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
            => Ok(await _mediaService.DeleteAsync(id));
    }
}