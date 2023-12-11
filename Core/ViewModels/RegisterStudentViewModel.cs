using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public RegisterStudentViewModel(string? name, string? surname, string? username, string? email, int grade, string branch,string? password, string? passwordConfirm, string? phoneNumber, DateTime birthDate, Gender gender, int studentNumber)
        {
            Name=name;
            Surname=surname;
            Username=username;
            Email=email;
            Grade = grade;
            Branch = branch; 
            Password=password;
            PasswordConfirm=passwordConfirm;
            PhoneNumber=phoneNumber;
            BirthDate=birthDate;
            Gender=gender;
            StudentNumber=studentNumber;
        }
        [Display(Name="İsim")]
        public string ?Name { get; set; }
        [Display(Name="Soyisim")]
        public string ?Surname { get; set; }
        [Display(Name="Kullanıcı Adı")]
        public string ?Username { get; set; }
        [Display(Name="Email")]
        public string ?Email { get; set; }
        [Display(Name="Şifre")]
        public string ?Password { get; set; }
        [Display(Name="Şifre Tekrar")]
        public string ?PasswordConfirm { get; set; }
        [Display(Name="Telefon Numarası")]
        public string ?PhoneNumber { get; set; }
        [Display(Name="Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Display(Name="Cinsiyet")]
        public Gender  Gender { get; set; }
        [Display(Name="Öğrenci Numarası")]
        public int StudentNumber { get; set; }
        public required string Branch { get; set; }
        public required int Grade { get; set; }
    }
}
