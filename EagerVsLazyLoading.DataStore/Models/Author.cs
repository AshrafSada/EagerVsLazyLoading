namespace EagerVsLazyLoading.DataStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; } = null!;
    }
}
