using Microsoft.EntityFrameworkCore;

namespace Quadro_de_pendencias.Data
{
    public class DatabaseService
    {
        private readonly AppDbContext _dbContext;

        public DatabaseService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
