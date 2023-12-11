using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Core.Utils.Helpers.TwilioSmsHelper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Business.Concrete
{
	public class SmsService : ISmsService
	{
		private readonly TwilioSettings _twilio;

		public SmsService(IOptions<TwilioSettings> twilio)
		{
			_twilio = twilio.Value;
		}

		public MessageResource Send(string mobileNumber, string body)
		{
			TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

			var result = MessageResource.Create(
				body : body,
				from : new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
				to : mobileNumber
				);

			if(!string.IsNullOrEmpty(result.ErrorMessage)) 
			{
				throw new SmsSendFailedException(Messages.SmsSendingFailed);
			}

			return result;
		}
	}
}
