using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [PersonalData, MaxLength(50, ErrorMessage = "De ingevulde naam is te lang. De maximale lengte is 50"), Required]

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

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var Naam = await Task.FromResult(user.Naam);
            var Voornaam = await Task.FromResult(user.Voornaam);
            var Straat = await Task.FromResult(user.Straat);
            var Huisnummer = await Task.FromResult(user.Huisnummer);
            var Postcode = await Task.FromResult(user.Postocde);
            var Gemeente = await Task.FromResult(user.Gemeente);
            var Geboortedatum = await Task.FromResult(user.Geboortedatum);
            var datum = new DateTime(1970, 1, 1);
            int res = DateTime.Compare(Geboortedatum, datum);

            if (res < 0)
            { Geboortedatum = datum; }


            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Naam = Naam,
                Voornaam = Voornaam,
                Straat = Straat,
                Huisnummer = Huisnummer,
                Postocde = Postcode,
                Gemeente = Gemeente,
                Geboortedatum = Geboortedatum
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            user.Naam = Input.Naam;
            user.Voornaam = Input.Voornaam;
            user.Straat = Input.Straat;
            user.Huisnummer = Input.Huisnummer;
            user.Postocde = Input.Postocde;
            user.Gemeente = Input.Gemeente;
            user.Geboortedatum = Input.Geboortedatum;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
