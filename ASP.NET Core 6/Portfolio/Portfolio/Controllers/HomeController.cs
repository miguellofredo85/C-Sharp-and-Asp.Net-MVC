using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepoProjetos repoProjetos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepoProjetos repoProjetos, 
            IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repoProjetos = repoProjetos;
            this.servicioEmail = servicioEmail;
        }

        

        public IActionResult Index()
        {
            var projects = repoProjetos.GetProjects().Take(3).ToList();
            var model  = new HomeIndexViewModel() { Projects = projects };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projetos = repoProjetos.GetProjects();
            return View(projetos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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