using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class EditGebruikerViewModel
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]

        public DateTime Geboortedatum { get; set; }
        [Required]
        public string Email { get; set; }

        public string GebruikerId { get; set; }


    }
}
