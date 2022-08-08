using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Entities;

namespace Test.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly DataDbContext _context;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(DataDbContext context, ILogger<AuthorService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception, Author Author)> CreateAsync(Author author)
        {
            try
            {
                await _context.Author.AddAsync(author);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Actor created in DB. ID: {author.Id}");
                return (true, null, author);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Creating Actor in DB failed.");
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeletAsync(Guid id)
        {
            var author = await GetAsync(id);
            if (author == default(Author))
            {
                return (false, new Exception("Not found."));
            }
            try
            {
                _context.Author.Remove(author);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Actor deleted in DB. ID: {author.Id}");
                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Deleting Actor in DB failed.");
                return (false, e);
            };
        }

        public Task<bool> ExistsAsync(Guid id)
            => _context.Author.AnyAsync(a => a.Id == id);

        public Task<List<Author>> GetAllAsync()
            => _context.Author.ToListAsync();


        public Task<Author> GetAsync(Guid id)
            => _context.Author.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Author author)
        {
            if (!await ExistsAsync(author.Id))
            {
                return (false, new Exception("Not found."));
            }
            try
            {
                _context.Author.Update(author);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Actor updated in DB. ID: {author.Id}");
                return (true, null);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Updating Actor in DB failed.");
                return (false, e);
            }
        }
    }
}