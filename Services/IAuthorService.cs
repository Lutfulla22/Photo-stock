using Test.Entities;

namespace Test.Services
{
    public interface IAuthorService
    {
        Task<bool> ExistsAsync(Guid id);
        Task<Author> GetAsync(Guid id);
        Task<List<Author>> GetAllAsync();
        Task<(bool IsSuccess, Exception Exception, Author Author)> CreateAsync(Author author);
        Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Author author);
        Task<(bool IsSuccess, Exception Exception)> DeletAsync(Guid id);
    }
}