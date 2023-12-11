using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmailService
    {
        Task SendResetPasswordLinkToEmailAsync(string resetPasswordEmailLink, string toEmail);
    }
}
