using HuellitasIdentity.Models;
using HuellitasIdentity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HuellitasIdentity.Pages
{
    public class PetModel : PageModel
    {
        public List<Pet> pets = new();

        [BindProperty]
        public Pet NewPet { get; set; } = new();

        public void OnGet()
        {
            pets = PetService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PetService.Add(NewPet);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
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
