using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FamilyInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string ?FatherFullName { get; set; }
        public string ?MotherFullName { get; set; }
        public string ?FatherPhoneNumber { get; set; }
        public string ?MotherPhoneNumber { get; set; }
        public virtual ICollection<Person> ?Persons { get; set; }
    }
}
