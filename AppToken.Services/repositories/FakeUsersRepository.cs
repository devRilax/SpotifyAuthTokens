using AppToken.Services.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppToken.Services.repositories
{
    public class FakeUsersRepository
    {
        private List<User> Users { get; set; }

        public FakeUsersRepository()
        {
            Users = GetUsers();
        }

        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User(){ Username = "dcaro", Password= "1234" },
                new User(){ Username = "anonimo", Password= "1234" },
                new User(){ Username = "anonimo", Password= "1234" }
            };
        }

        public bool IsValidUser(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username.Equals(username));

            return (user != null && user.Password == password);
        }
    }
}
