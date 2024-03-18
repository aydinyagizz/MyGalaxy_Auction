using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace MyGalaxy_Auction_Core.MailHelper
{
    public class MailService : IMailService
    {
        public void SendMail(string subject, string body, string email)
        {
            try
            {
                var emailToSend = new MimeMessage();
                // nereden mail gidecek
                emailToSend.From.Add(MailboxAddress.Parse("YourGalaxyAuction@gmail.com"));
                //göndereceğimiz maili göndermeye uygun olarak Parse ediyoruz.
                emailToSend.To.Add(MailboxAddress.Parse(email));
                emailToSend.Subject = subject;
                emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                // mail gönderme
                using var emailClient = new SmtpClient();
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                //maili gönderecek orjinal bir mail hesabı
                emailClient.Authenticate("aydinyagiz002@gmail.com", "lrnioeajwdvhzeln");
                emailClient.Send(emailToSend);
                //bağlantı kapatma işlemi
                emailClient.Disconnect(true);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }
    }
}
