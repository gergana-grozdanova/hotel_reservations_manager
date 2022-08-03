using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationsManager.Data.Entities
{
    public class ApplicationUser:IdentityUser<string>
    {
        [Key]
      //  public string  Id { get; set; }
       //public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Egn { get; set; }
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
       // public string? Email { get; set; }
        public DateTime? HiredDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DismissalDate { get; set; }

        public ApplicationUser()
        {
            this.Id=Guid.NewGuid().ToString();
        }
    }
}
