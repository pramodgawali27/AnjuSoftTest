using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAPP.Models
{
    [Serializable]
    public class UserViewModel
    {
        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
    }
}