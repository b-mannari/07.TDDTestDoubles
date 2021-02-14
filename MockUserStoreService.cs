using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDoubles
{
    public class MockUserStoreService : IUserStoreService
    {
        public string UserRole { get; set; }
        public string GetUserRole(string username)
        {
            UserRole = (username == "admin") ? "administrator" : "contributor";
            return UserRole;
        }
    }
}