using API_MainMemory.Entity;
using API_MainMemory.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;


namespace API_MainMemory.Repositoty
{
    public class UserRepository : IUserRepository
    {
        private int lastId = 1;
        IList<User> users = new List<User>();

        public void CreateUser(User user)
        {
            try
            {
                if (user.name == null || user.email == null || user.password == null)
                    throw new Exception("All fields must be filled");

                if (users.Any(usersList => usersList.email == user.email))
                    throw new Exception("Email already exists");

                if (user.password.Length < 8)
                    throw new Exception("Password must be at least 8 characters");

                users.Add(new User
                {
                    id = lastId,
                    name = user.name,
                    email = user.email,
                    password = user.password
                });

                lastId++;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditUser(User user)
        {
            var editUser = ShowUserById(user.id);

            if (editUser == null)
                throw new Exception("User not found");

            if (users.Any(user => user.email == user.email))
                throw new Exception("Email already registered");

            if (user.password.Length < 8)
                throw new Exception("Password must be at least 8 characters");

            editUser.name = user.name;
            editUser.password = user.password;
        }

        public User ShowUserById(int id)
        {
            return users.FirstOrDefault(user => user.id == id);
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

