using System.ComponentModel.DataAnnotations;

namespace Qulix.Test.Company.Domain.Models
{
   public class Position
    {
        [Range(1, 4)]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
