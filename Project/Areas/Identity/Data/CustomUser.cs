using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData, MaxLength(50,ErrorMessage ="De ingevulde naam is te lang. De maximale lengte is 50"),Required]
        
        public string Naam { get; set; }
        [PersonalData, Required]
        public string Voornaam { get; set; }
        [PersonalData]
        public string Straat { get; set; }
        [PersonalData]
        public int Huisnummer { get; set; }
        [PersonalData]
        public string Postocde { get; set; }
        [PersonalData]
        public string Gemeente { get; set; }
        [PersonalData, DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }


    }
}
