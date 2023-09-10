using System.Net.Mail;
using System.Net;

namespace HangfireApp
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherService()
        {

        }
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
            var mailBody = $"Temparatute in celsius for {string.Join(',', weather.Select(v => v.Date))} is \n {string.Join(',', weather.Select(v => v.TemperatureC))} respectively";
            //var fromAddress = new MailAddress("olanrewajuelizabeth97@gmail.com", "Lolade");
            //var toAddress = new MailAddress("lolareliza@gmail.com", "Ololade");
            //const string fromPassword = "Lolade@1";
            //const string subject = "Weather report";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 465,

            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = mailBody
            //})

            //var email = SendEmail(mailBody);
            return weather;
        }
        //private string SendEmail(string body)
        //{
        //    // Replace with your Gmail email address and password (or App Password for 2FA)
        //    //string email = "olanrewajuelizabeth97@gmail.com";
        //    //string password = "Lolade@1";
        //    //string smtpServerAddress = "142.251.31.108";
        //    //// Create a new SmtpClient
        //    ////var smtpClient = new SmtpClient("smtp.gmail.com")
        //    //var smtpClient = new SmtpClient(smtpServerAddress)
        //    //{
        //    //    Port = 587, // Gmail SMTP port
        //    //    Credentials = new NetworkCredential(email, password),
        //    //    EnableSsl = true, // Enable SSL/TLS encryption
        //    //};
            
        //    using var smtpServer = new SmtpClient("smtp.office365.com");
        //    smtpServer.Credentials =
        //        new System.Net.NetworkCredential("oolarenwaju@wragbysolutions.com", "Wragby2023");
        //    smtpServer.Port = 587;
        //    smtpServer.EnableSsl = true;
        //    smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    // Create a new MailMessage
        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("oolarenwaju@wragbysolutions.com"),
        //        Subject = "Subject",
        //        Body = body,
        //    };

        //    // Add recipients (To, CC, BCC)
        //    mailMessage.To.Add("lolareliza@gmail.com"); // Replace with the recipient's email address

        //    // Send the email
        //    try
        //    {
        //        smtpServer.Send(mailMessage);
        //        return "Email sent successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Failed to send email: {ex.Message}";
        //    }

        //}
    }
}
