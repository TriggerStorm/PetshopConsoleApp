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
        public Pet deletePet(int PetID);
        public Pet UpdatePet(Pet updatePet);
        public IEnumerable<Pet> GetOneTypeOfPets(String type);
        public IEnumerable<Pet> OrderByPrice();
        public Pet ReadyById(int id);
    }
}
