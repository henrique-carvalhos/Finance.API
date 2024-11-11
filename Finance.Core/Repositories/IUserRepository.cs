using Finance.Core.Entities;

namespace Finance.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetbyId (int id);
        Task<List<User>> GetAll();
        Task<int> Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
