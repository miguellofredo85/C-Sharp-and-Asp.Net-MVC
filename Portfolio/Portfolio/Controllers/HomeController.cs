using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepoProjetos repoProjetos;

        public HomeController(ILogger<HomeController> logger, RepoProjetos repoProjetos)
        {
            _logger = logger;
            this.repoProjetos = repoProjetos;
        }

        

        public IActionResult Index()
        {
            var projects = repoProjetos.GetProjects().Take(3).ToList();
            var model  = new HomeIndexViewModel() { Projects = projects };
            return View(model);
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
    }
}