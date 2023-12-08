using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.Helpers.TwilioSmsHelper
{
	public class TwilioSettings
	{
		public string AccountSID { get; set; }
		public string AuthToken { get; set; }
		public string TwilioPhoneNumber { get; set; }
	}
}
