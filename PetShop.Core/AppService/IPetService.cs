using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AppService
{
    public interface IPetService
    {
        public List<Pet> GetPets();

        public Pet CreatePet(Pet pet);
        //public Pet CreatePet(String name, String type, DateTime birthDate, DateTime soldDate, String color, String previousOwner, double price);
        public Pet RemovePet(int petID);
        public Pet UpdatePet(Pet UpdatePet);
        public List<Pet> GetOneTypeOfPets(string type);
        public List<Pet> GetPetByProp(string prop, string val);
        public List<Pet> OrderByPrice();
        public List<Pet> FiveCheepest();
        public Pet ReadyById(int id);
    }
}
