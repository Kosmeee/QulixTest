using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Qulix.Test.Company.Domain.Models;

namespace Qulix.Test.Company.Presentation.Models
{
    public class EmployeeView
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

        public Domain.Models.Company Company { get; set; }

        public List<Position> SelectPositions { get; set; }

        public List<Domain.Models.Company> SelectCompanies { get; set; }
    }
}
