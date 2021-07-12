using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
  public class User
  {
   [Required]
      [Display(Name="First Name:")]
      [MinLength(2, ErrorMessage="First Name must be at least 2 characters")]
      public string FirstName { get; set; }

      [Required]
      [Display(Name="Last Name:")]
      [MinLength(2, ErrorMessage="Last Name must be at least 2 characters")]
      public string LastName { get; set; }

      [Required]
      [Display(Name="Age:")]
      [Range(0, 100, ErrorMessage="Your age Wrong")]
      public int Age { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
    }
}