using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private DbSet<Category> _categories;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories => _categories;
    }
}
