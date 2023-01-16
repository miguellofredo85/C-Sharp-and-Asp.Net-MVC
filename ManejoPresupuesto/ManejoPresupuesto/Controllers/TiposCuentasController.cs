using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;


namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas) 
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = 1;
            var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
            return View(tiposCuentas);
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid) // hace que no se borre la info del formulario al presionar enviar
            {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;

            var yaExisteTipoCuenta = await repositorioTiposCuentas.Existe(tipoCuenta.UsuarioId, tipoCuenta.Nombre);

            if (yaExisteTipoCuenta)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre),
                    $"El nombre {tipoCuenta.Nombre} ya existe");
            }

            await repositorioTiposCuentas.Crear(tipoCuenta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExistenciaCuenta(string nombre)
        {
            var usuarioId = 1;
            var yaExisteTipoCuenta = await repositorioTiposCuentas.Existe(usuarioId, nombre);

            if (yaExisteTipoCuenta)
            {
                return Json($"El {nombre} ya existe");
            }
            return Json(true);
        }
    }
}