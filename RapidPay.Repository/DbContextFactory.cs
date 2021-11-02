using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.RapidPay.Repository
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();

            builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=RapidPay_Hola;Integrated Security=SSPI");

            return new DbContext(builder.Options);
        }
    }
}