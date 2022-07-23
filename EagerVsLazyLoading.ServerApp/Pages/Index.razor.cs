using EagerVsLazyLoading.DataStore.Data;
using EagerVsLazyLoading.DataStore.Models;
using Microsoft.AspNetCore.Components;

namespace EagerVsLazyLoading.ServerApp.Pages
{
    public partial class Index : ComponentBase
    {
        public List<Author> Authors { get; set; }
        [Inject] public AppDbContext Context { get; set; }
        protected override void OnInitialized()
        {
            if (Context.Database.EnsureCreated())
            {
                GetBooksByAuthorEager(Context);
            }

        }

        private void GetBooksByAuthorEager(AppDbContext context)
        {
            Authors = context.Authors.ToList();
        }
    }
}
