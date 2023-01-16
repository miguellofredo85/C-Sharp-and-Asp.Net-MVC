using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [PrimeraLetraMayuscula]
        //[Remote(action: "VerificarExistenciaCuenta", controller:"TiposCuentas")]
        // Remote hace conexion del front y back y valida entrando al httpget del action para validar
        // el httppost del crear y verificar yaExisteTipoCuenta
        public string Nombre { get; set; }
        public int UsuarioId { get; set;}
        public int Orden { get; set; }

        // Este tipo de validacion de abajo sirve e caso de que queramos validar varios campo del modelo,
        // pero como solo validamos Nombre lo hacemos por atributo asi podemos reutilizarlo tambien

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0)
        //    {
        //        var primeraLetra = Nombre[0].ToString();
        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula",
        //                new[] {nameof(Nombre)});
        //        }
        //    }
        //}
    }

}
