using SmartSaver_backend.Infrastructure;

namespace SmartSaver_backend.Repositories.Interface
{

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(User dbUser, User user);

        Task DeleteUser(User user);
    }
}
