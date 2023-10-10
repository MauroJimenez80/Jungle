using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Region { get; set; } = string.Empty;

        //Propriété de navigation 1 à plusieurs, côté 1
        public Country? Country { get; set; }

        //Propriété de navigation 1 à plusieurs, côté plusieurs
        public ICollection<Travel>? Travels { get; set; }
    }
}
