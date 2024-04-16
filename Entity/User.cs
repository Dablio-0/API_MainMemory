namespace API_MainMemory.Entity
{
    public class User
    {
        public int id { get; init; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User()
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}
