using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int ReaderId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal OverdueCharge { get; set; }
    }
}