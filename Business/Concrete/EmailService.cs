using Business.Abstract;
using Core.OptionsModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings=options.Value; // appsettings.json dosyasındaki EmailSettings nesnesini burada kullanabilmek için IOptions nesnesini kullanıyoruz
        }

        public async Task SendResetPasswordLinkToEmailAsync(string resetPasswordEmailLink, string toEmail)
        {
            var smptClient = new SmtpClient();

            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network; // method olarak network kullanıyoruz
            smptClient.UseDefaultCredentials = false; // varsayılan kimlik bilgilerini kullanma
            smptClient.Port=587;//gmail için port numarası
            smptClient.Host = _emailSettings.Host; // appsettings.json dosyasındaki EmailSettings nesnesinin Host özelliğini kullanıyoruz
            //networkCredential nesnesi : kullanıcı adı ve şifre ile ilgili bilgileri tutar
            smptClient.Credentials=new NetworkCredential(_emailSettings.Email,_emailSettings.Password);// appsettings.json dosyasındaki EmailSettings nesnesinin Email ve Password özelliklerini kullanıyoruz 
            smptClient.EnableSsl = true; // ssl kullanıyoruz ssl: secure socket layer bilgilerin güvenli bir şekilde iletilmesini sağlar

            var mailMessage = new MailMessage(); // mailMessage nesnesi mail ile ilgili bilgileri tutar

            mailMessage.From= new MailAddress(_emailSettings.Email!); // mailMessage nesnesinin From özelliğine hangi mail adresinden gönderileceğini belirtiyoruz
            mailMessage.To.Add(toEmail); // mailMessage nesnesinin To özelliğine hangi mail adresine gönderileceğini belirtiyoruz

            mailMessage.Subject = "Yıldız Okulları ||  Şifre Sıfırlama Linki"; // mailMessage nesnesinin Subject özelliğine mailin konusunu belirtiyoruz

            //mailMessage.Headers.Add("Content-Type", "text/html; charset=UTF-8"); // mailMessage nesnesinin Headers özelliğine mailin içeriğinin html formatında olduğunu belirtiyoruz

            mailMessage.Body= @$" <h4>Şifrenizi yenilemek için aşşağıdaki linke tıklayınız.<h4>
                                  <p><a href='{resetPasswordEmailLink}'>Şifre Yenileme Linki</a></p>"; // mailMessage nesnesinin Body özelliğine mailin içeriğini belirtiyoruz

            mailMessage.IsBodyHtml = true; // mailMessage nesnesinin IsBodyHtml özelliğine mailin içeriğinin html formatında olduğunu belirtiyoruz

            await smptClient.SendMailAsync(mailMessage); // mailMessage nesnesini smptClient nesnesi ile gönderiyoruz
        }
    }
}
