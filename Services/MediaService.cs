using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Entities;

namespace Test.Services
{
    public class MediaService : IMediaService
    {
        private readonly DataDbContext _context;
        private readonly ILogger<MediaService> _logger;

        public MediaService(DataDbContext context, ILogger<MediaService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            var media = await GetAsync(id);
            if (media is default(Media))
            {
                return (false, new Exception("Not found."));
            }
            try
            {
                _context.Medias.Remove(media);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Medias deleted in DB.");
                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Deleting medias in DB failed.\nError:{e.Message}", e);
                return (false, e);
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _context.Medias.AnyAsync(m => m.Id == id);

        public async Task<bool> ExistsAsync(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                if (await ExistsAsync(id))
                {
                    return false;
                }
            }
            return true;
        }

        public Task<List<Media>> GetAllAsync()
            => _context.Medias.ToListAsync();

        public Task<Media> GetAsync(Guid id)
            => _context.Medias.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> InsertAsync(List<Media> media)
        {
            try
            {
                await _context.Medias.AddRangeAsync(media);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Medias created in DB.");
                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Creating medias in DB failed.\nError:{e.Message}, e");
                return (false, e);
            }
        }
    }
}