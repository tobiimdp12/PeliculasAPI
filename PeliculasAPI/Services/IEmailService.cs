namespace PeliculasAPI.Services
{
    public interface IEmailService
    {
        public  Task SendEmail(string email, string subejct, string message);
    }
}
