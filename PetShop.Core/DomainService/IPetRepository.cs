using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        
        public IEnumerable<Pet> ReadPets();

        public Pet AddPet(Pet pet);
        public void deletePet(int PetID);
        public void UpdatePet(int petId, string name, string type, DateTime birthDate, DateTime soldDate, string color, string privousOwner, double price);
        public IEnumerable<Pet> GetOneTypeOfPets(String type);
        public IEnumerable<Pet> OrderByPrice();
    }
}
