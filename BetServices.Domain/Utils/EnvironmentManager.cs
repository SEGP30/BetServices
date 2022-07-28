using System;

namespace BetServices.Domain.Utils
{
    public static class EnvironmentManager
    {
        public static string DbConnection => Environment.GetEnvironmentVariable("DB_CONNECTION");
    }
}