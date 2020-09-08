using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AppService
{
    public interface IPetService
    {
        public List<Pet> GetPets();

        public Pet CreatePet(String name, String type, DateTime birthDate, DateTime soldDate, String color, String previousOwner, double price);
        public void RemovePet(int petID);
        public void UpdatePet(int petId, string name, string type, DateTime birthDate, DateTime soldDate, string color, string privousOwner, double price);
        public List<Pet> GetOneTypeOfPets(String type);
        public List<Pet> OrderByPrice();
        public List<Pet> FiveCheepest();

    }
}
