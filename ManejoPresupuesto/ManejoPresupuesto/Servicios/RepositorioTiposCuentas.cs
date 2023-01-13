using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios
{
    interface IRepositorioTiposCuentas
    {

    }
    public class RepositoriosTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositoriosTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void Crear(TipoCuenta tipoCuenta)
        {

        }
    }
}
