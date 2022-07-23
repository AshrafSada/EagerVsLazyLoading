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

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
