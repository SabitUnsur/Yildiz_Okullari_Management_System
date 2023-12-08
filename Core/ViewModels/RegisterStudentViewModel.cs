using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class RegisterStudentViewModel
    {
        public RegisterStudentViewModel()
        {

        }

        public RegisterStudentViewModel(string? name, string? surname, string? username, string? email, string? password, string? passwordConfirm, string? phoneNumber, DateTime birthDate, Gender gender, int studentNumber)
        {
            Name=name;
            Surname=surname;
            Username=username;
            Email=email;
            Password=password;
            PasswordConfirm=passwordConfirm;
            PhoneNumber=phoneNumber;
            BirthDate=birthDate;
            Gender=gender;
            StudentNumber=studentNumber;
        }

        public string ?Name { get; set; }
        public string ?Surname { get; set; }
        public string ?Username { get; set; }
        public string ?Email { get; set; }
        public string ?Password { get; set; }
        public string ?PasswordConfirm { get; set; }
        public string ?PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender  Gender { get; set; }
        public int StudentNumber { get; set; }
    }
}
