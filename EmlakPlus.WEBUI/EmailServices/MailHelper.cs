using System.Net.Mail;
using System.Net;

namespace EmlakPlus.WEBUI.EmailServices
{
    public class MailHelper
    {
        public static bool SendMail(string body, string to, string subject, bool isHtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, isHtml);
        }

        public static bool SendMail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false;

            try
            {
                var message = new MailMessage();

                message.From = new MailAddress("test.altanemre1989@gmail.com");

                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("test.altanemre1989@gmail.com", "vdxs vbbe rhtp mwed");

                    smtp.Send(message);

                    result = true;

                }
            }
            catch (Exception)
            {


            }

            return result;
        }
    }
}
