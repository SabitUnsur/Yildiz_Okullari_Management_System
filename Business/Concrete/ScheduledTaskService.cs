using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace Business.Concrete
{
    public class ScheduledTaskService : IScheduledTaskService
    {
        private readonly ITimer _timer;
        private readonly IPersonService _personService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ISmsService _smsService;

        public ScheduledTaskService(ITimer timer, IPersonService personService, ISmsService smsService, IServiceScopeFactory serviceScopeFactory)
        {
            _timer = timer;
            _personService = personService;
            _smsService = smsService;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task ScheduleSms(Guid studentId)
        {
            var now = DateTime.Now;
            var targetTime = new DateTime(now.Year, now.Month, now.Day, 11, 57,20 );

            if (now > targetTime)
            {
                targetTime = targetTime.AddDays(1);
            }

            var delay = targetTime - now;

            await Task.Delay(delay);

            // Örnek bir TimerCallback oluşturun
            Action<object> callback = x => SendDailyAttendanceSmsViaTwilio(studentId);

                // TimerWrapper'ı kullanarak TimerCallback'i başlatın
                _timer.Start(callback, null, delay, TimeSpan.FromDays(1));
                //await Task.Delay(TimeSpan.FromDays(1));
        }

        private void SendDailyAttendanceSmsViaTwilio(Guid studentId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var personService = scope.ServiceProvider.GetRequiredService<IPersonService>();
                var personToGetSms = personService.GetPersonWithFamilyInfoById(personService.GetById(studentId).Id);
                
                string phoneNumber;

                if (personToGetSms.FamilyInfoId != null)
                {

                    phoneNumber = personToGetSms.FamilyInfo.FatherPhoneNumber;
                }
                else
                {
                    phoneNumber = personToGetSms.FamilyInfo.MotherPhoneNumber;
                }

                var attendanceDate = _personService.GetTodaysAbsenceDateForStudent(studentId);
  
                try
                {
                    _smsService.Send(phoneNumber, $"{personToGetSms.Name + " " 
                        + personToGetSms.Surname + " "
                        + "öğrencimiz" + " "
                        + $"{attendanceDate.Value.ToShortDateString()}" + " "
                        + "tarihinde" + " " }" 
                        + Messages.AttendanceInformation);

                    _timer.Stop();
                }
                catch (SmsSendFailedException ex)
                {
                    throw new SmsSendFailedException(ex.Message);
                }
            }
        }

    }
}
