using Business.Abstract;
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

		public ScheduledTaskService(Timer timer)
		{
			_timer = timer;
		}

		public void StartScheduledTask()
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

			//timer = new Timer(x => SendDailyAttendanceSmsViaTwilio(), null, timeToGo, TimeSpan.FromHours(24));

		}

		public void StopScheduledTask()
		{
			// Zamanlanmış görevi durdur
			_timer?.Dispose();
		}
	}
}
