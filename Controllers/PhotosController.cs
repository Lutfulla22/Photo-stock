using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Test.Mapper;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMediaService _mediaService;
        private readonly AuthorService _authorService;

        public PhotosController(IPhotoService photoService, IMediaService mediaService, AuthorService authorService)
        {
            _photoService = photoService;
            _mediaService = mediaService;
            _authorService = authorService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewPhotos photos)
        {
            var authors = photos.AuthorId.Select(id => _authorService.GetAsync(id).Result);
            var medias = photos.MediasId.Select(id => _mediaService.GetAsync(id).Result);
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var result = JsonSerializer.Serialize(await _photoService.CreateAsync(photos.ToEntity(medias,  authors)));

            return Ok(result);
        }

    }
}           