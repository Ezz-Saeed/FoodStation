using FoodCorner.Settings;
//using MailKit.Net.Smtp;
//using MailKit.Security;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
//using MimeKit;

namespace FoodCorner.Services
{
    public class EmailService : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "moatazsaeed299@gmail.com";
            var fPassowrd = "vmky nizn tdwg blxl";
            var thMessage = new MailMessage();
            thMessage.From = new MailAddress(fMail);
            thMessage.Subject = subject;
            thMessage.Body = $"<html><body>{htmlMessage}</html></body>";
            thMessage.IsBodyHtml = true;
            thMessage.To.Add(email);

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassowrd),
                Port = 587,
            };
            smtp.Send(thMessage);
        }

        //public async Task SendEmailAsyncWithMimeKit(string mailTo, string subject, string body, IList<IFormFile>? attatchments)
        //{
        //    MimeMessage email = new()
        //    {
        //        Subject = subject,
        //        Sender = MailboxAddress.Parse(_mailSettings.Email)
        //    };
        //    email.To.Add(MailboxAddress.Parse(mailTo));
        //    var builder = new BodyBuilder();

        //    if (attatchments is not null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in attatchments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    file.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //                }
        //            }
        //        }
        //    }
        //    builder.HtmlBody = body;
        //    email.Body = builder.ToMessageBody();
        //    email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
        //}
    }
}
