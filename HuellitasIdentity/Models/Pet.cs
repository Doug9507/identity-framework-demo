using System.ComponentModel.DataAnnotations;

namespace HuellitasIdentity.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pet name is required")]
        [Display(Name = "Pet name")]
        public string? Name { get; set; }
        public PetSize Size { get; set; }
        public bool IsPedigree { get; set; }
    }

    public enum PetSize { Small, Medium, Large }
}
