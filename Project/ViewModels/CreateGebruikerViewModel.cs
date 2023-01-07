using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class CreateGebruikerViewModel
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]

        public DateTime Geboortedatum { get; set; } 
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public SelectList Rollen { get; set; }
        public string RolId { get; set; }
    }
}
