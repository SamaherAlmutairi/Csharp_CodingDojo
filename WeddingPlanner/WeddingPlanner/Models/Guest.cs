using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        [Key]
        // LikeId
        public int GuestId { get; set; }
        // bring in Foreign Keys for both User and Movies
        public int UserId { get; set; }
        // Fan
        public User Invited { get; set; }
// WeddingId
        public int WeddingId { get; set; }
// FanOf
        public Wedding InvitedTo { get; set; }
    }
}