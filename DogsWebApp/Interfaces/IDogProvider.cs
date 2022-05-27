using DogsWebApp.Models;

namespace DogsWebApp.Interfaces
{
    public interface IDogProvider
    {
        Task<ICollection<Dog>> GetAllAsync();
        Task<Dog> GetAsync(int id);
        Task<ICollection<Dog>> SearchAsync(string search);
        Task<bool> UpdateAsync(int id, Dog _dog);
        Task<(bool IsSuccess, int? Id)> AddAsync(Dog _dog);
        Task<bool> RemoveAsync(int id);
    }
}
