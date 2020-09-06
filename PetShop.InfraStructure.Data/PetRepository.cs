using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository : IPetRepository
    {
        

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.GetAllPets();
        }

        public Pet AddPet(Pet pet)
        {
            return FakeDB.AddPet(pet);
        }

        public void deletePet(int PetID)
        {
            FakeDB.deletePet(PetID);
        }

        public void UpdatePet(int petId, string name, string type, DateTime birthDate, DateTime soldDate, string color, string privousOwner, double price)
        {
            FakeDB.UpdatePet(petId, name, type, birthDate, soldDate, color, privousOwner, price);
        }

        public IEnumerable<Pet> GetOneTypeOfPets(string type)
        {
            return FakeDB.GetOneTypeOfPets(type);
        }

        public IEnumerable<Pet> OrderByPrice()
        {
            return FakeDB.OrderByPrice();
        }
    }
}
