using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20, ErrorMessage = "Username can't be longer than 20 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [MaxLength(100, ErrorMessage = "Fullname can't be longer than 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(100, ErrorMessage = "Address can't be longer than 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [MaxLength(20, ErrorMessage = "Role can't be longer than 20 characters")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Email can't longer than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Sex is required")]
        [MaxLength(10, ErrorMessage = "Sex can't longer than 10 characters")]
        public string Sex { get; set; }

        //[Required(ErrorMessage = "Shift id is required")]
        //[MaxLength(20, ErrorMessage = "Shift id can't longer than 20 characters")]
        //public string ShiftId { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid BranchId { get; set; }

        public Company Company { get; set; }

        public ICollection<WorkShift> WorkShifts { get; set; }

    }
}
