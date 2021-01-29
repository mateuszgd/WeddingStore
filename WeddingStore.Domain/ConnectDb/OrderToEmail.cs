using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.Models;

namespace WeddingStore.Domain.ConnectDb
{
    public class OrderToEmail : IProcessOrder
    {
        private Email email;

        public OrderToEmail(Email emailParam)
        {
            email = emailParam;
        }

        public void OrderProcess(CartFunctions cartFunctions, Order order)
        {
            using (var smpt = new SmtpClient())
            {
                smpt.UseDefaultCredentials = false;
                smpt.Credentials = new NetworkCredential(email.Login, email.Password);
                smpt.Host = email.ServerName;
                smpt.Port = email.Port;
                smpt.EnableSsl = email.Ssl;

                if (email.File)
                {
                    smpt.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smpt.PickupDirectoryLocation = email.Target;
                    smpt.EnableSsl = false;
                }

                StringBuilder builder = new StringBuilder()
                    .AppendLine("Zamówienie:")
                    .AppendLine("");

                foreach (var m in cartFunctions.Cart)
                {
                    var sum = m.Product.Price * m.Number;
                    builder.AppendFormat("{0} x {1}     {2:c}", m.Product.Name, m.Number, sum)
                           .AppendLine("");
                }


                builder.AppendFormat("W sumie:     {0:c}", cartFunctions.SumItem())
                    .AppendLine("")
                    .AppendLine("")
                    .AppendLine("Adres dostawy:")
                    .AppendLine(order.FirstName)
                    .AppendLine(order.LastName)
                    .AppendLine(order.Phone)
                    .Append(order.Street + " ").Append(order.House).AppendLine("/" + order.Apartment)
                    .Append(order.City + ", ").AppendLine(order.Zip);

                MailMessage message = new MailMessage
                (
                    email.UserMail,
                    email.AdminMail,
                    "Nowe zamówienie",
                    builder.ToString()
                );

                if (email.File)
                {
                    message.BodyEncoding = Encoding.UTF8;
                }

                smpt.Send(message);
            }
        }
    }

    public class Email
    {
        public string Login = "admin";
        public string Password = "1234";
        public string AdminMail = "admin@test.pl";
        public string UserMail = "user@test.pl";
        public string Target = @"d:\order";
        public string ServerName = "smtp.test.pl";
        public int Port = 587;
        public bool Ssl = true;
        public bool File = false;
    }
}