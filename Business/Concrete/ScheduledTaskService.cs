using Business.Abstract;
using Business.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ScheduledTaskService : IScheduledTaskService
	{
		private Timer _timer;
		private readonly ISmsService _smsService;
		private readonly IPersonService _personService;

		public ScheduledTaskService(Timer timer, ISmsService smsService, IPersonService personService)
		{
			_timer = timer;
			_smsService = smsService;
			_personService = personService;
		}

		public void StartScheduledTask(int studentId)
		{
			DateTime now = DateTime.Now;

			// Hedef saat ve dakikayı belirle
			int targetHour = 16;
			int targetMinute = 0;

			// Zamanı ayarla
			DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, targetHour, targetMinute, 0);

			// Eğer bugün hedef saatten sonraysa, bir sonraki gün için ayarla
			if (now > scheduledTime)
			{
				scheduledTime = scheduledTime.AddDays(1);
			}

			// Zamanlayıcıyı ayarla
			TimeSpan timeToGo = scheduledTime - now;

			_timer = new Timer(x => SendDailyAttendanceSmsViaTwilio(studentId), null, timeToGo, TimeSpan.FromHours(24));
		}

		public void StopScheduledTask()
		{
			// Zamanlanmış görevi durdur
			_timer?.Dispose();
		}

		private void SendDailyAttendanceSmsViaTwilio(int studentId)
		{
			var personToGetSms = _personService.GetById(studentId);
			string phoneNumber= personToGetSms.PhoneNumber;
			_smsService.Send(phoneNumber, Messages.AttendanceInformation);
		}


	}
}
