using EagerVsLazyLoading.DataStore.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EagerVsLazyLoading.DataStore.Data.Managers
{
    public static class DataStoreManager
    {
        /// <summary>
        /// Update books after database created
        /// </summary>
        /// <param name="context"> Published Year </param>
        public static void UpdateData(AppDbContext context)
        {
            var books = context.Books.ToList();
            for (int i = 0; i < books.Count; i++)
            {
                switch (books[i].Id)
                {
                    case 1: books[i].PubYear = 1815; break;
                    case 2: books[i].PubYear = 1818; break;
                    case 3: books[i].PubYear = 1814; break;
                    case 4: books[i].PubYear = 1958; break;
                    case 5: books[i].PubYear = 1959; break;
                    case 6: books[i].PubYear = 1957; break;
                    default:
                        break;
                }
            }
            context.SaveChanges();
        }

        public static void SeedData(AppDbContext context)
        {
            var authors = new List<Author>()
            {
                new() { Name = "Jane Austin" },
                new() { Name = "Ian Fleming" }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var books = new List<Book>()
            {
                new() { Title = "Emma", Author = context.Authors.Find(1) },
                new() { Title = "Persuasion", Author = context.Authors.Find(1) },
                new() { Title = "Manfield Park", Author = context.Authors.Find(1) },
                new() { Title = "Dr No", Author = context.Authors.Find(2) },
                new() { Title = "Gold finger", Author = context.Authors.Find(2) },
                new() { Title = "From Russia With love", Author = context.Authors.Find(2) },
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }

        /// <summary>
        /// Eager loading method using Include
        /// </summary>
        /// <param name="context"> </param>
        public static List<Author> GetBooksByAuthorEager(AppDbContext context)
        {
            // eager loading using Include another related entity
            var authors = context.Authors
                .Include(b => b.Books)
                .ToList();
            //for (int i = 0; i < authors.Count; i++)
            //{
            //   // Console.WriteLine($"Author {authors[i].Name} Books: ");
            //    var books = authors[i].Books.ToList();
            //    for (int b = 0; b < books.Count; b++)
            //    {
            //        Console.WriteLine("Book Title: {0} Published: {1}",
            //        books[b].Title, books[b].PubYear);
            //    }
            //}

            return authors;
        }

        /// <summary>
        /// Lazy loading method using the  directive before DbSet() and Microsoft.EntityFrameworkCore.Proxies
        /// Lazy loading proxies for Entity Framework Core.
        /// </summary>
        /// <param name="context"> </param>
        public static List<Author> GetBooksByAuthorLazy(AppDbContext context)
        {
            var authors = context.Authors.ToList();
            //for (int i = 0; i < authors.Count; i++)
            //{
            //    Console.WriteLine($"Author {authors[i].Name} Books: ");
            //    var books = authors[i].Books.ToList();
            //    for (int b = 0; b < books.Count; b++)
            //    {
            //        Console.WriteLine("Book Title: {0} Published: {1}",
            //        books[b].Title, books[b].PubYear);
            //    }
            //}

            return authors;
        }
    }
}
