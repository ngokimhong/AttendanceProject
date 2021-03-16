using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("attendance")]
    public class Attendance
    {
        [Key]

        public Guid AttendanceId { get; set; }

        [Required(ErrorMessage = "CheckIn is required")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "CheckOut is required")]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(20, ErrorMessage = "Status can't be longer than 20")]
        public string Status { get; set; }

        [ForeignKey(nameof(WorkShift))]
        public Guid WorkShiftId { get; set; }
        public WorkShift WorkShift { get; set; }

    }
}
