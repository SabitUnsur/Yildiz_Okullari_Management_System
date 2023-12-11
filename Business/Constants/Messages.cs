using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public static class Messages
	{
        public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string AttendanceNotFound = "Devamsızlık bilgisi bulunamadı";
		public static string AttendanceInformation = "devamsızlık yapmıştır";
		public static string SmsSendingFailed= "SMS gönderilemedi";
	}
}
