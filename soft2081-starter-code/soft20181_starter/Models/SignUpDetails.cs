using System;
using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Models
{
    public class SignUpDetails
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
