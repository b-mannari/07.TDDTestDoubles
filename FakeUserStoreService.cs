namespace TestDoubles
{
    public class FakeUserStoreService : IUserStoreService
    {
        public string GetUserRole(string username)
        {
            if (username == "admin")
                return "administrator";
            else
                return "contributor";
        }
    }

}