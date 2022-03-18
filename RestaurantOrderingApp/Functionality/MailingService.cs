using System;
using System.Net.Mail;
using System.Net;
using RestaurantOrderingApp.Models;

namespace RestaurantOrderingApp.Functionality
{
    internal class MailingService:IEmail
    {
        
        public void MailSendInquiry()
        {
            Console.WriteLine("Does client want check to be sent to email? y/n");
            string answer = Console.ReadLine().Trim().ToLower();
            bool mailSend = true;
            while (mailSend)
            {
                if (answer == "y")
                {
                    Console.WriteLine("enter email");
                    string emailAddress = Console.ReadLine();
                    SendEmail(emailAddress);
                    Console.ReadKey();
                    mailSend = false;
                }
                else if (answer == "n")
                {
                    mailSend = false;
                }
                else
                {
                    Console.WriteLine("incorect input");
                    Console.ReadKey();
                    break;
                }
            }
                
        }
        public void SendEmail(string email)
        {
            string to = email;
            string from = "webshop.codeacademy@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Receipt for your last visit at the restaurant";
            message.Body = @"Receipt for today's lunch attached below, thank you!";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            FilePath filePath = new FilePath("CustomerCheck.txt");
            var file = new Attachment(filePath.Path);
            message.Attachments.Add(file);
            client.Port = 587;
            client.Credentials = new NetworkCredential(from, "slaptazodis12");
            client.EnableSsl = true;
            try
            {
                client.Send(message);
                Console.WriteLine("Mail sent, press any key to refresh");
                Console.ReadKey();
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            };
            
        }
    }
}
