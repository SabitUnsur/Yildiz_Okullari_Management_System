﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person:IdentityUser<Guid>
    {
        public string ?Name { get; set; }
        public string ?Surname { get; set; }
        public int? StudentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender ?Gender { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public Guid ?TermId { get; set; }
        public Term ?Term { get; set; }
        public  int? Grade { get; set; }
        public string? Branch { get; set; }
        public Guid ?FamilyInfoId {  get; set; }
        public FamilyInfo ?FamilyInfo { get; set; }



    }
}
