using API_MainMemory.Entity;

namespace API_MainMemory.Interfaces
{
    public interface IUserRepository
    {
        IList<User> ShowAllUsers();

        User ShowUserById(int id);

        void CreateUser(User usuario);

        void EditUser(User usuario);

        void RemoveUser(int id);
    }
}
