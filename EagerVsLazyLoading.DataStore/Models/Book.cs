namespace EagerVsLazyLoading.DataStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PubYear { get; set; }
        public  Author Author { get; set; } = null!;
    }
}
