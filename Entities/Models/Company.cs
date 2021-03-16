using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        public Guid BranchId { get; set; }

        [Required(ErrorMessage = "Branch name is required")]
        [MaxLength(100, ErrorMessage = "Branch name can't be longer than 100 characters")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(255, ErrorMessage = "Address can't be longer than 255 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
