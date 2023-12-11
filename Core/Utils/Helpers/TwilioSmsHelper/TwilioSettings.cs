using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.Helpers.TwilioSmsHelper
{
	public class TwilioSettings
	{
		public required string AccountSID { get; set; }
		public required string AuthToken { get; set; }
		public required string TwilioPhoneNumber { get; set; }
	}
}
