namespace FoodCorner.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsyncWithMimeKit(string mailTo, string subject, string body, IList<IFormFile>? attatchments);
    }
}
