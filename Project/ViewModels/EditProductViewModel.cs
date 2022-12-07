using System;

namespace Project.ViewModels
{
    public class EditProductViewModel
    {
        public int ProductId { get; set; }


        public string Naam { get; set; }


        public int InVoorraad { get; set; }

        public string Type { get; set; }


        public int CategorieId { get; set; }


        public string Beschrijving { get; set; }

        public string Rating { get; set; }


        public string Afbeelding { get; set; }

        public Decimal Prijs { get; set; }
    }
}