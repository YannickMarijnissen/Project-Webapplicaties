using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Klant
    {
        [Key]
       public int Klantid { get; set; }
       public string Naam { get; set; }
       public string Voornaam { get; set; }
       public string Straat { get; set; }
       public int Huisnummer { get; set; }
       public string Gemeente { get; set; }
       public int Postcode { get; set; }
       public string Btwnummer { get; set; }
       public string Telefoonnummer { get; set; }
       public string Emailadres { get; set; }
       public string Wachtwoord { get; set; }
    }
}
