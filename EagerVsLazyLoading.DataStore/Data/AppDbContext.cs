using EagerVsLazyLoading.DataStore.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EagerVsLazyLoading.DataStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        { }

        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
