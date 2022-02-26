using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebValidation.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name ="Employee Name")]
        [Required(ErrorMessage ="Please Enter Employee Name")]
        public string Name { get; set; }

        [Display(Name ="Employee Email")]
        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress(ErrorMessage ="Email Address is not valid")]
        public string Email { get; set; }

        [Display(Name = "Employee Contact")]
        [Required(ErrorMessage = "Please Enter Contact Number")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
            ErrorMessage ="Invalid Mobile Number")]
        public string Contact { get; set; }

        [Display(Name="Employee Address")]
        [Required(ErrorMessage ="Please Enter Your Address")]
        public string Address { get; set; }

    }
}
