using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Mail
    {
        public static bool SendMail(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            mail.From = new MailAddress("lielb1005@gmail.com", "The Valunteers");
            mail.Subject = subject;
            mail.Body = message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.To.Add(email);
            client.Credentials = new System.Net.NetworkCredential("lielb1005@gmail.com", "322766734");
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception caught in sendMail(): {0}", ex.ToString());
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
        public static bool SendMailForGroup(List<string> Emails, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            mail.From = new MailAddress("lielb1005@gmail.com", "The Valunteers");
            mail.Subject = subject;
            mail.Body = message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            Emails.ForEach(email => mail.Bcc.Add(email));
            client.Credentials = new System.Net.NetworkCredential("lielb1005@gmail.com", "322766734");
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception caught in sendMail(): {0}", ex.ToString());
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
