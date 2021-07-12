using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        [Required]
        public int WeddingId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string Onew { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        [Display(Name = "Twow")]
        public string Twow { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        [Display(Name = "Address URL")]
        public string Address  { get; set; }
        [Required]
        [Display(Name = " Date")]
        [DataType(DataType.Date)]
        public DateTime WDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
                // Foreign Key for UserId has to match the property name in User class
        public int UserId { get; set; }
        // PostedBy
        public User Planner { get; set; }
        // Fans
        public List<Guest> Visitors { get; set; }
    }
}