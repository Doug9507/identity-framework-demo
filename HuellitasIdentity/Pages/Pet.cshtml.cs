using HuellitasIdentity.Models;
using HuellitasIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HuellitasIdentity.Pages
{
    [Authorize]
    public class PetModel : PageModel
    {
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);
        public List<Pet> pets = new();

        [BindProperty]
        public Pet NewPet { get; set; } = new();

        public void OnGet()
        {
            pets = PetService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!IsAdmin) return Forbid();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            PetService.Add(NewPet);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            if (!IsAdmin) return Forbid();
            PetService.Delete(id);
            return RedirectToAction("Get");
        }

        public string PedigreeText(Pet pet)
        {
            if (pet.IsPedigree)
                return "Is pedigree";
            return "Not pedegree";
        }
    }
}
