using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string? Address { get; set; }
    }
}