using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class TravelRecommendation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string DangerLevel { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public Type? Attribut { get; set; }
    }
}
