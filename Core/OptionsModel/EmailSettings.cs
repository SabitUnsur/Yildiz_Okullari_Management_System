using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OptionsModel
{
    // bu sınıfı appsettings.json dosyasında tanımladığımız EmailSettings adlı bir nesne ile eşleştirmek için kullanıyoruz
    public class EmailSettings
    {
        public string ?Host { get; set; } // host stmtp.gmail.com
        public string ?Password { get; set; } // password haylejj3@gmail.com app password
        public string ?Email { get; set; } // haylejj3@gmail.com
        
    }
}
