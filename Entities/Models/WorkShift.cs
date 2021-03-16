using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("workShift")]
    public class WorkShift
    {
        [Key]
        public Guid ShiftId { get; set; }

        [Required(ErrorMessage = "Attendance id is required")]
        [MaxLength(50, ErrorMessage = "Attendance id can't be longer than 50 characters")]
        public string AttendanceId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public int Date { get; set; }

        [Required(ErrorMessage = "Month is required")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Period is required")]
        [MaxLength(20, ErrorMessage = "Period can't be longer than 20 characters")]
        public string Period { get; set; }

        [Required(ErrorMessage = "SumHourPerDay is required")]
        public int SumHourPerDay { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
