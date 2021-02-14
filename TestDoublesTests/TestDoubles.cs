using NUnit.Framework;
using TestDoubles;
using Moq;

namespace TestDoublesTests
{
    public class TestDoubles
    {
        readonly DummyClass dummyClass = new DummyClass();
        UserStoreService userStoreService;
        FakeUserStoreService fakeUserStoreService;
        StubUserStoreService stubUserStoreService;
        SpyUserStoreService spyUserStoreService;
        //MockUserStoreService mockUserStoreService;

        [SetUp]
        public void Setup()
        {
            userStoreService = new UserStoreService(dummyClass);
            fakeUserStoreService = new FakeUserStoreService();
            stubUserStoreService = new StubUserStoreService();
            spyUserStoreService = new SpyUserStoreService();
            //mockUserStoreService = new MockUserStoreService();
        }

        [Test]
        public void Test_Dummy()
        {
            string expected = "Wel Come to the new user";
            string result = userStoreService.GetMessage();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Fake()
        {
            string expected = "administrator";
            string result = fakeUserStoreService.GetUserRole("admin");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Stub()
        {
            string expected = "contributor";
            string result = stubUserStoreService.GetUserRole("admin");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Spy()
        {
            string expected = "contributor";
            string result = spyUserStoreService.GetUserRole("user");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Spy1()
        {
            string expected = "contributor";
            string result = spyUserStoreService.GetUserRole("user");
            Assert.AreEqual(expected, result);

            expected = "Function called more than once";
            result = spyUserStoreService.GetUserRole("user");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Mock()
        {
            var mockUserStore = new Mock<IUserStoreService>();
            mockUserStore.Setup(x => x.GetUserRole("admin")).Returns("administrator");
            //mockUserStore.Setup(x => x.GetUserRole(It.IsAny<string>())).Returns("contributor");

            var result = mockUserStore.Object.GetUserRole("admin");
             //result = mockUserStore.Object.GetUserRole("user");
            Assert.AreEqual("administrator", result);

            //Mock<IUserStoreService> mockedUserStore = new Mock<IUserStoreService>();
            //mockedUserStore.Setup(func => func.GetUserRole("admin")).Returns("administrator");
            //mockedUserStore.Setup(func => func.GetUserRole("user1")).Returns("contributor");
            //mockedUserStore.Setup(func => func.GetUserRole("user2")).Returns("basic");

            ////var result = mockedUserStore.Object.GetUserRole(It.IsAny<string>());
            //var result = mockedUserStore.Object.GetUserRole("admin");
            //string expected = string.Format("{0}", result);
            //Assert.AreEqual("administrator", expected);
        }

        [TearDown]
        public void TearDown()
        {
            userStoreService = null;
            fakeUserStoreService = null;
            stubUserStoreService = null;
            spyUserStoreService = null;
            //mockUserStoreService = null;
        }
    }
}