using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Departuredate { get; set; }
        [Required]
        [Range(7,21)]
        public int Duration { get; set; }

        //Propriété de navigation 1 à plusieurs, côté 1
        public Destination? Destination { get; set; }

        //Propriété de navigation 1 à plusieurs, côté 1
        public Guide? Guide { get; set; }

        //Propriété de navigation 0 ou 1 à 1
        public TravelRecommendation? TravelRecommendation { get; set; }
    }
}
