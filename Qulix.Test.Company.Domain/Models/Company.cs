using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qulix.Test.Company.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="max length 50")]
        public string Title { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "max length 10")]
        public string OrganisationalForm { get; set; }

        public int Size { get; set; } // TODO remove this and make presentation model with this property
    }
}
