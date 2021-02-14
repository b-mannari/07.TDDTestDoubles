using System;
using System.Collections.Generic;
using System.Text;

namespace TestDoubles
{
    public class SpyUserStoreService : IUserStoreService
    {
        private static int Counter { get; set; }
        public SpyUserStoreService()
        {
            Counter = 0;
        }

        public string GetUserRole(string username)
        {
            if (Counter >= 1)
                return "Function called more than once";
            Counter++;
            return (username == "admin") ? "administrator" : "contributor";
        }
    }
}
