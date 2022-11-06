using SendGrid;
using SendGrid.Helpers.Mail;

namespace Talleres.API.Utilities
{
    public class EmailSender
    {
        public static void Principal(string mensaje)
        {
             Execute(mensaje).Wait();
        }

        static async Task Execute(string mensaje)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("2502592017@mail.utec.edu.sv", "Biblioteca Comunitaria de Jardines de Colón");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("amilton.rodriguez77@gmail.com", "Estudiante");
            var plainTextContent = mensaje;
            var htmlContent = "<strong" + mensaje +"</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
