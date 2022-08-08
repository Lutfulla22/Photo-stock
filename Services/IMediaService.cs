
using Test.Entities;

namespace Test.Services
{
     public interface IMediaService
    {
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(IEnumerable<Guid> id);
        Task<Media> GetAsync(Guid id);
        Task<List<Media>> GetAllAsync();
        Task<(bool IsSuccess, Exception Exception)> InsertAsync(List<Media> media);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    }
}