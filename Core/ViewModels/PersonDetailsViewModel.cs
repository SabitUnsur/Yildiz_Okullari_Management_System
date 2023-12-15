using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class PersonDetailsViewModel
    {
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

        public PersonDetailsViewModel(Guid id, string? name, string? surname, int studentNumber, int grade, string? branch, string? email, string? phoneNumber, string? motherNumber, string? fatherNumber, string? motherFullName, string? fatherFullName)
        {
            Id = id;
            Name = name;
            Surname = surname;
            StudentNumber = studentNumber;
            Grade = grade;
            Branch = branch;
            Email = email;
            PhoneNumber = phoneNumber;
            MotherNumber = motherNumber;
            FatherNumber = fatherNumber;
            MotherFullName = motherFullName;
            FatherFullName = fatherFullName;
        }
        public PersonDetailsViewModel()
        {
            
        }
        public static  PersonDetailsViewModel personToPersonDetailsViewModel(Person person)
        {
            return new PersonDetailsViewModel
            {
                Id=person.Id,
                Name=person.Name,
                Surname=person.Surname,
                StudentNumber=person.StudentNumber,
                Grade=person.Grade,
                Branch=person.Branch,
                Email=person.Email,
                PhoneNumber=person.PhoneNumber,
                MotherNumber=person.FamilyInfo?.MotherPhoneNumber,
                FatherNumber=person.FamilyInfo?.FatherPhoneNumber,
                MotherFullName=person.FamilyInfo?.MotherFullName,
                FatherFullName=person.FamilyInfo?.FatherFullName
            };
        }
    }
}
