using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public int InVoorraad { get; set; }
        [Required]
        public string Type { get; set; }

        [Required]
        public int CategorieId { get; set; }

        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public string Rating { get; set; }

        [Required]
        public string Afbeelding { get; set; }
        [Required]
        public Decimal Prijs { get; set; }
        public Categorie Categorie { get; set; }
        

    }
}