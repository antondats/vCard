using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using vCard.Models;

namespace vCard.Infrastructure
{
    public class EmailSettings
    {
        public string MailToAddress = "messages@example.com";
        public string MailFromAddress = "vcard@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"C:\Users\Антон\Documents\Visual Studio 2015\Projects\vCard\messages";
    }

    public class EmailContactProcessor : IContactProcessor
    {
        private EmailSettings emailSettings;

        public EmailContactProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void SendMessage(ContactInfo contact)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New message!")
                    .AppendLine("---")
                    .AppendLine("Name:");


                body.AppendLine(contact.Name);


                body.AppendLine("Message: ")
                    .AppendLine(contact.Message)
                    .AppendLine("---")
                    .AppendLine("Email: ")
                    .AppendLine(contact.Email);
                    

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,	// От кого
                                       emailSettings.MailToAddress,		// Кому
                                       "New message send",		// Тема
                                       body.ToString()); 				// Тело письма

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}