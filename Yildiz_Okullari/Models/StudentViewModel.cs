using Entities;

namespace UI.Models
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Grade { get; set; }
        public string Branch { get; set; }
        public Term ?Term { get; set; }
        public List<Attendance> ?Attendances { get; set; }
    }
}
