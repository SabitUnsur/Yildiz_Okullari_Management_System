using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.Helpers.Dtos
{
	public class SendSmsDto
	{
		public required string MobileNumber { get; set; }
		public required string Body { get; set; }
	}
}
