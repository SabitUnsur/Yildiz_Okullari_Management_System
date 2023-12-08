using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Business.Abstract
{
	public interface ISmsService
	{	
		MessageResource Send(string mobileNumber, string body);
	}
}
