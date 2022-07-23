using System.Diagnostics;
using EagerVsLazyLoading.DataStore.Data;
using EagerVsLazyLoading.DataStore.Data.Managers;
using EagerVsLazyLoading.DataStore.Models;
using EagerVsLazyLoading.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EagerVsLazyLoading.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this._context = context;
            _context.Database.EnsureCreated();
        }

        public List<Author> Authors { get; set; }

        public IActionResult Index()
        {
            //InitializeDatabaseWithData(_context);
            GetBooksByAuthor(_context);

            return View(Authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetBooksByAuthor(AppDbContext context)
        {
            //Authors = context.Authors.ToList();
            Authors = DataStoreManager.GetBooksByAuthorEager(context);
            //Authors = DataStoreManager.GetBooksByAuthorLazy(context);
        }

        private void InitializeDatabaseWithData(AppDbContext context)
        {
            DataStoreManager.SeedData(context);
            DataStoreManager.UpdateData(context);
        }
    }
}
