using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Required]
        public string Naam { get; set; }

        public string Afbeelding { get; set; }
        
    }
}