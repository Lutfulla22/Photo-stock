using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Entities;

namespace Test.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly DataDbContext _context;
        private readonly ILogger<AuthorService> _logger;

        public PhotoService(DataDbContext context, ILogger<AuthorService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception, Photos Photos)> CreateAsync(Photos photos)
        {
            try
            {
                await _context.Photo.AddAsync(photos);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Actor created in DB. ID: {photos.Id}");
                return (true, null, photos);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Creating Actor in DB failed.");
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeletAsync(Guid id)
        {
            var photos = await GetAsync(id);
            if (photos == default(Photos))
            {
                return (false, new Exception("Not found."));
            }
            try
            {
                _context.Photo.Remove(photos);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Actor deleted in DB. ID: {photos.Id}");
                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Deleting Actor in DB failed.");
                return (false, e);
            };
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Photos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Photos> GetAsync(Guid id)
            => _context.Photo.FirstOrDefaultAsync(a => a.Id == id);

        public Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Photos photos)
        {
            throw new NotImplementedException();
        }
    }
}