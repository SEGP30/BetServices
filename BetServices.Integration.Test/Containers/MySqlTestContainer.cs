using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Xunit;

namespace BetServices.Integration.Test.Containers
{
    public class MySqlTestContainer : IAsyncLifetime
    {
        private readonly TestcontainersContainer _mySqlContainer;

        public MySqlTestContainer()
        {
            var mySqlLocal = new TestcontainersBuilder<TestcontainersContainer>()
                .WithImage("mariadb:10.9.4")
                .WithEnvironment("MARIADB_ROOT_PASSWORD", "123456")
                .WithEnvironment("MARIADB_DATABASE", "BetServices")
                .WithCleanUp(true)
                .WithPortBinding(3306, 3306);
            _mySqlContainer = mySqlLocal.Build();
        }

        public async Task InitializeAsync()
        {
            await _mySqlContainer.StartAsync();
        }

        public async Task DisposeAsync()
        {
            await _mySqlContainer.StopAsync();
        }
    }
}