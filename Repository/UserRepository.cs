using API_MainMemory.Entity;
using API_MainMemory.Interfaces;

namespace API_MainMemory.Repositoty
{
    public class UserRepository : IUserRepository
    {
        private int lastId = 0;
        IList<User> users = new List<User>();

        public void CreateUser(User usuario)
        {
            lastId++;
            users.Add(new User
            {
                id = lastId,
                name = usuario.name,
                email = usuario.email,
                password = usuario.password
            });
        }

        public void EditUser(User usuario)
        {
            var editUser = ShowUserById(usuario.id);
            editUser.name = usuario.name;
            editUser.email = usuario.email;
            editUser.password = usuario.password;
        }

        public User ShowUserById(int id)
        {
            return users.FirstOrDefault(usuario => usuario.id == id);
        }

        public IList<User> ShowAllUsers()
        {
            return users;
        }

        public void RemoveUser(int id)
        {
            var deletarUser = ShowUserById(id);
            users.Remove(deletarUser);
        }
    }
}

