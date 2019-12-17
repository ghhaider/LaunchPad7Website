using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Launchpad7New.Areas.Admin.Models
{
    public class UserViewModel
    {
        
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Profession { get; set; }
        [Required]
        [DisplayName("Select Package")]
        public int PackageId { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public string Website { get; set; }
        [Required]
        [DisplayName("Team Members")]
        [DataType(DataType.Text)]
        public int Members { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        [DisplayName("When you Start your package subscription")]
        public DateTime StartingDate { get; set; }
        public bool Food { get; set; }
        public string HowYouKnow { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}