using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Services
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contactoViewModel);
    }
    public class ServicioEmailSendGrid : IServicioEmail 
    {
        private readonly IConfiguration configuration;
        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task Enviar(ContactoViewModel contactoViewModel)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENGRID_FROM");
            var nombre = configuration.GetValue<string>("SENGRID_NOME");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contactoViewModel.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensaje = contactoViewModel.Mesagem;
            var contenidoHtml = $@"De: {contactoViewModel.Nome} - 
Email: {contactoViewModel.Email} - 
Mensaje: {contactoViewModel.Mesagem}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject,mensaje, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}