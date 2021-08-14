using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Connection
{
    public class DataBaseContext : IdentityDbContext {
        public DbSet<Product> Product { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        { }
    }
}