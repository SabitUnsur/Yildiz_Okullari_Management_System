using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.Helpers.EnumHelper
{
    public static class LectureHelper
    {
        public static string GetFormattedLecture(LectureHours lecture)
        {
            switch (lecture)
            {
                case LectureHours.Lecture1:
                    return "1. Ders";
                case LectureHours.Lecture2:
                    return "2. Ders";
                case LectureHours.Lecture3:
                    return "3. Ders";
                case LectureHours.Lecture4:
                    return "4. Ders";
                case LectureHours.Lecture5:
                    return "5. Ders";
                case LectureHours.Lecture6:
                    return "6. Ders";
                case LectureHours.Lecture7:
                    return "7. Ders";
                case LectureHours.Lecture8:
                    return "8. Ders";
                default:
                    return "Bilinmeyen Ders";
            }
        }
    }
}
