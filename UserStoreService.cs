using System;

namespace TestDoubles
{
    public class DummyClass
    {

        public string SayMessage()
        {
            return "Wel Come User";
        }
    }

    public class UserStoreService
    {
        public UserStoreService(DummyClass dummyClass)
        {
        }

        public string GetMessage()
        {
            return "Wel Come to the new user";
        }
    }
}