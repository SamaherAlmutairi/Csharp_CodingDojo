using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{

    public class Survey
  {
    [Required]
    [Display(Name="Name:")]
    [MinLength(2, ErrorMessage="Name should be more than 2 characters")]
    public string Name { get; set; }

    [Required]
    [Display(Name="Locations:")]
    public string Locations { get; set; }

    [Required]
    public string Languages { get; set; }

    [Required]
    [MinLength(21, ErrorMessage="Comment must be more than 20 characters!")]
    public string Comments { get; set; }
  }
  }
