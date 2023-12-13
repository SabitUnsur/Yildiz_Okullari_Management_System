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

        public RegisterStudentViewModel(string? name, string? surname, string? username, string? email, string? password, string? passwordConfirm, string? phoneNumber, DateTime birthDate, Gender gender, int studentNumber, string branch, int grade, string fatherFullName, string motherFullName, string fatherPhoneNumber, string motherPhoneNumber)
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
            Branch=branch;
            Grade=grade;
            FatherFullName=fatherFullName;
            MotherFullName=motherFullName;
            FatherPhoneNumber=fatherPhoneNumber;
            MotherPhoneNumber=motherPhoneNumber;
        }

        [Display(Name="İsim")]
        [Required(ErrorMessage="Lütfen isim giriniz.")]
        public string ?Name { get; set; }
        [Required(ErrorMessage="Lütfen soyisim giriniz.")]
        [Display(Name="Soyisim")]
        public string ?Surname { get; set; }
        [Required(ErrorMessage="Lütfen kullanıcı adı giriniz.")]
        [Display(Name="Kullanıcı Adı")]
        public string ?Username { get; set; }
        [Required(ErrorMessage="Lütfen email giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string ?Email { get; set; }
        [Required(ErrorMessage="Lütfen şifre giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name="Şifre")]
        public string ?Password { get; set; }
        [Required(ErrorMessage="Lütfen şifre giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name="Şifre Tekrar")]
        public string ?PasswordConfirm { get; set; }
        [Required(ErrorMessage="Lütfen telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Telefon Numarası")]
        public string ?PhoneNumber { get; set; }
        [Required(ErrorMessage="Lütfen doğum tarihi seçiniz.")]
        [DataType(DataType.Date)]
        [Display(Name="Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage="Lütfen cinsiyet seçiniz.")]
        [Display(Name="Cinsiyet")]
        public Gender  Gender { get; set; }
        [Required(ErrorMessage="Lütfen öğrenci numarası giriniz.")]
        [Display(Name="Öğrenci Numarası")]
        public int StudentNumber { get; set; }
        [Required(ErrorMessage="Lütfen şube seçiniz.")]
        [Display(Name="Şube")]
        public required string Branch { get; set; }
        [Required(ErrorMessage="Lütfen sınıf seçiniz.")]
        [Display(Name="Sınıf")]
        public required int Grade { get; set; }
        [Required(ErrorMessage ="Lütfen baba adı giriniz.")]
        [Display(Name="Baba Ad-Soyad")]
        public string FatherFullName { get; set; }
        [Required(ErrorMessage ="Lütfen anne adı giriniz.")]
        [Display(Name="Anne Ad-Soyad")]
        public string MotherFullName { get; set; }
        [Required(ErrorMessage ="Lütfen baba telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Baba Telefon Numarası")]
        public string FatherPhoneNumber { get; set; }
        [Required(ErrorMessage ="Lütfen anne telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Anne Telefon Numarası")]
        public string MotherPhoneNumber { get; set; }

    }
}
