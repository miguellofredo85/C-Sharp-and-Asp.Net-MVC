using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(int usuarioId, string nombre);
    }
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync<int>
                                                   ($@"insert into TiposCuentas (Nombre, UsuarioId, Orden) 
                                                    value (@Nombre, @UsuarioId, 0)
                                                    SELECT SCOPE_IDENTITY();", tipoCuenta);
            tipoCuenta.Id= id;

        }

        public async Task<bool> Existe(int usuarioId, string nombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                                                                   $@"select 1
                                                                      from TipoCuentas
                                                                      where Nombre = @Nombre and UsuarioId = @UsuarioId;",
                                                                   new {nombre, usuarioId});
            return existe == 1;
        }
    }
}
