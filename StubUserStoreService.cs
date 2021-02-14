namespace TestDoubles
{
    public class StubUserStoreService : IUserStoreService
    {
        public string GetUserRole(string username)
        {
            return "contributor";
        }
    }
}