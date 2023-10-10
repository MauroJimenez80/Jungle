using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        //Propriété de navigation 1 à plusieurs, côté plusieurs
        public ICollection<Destination> Destinations { get; set; } = new List<Destination>();
    }
}
