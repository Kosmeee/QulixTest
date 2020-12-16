using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qulix.Test.Company.Domain.Models
{
    

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "max length 50")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "max length 50")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "max length 50")]
        public string Patronymic { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EmploymentDate { get; set; }

        public Position Position { get; set; }

        public Company Company { get; set; }
    }
}
