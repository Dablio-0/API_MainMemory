using API_MainMemory.Entity;

namespace API_MainMemory.Interfaces
{
    public interface IUserRepository
    {
        IList<User> ShowAllUsers();

        User ShowUserById(int id);

        void CreateUser(User user);

        void EditUser(User user);

        void RemoveUser(int id);
    }
}
