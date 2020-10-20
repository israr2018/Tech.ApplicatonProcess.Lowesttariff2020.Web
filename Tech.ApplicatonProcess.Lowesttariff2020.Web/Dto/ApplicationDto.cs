using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web.Dto
{
    public class ApplicationDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5, ErrorMessage = "The Name should be atleast 5 charactors ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FamilyName is required.")]
        [MinLength(5, ErrorMessage = "The FamilyName should be atleast 10 charactors ")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MinLength(5, ErrorMessage = "The Address should be atleast 10 charactors ")]
        public string Address { get; set; }

        public string CountryOfOrigin { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }



        [Required(ErrorMessage = "The Age  is required")]
        [Range(20, 60, ErrorMessage = "Age must be between 20 and 60")]
        public int Age { get; set; }


        [Required(ErrorMessage = "The Hired  is required")]

        public Boolean Hired { get; set; }


    }
}
