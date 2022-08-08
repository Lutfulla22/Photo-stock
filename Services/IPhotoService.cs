using Test.Entities;

namespace Test.Services
{
    public interface IPhotoService
    {
        Task<bool> ExistsAsync(Guid id);
        Task<Photos> GetAsync(Guid id);
        Task<List<Photos>> GetAllAsync();
        Task<(bool IsSuccess, Exception Exception, Photos Photos)> CreateAsync(Photos photos);
        Task<(bool IsSuccess, Exception Exception)> UpdateAsync(Photos photos);
        Task<(bool IsSuccess, Exception Exception)> DeletAsync(Guid id);
    }
}