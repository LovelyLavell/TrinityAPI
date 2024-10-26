using Microsoft.EntityFrameworkCore;
using TrinityAPI.Database.Context;
using TrinityAPI.Services;

namespace TrinityAPI.Database.Factory
{
    public class FactoryGame : IDbContextFactory<ContextGame>
    {
        private readonly int retryCount;
        private readonly string connectionString;
        private readonly string GenericContextFactoryError;
        private readonly string name;
        public FactoryGame(ServiceConfiguration configs)
        {
            connectionString = configs.ConnectionStrings[0];
            name = "Game Context Factory";
            retryCount = configs.retryCount;
            GenericContextFactoryError = configs.GenericContextFactoryError;
        }
        ContextGame IDbContextFactory<ContextGame>.CreateDbContext()
        {
            string error = GenericContextFactoryError;
            for(int i = 0; i < retryCount; i++)
            {
                var builder = new DbContextOptionsBuilder<ContextGame>();
                builder.UseSqlServer(connectionString);
                var context = new ContextGame(builder.Options);
                if (context.Database.CanConnect())
                {
                    return context;
                }
                error = "Failed to connect at " + i + " attempts with connection " + connectionString;
            }
            throw new Exception("EXCEPTION in " + name + ": " + error);
        }
    }
}
