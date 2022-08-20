using SendGrid;
using SendGrid.Helpers.Mail;

namespace PeliculasAPI.Services
{
    public class EmailService:IEmailService
    {
        public async Task SendEmail(string email, string subejct, string message)
        {
            const string APIKEY = "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";
         
            var client = new SendGridClient(APIKEY); //crea una instancia del send grid
            var from = new EmailAddress("tobiasselva@gmail.com", "Tobias Selva"); //origen- emisor
            var subject = subejct;
            var to = new EmailAddress(email, "Example User"); //destino- receptor
            var plainTextContent = "and easy to do anywhere, even with C#"; //contenido
            var htmlContent = $"<strong> {message} </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);


        }
    }
}
