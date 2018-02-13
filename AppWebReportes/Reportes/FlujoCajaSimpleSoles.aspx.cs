using System;
using System.Net;
using System.Web.UI;
using System.Net.Mail;
using System.Text;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaSimpleSoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MailMessage mail = new MailMessage("jorgealcantara5a@gmail.com", "jorgealcantara5a@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("jorgealcantara5a@gmail.com", "1qaz2wsxM@123");

            MailMessage mm = new MailMessage("jorgealcantara5a@gmail.com", "jorgealcantara5a@gmail.com", "test", "test");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

            if (!Page.IsPostBack)
            {
                //var fromAddress = new MailAddress("jorgealcantara@gmail.com", "From Name");
                //var toAddress = new MailAddress("jorgealcantara@gmail.com", "To Name");
                //const string fromPassword = "1qaz2wsxM@123";
                //const string subject = "Subject";
                //const string body = "Body";

                //var smtp = new SmtpClient
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                //};
                //using (var message = new MailMessage(fromAddress, toAddress)
                //{
                //    Subject = subject,
                //    Body = body
                //})
                //{
                //    smtp.Send(message);
                //}
            }
        }
    }
}