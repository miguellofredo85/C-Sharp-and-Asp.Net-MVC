using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Models
{
    public class CuentaCreacionViewModel : Cuenta
    {
        public IEnumerable<SelectListItem> TiposCuentas { get; set; }
        // SelectListItem es una clase especia de asp.net core que nos permite crear select (dropdown) sencillos
    }
}
