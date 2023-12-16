using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public  class PersonUpdateViewModel
    {
        public PersonUpdateViewModel(Guid ıd, string? name, string? surname, int studentNumber, int? grade, string? branch, string? email, string? phoneNumber, string? motherNumber, string? fatherNumber, string? motherFullName, string? fatherFullName)
        {
            Id=ıd;
            Name=name;
            Surname=surname;
            StudentNumber=studentNumber;
            Grade= (int)grade;
            Branch=branch;
            Email=email;
            PhoneNumber=phoneNumber;
            MotherNumber=motherNumber;
            FatherNumber=fatherNumber;
            MotherFullName=motherFullName;
            FatherFullName=fatherFullName;
        }
        public PersonUpdateViewModel()
        {
            
        }
        public static PersonUpdateViewModel personToPersonDetailsViewModel(Person person)
        {
            return new PersonUpdateViewModel
            {
                Id=person.Id,
                Name=person.Name,
                Surname=person.Surname,
                StudentNumber= (int)person.StudentNumber,
                Grade= (int)person.Grade,
                Branch=person.Branch,
                Email=person.Email,
                PhoneNumber=person.PhoneNumber,
                MotherNumber=person.FamilyInfo!.MotherPhoneNumber,
                FatherNumber=person.FamilyInfo.FatherPhoneNumber,
                MotherFullName=person.FamilyInfo.MotherFullName,
                FatherFullName=person.FamilyInfo.FatherFullName
            };
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int StudentNumber { get; set; }
        public int Grade { get; set; }
        public string? Branch { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MotherNumber { get; set; }
        public string? FatherNumber { get; set; }
        public string? MotherFullName { get; set; }
        public string? FatherFullName { get; set; }

    }
}
