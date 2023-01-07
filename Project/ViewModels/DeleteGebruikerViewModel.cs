using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Project.ViewModels
{
    public class DeleteGebruikerViewModel
    {
        public string GebruikerId { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }

    }
}
