using Business.Abstract;
using Core.ViewModels;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RegisterService(UserManager<Person> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager=roleManager;
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> RegisterAdminAsync(RegisterAdminViewModel request)
        {
            var result = await _userManager.CreateAsync(new Person() { UserName=request.Username, Email=request.Email, Name=request.Name, Surname=request.Surname, PhoneNumber=request.PhoneNumber,},request.Password!);
            
            if(!result.Succeeded)
            {
                return (false,result.Errors);
            }
            else
            {
                var user=await _userManager.FindByNameAsync(request.Username!);
                await _userManager.AddToRoleAsync(user!, "admin");
                return (true, null);
            }
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> RegisterStudentAsync(RegisterStudentViewModel request)
        {
            var result= await _userManager.CreateAsync(new Person() { UserName=request.Username,Email=request.Email,PhoneNumber=request.PhoneNumber,Name=request.Name,Surname=request.Surname,
            Grade = request.Grade, Branch = request.Branch,StudentNumber = request.StudentNumber,BirthDate=request.BirthDate,Gender=request.Gender
            ,FamilyInfo=new FamilyInfo { FatherFullName=request.FatherFullName,MotherFullName=request.MotherFullName,FatherPhoneNumber=request.FatherPhoneNumber,MotherPhoneNumber=request.MotherPhoneNumber}
            }
            ,request.Password!);

            if (!result.Succeeded)
            {
                return (false,result.Errors);
            }
            else
            {
                var user=await _userManager.FindByNameAsync(request.Username!);
                await _userManager.AddToRoleAsync(user!, "student");
                return (true, null);
            }
        }
        public SelectList GetGenderSelectList()
        {
            return new SelectList(Enum.GetNames(typeof(Gender)));
        }
    }
}
