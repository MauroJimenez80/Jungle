using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Guide
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)]
        public string Speciality { get; set; } = String.Empty;

        //Propriété de navigation 1 à plusieurs, côté plusieurs
        public ICollection<Travel> Travels { get; set; } = new List<Travel>();
    }
}
