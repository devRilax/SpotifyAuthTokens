using System;
using System.Collections.Generic;
using System.Text;

namespace AppToken.Services.repositories
{
    public static class UserRepository
    {
        public static List<User> All()
        {
            return new List<User>()
            {
                new User("Usuario genérico", "usuario", "1234"),
                new User("Danilo Caro", "dcaro", "1234")
            };
        }
    }
}
