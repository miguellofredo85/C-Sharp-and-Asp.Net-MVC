﻿namespace ManejoPresupuesto.Servicios
{
    public interface IServicioUsuario
    {
        int ObtenerUsuarioId();
    }
    public class ServicioUsuario : IServicioUsuario
    {
        public int ObtenerUsuarioId() 
        {
            return 1;
        }
    }
}
