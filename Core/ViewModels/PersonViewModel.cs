using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(Guid ıd, string? name, string? surname, int studentNumber, int grade, string? branch)
        {
            Id=ıd;
            Name=name;
            Surname=surname;
            StudentNumber=studentNumber;
            Grade=grade;
            Branch=branch;
        }
        public PersonViewModel()
        {
            
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string?  Surname { get; set; }
        public int?  StudentNumber { get; set; }
        public int? Grade { get; set; }
        public string? Branch { get; set; }

        public PersonViewModel personToPersonViewModel(Person person)
        {
            return new PersonViewModel
            {
                Id=person.Id,
                Name=person.Name,
                Surname=person.Surname,
                StudentNumber=person.StudentNumber,
                Grade=person.Grade,
                Branch=person.Branch
            };
        }
    }
}
