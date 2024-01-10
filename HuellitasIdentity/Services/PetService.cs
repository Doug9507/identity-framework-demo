using HuellitasIdentity.Models;

namespace HuellitasIdentity.Services
{
    public static class PetService
    {
        static List<Pet> Pets { get; }
        static int nextId = 3;
        static PetService()
        {
            Pets = new List<Pet>
                {
                    new Pet { Id = 1, Name = "Gato Persa", Size=PetSize.Large, IsPedigree = true },
                    new Pet { Id = 2, Name = "Perro pitbull", Size=PetSize.Small, IsPedigree = true }
                };
        }

        public static List<Pet> GetAll() => Pets;

        public static Pet? Get(int id) => Pets.FirstOrDefault(p => p.Id == id);

        public static void Add(Pet pet)
        {
            pet.Id = nextId++;
            Pets.Add(pet);
        }

        public static void Delete(int id)
        {
            var pet = Get(id);
            if (pet is null)
                return;

            Pets.Remove(pet);
        }

        public static void Update(Pet pet)
        {
            var index = Pets.FindIndex(p => p.Id == pet.Id);
            if (index == -1)
                return;

            Pets[index] = pet;
        }
    }
}
