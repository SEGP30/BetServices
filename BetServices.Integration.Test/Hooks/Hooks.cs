using System;
using System.Threading;
using System.Threading.Tasks;
using BetServices.Integration.Test.Containers;
using BetServices.Integration.Test.Seeders;
using TechTalk.SpecFlow;

namespace BetServices.Integration.Test.Hooks
{
    [Binding]
    public class Hooks
    {
        private static TestServerFixture _testServerFixture;
        public static TestServerFixture TestServerFixture => _testServerFixture ??= new TestServerFixture();

        private static MySqlTestContainer _testContainer;
        public static MySqlTestContainer TestContainer => _testContainer ??= new MySqlTestContainer();

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            await TestContainer.InitializeAsync();
            Thread.Sleep(10000);
            Environment.SetEnvironmentVariable("DB_CONNECTION", "server=localhost;user=root;database=BetServices;port=3306;password=123456");
            MySqlSeeder.SeedContext();
        }

        [AfterTestRun]
        public static async Task AfterTestRun()
        {
            await TestContainer.DisposeAsync();
        }
    }
}