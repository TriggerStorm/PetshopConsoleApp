using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AppService.Service
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public Pet CreatePet(String name, String type, DateTime birthDate, DateTime soldDate, String color, String previousOwner, double price)
        {
            var pet = new Pet
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return _petRepository.AddPet(pet);
        }

        public List<Pet> FiveCheepest()
        {
            
            var pricelist = (List<Pet>)_petRepository.OrderByPrice();
            while (pricelist.Count > 5)
                pricelist.RemoveAt(pricelist.Count - 1);
            return pricelist;
        }

        public List<Pet> GetOneTypeOfPets(string type)
        {
            return (List<Pet>)_petRepository.GetOneTypeOfPets(type);
        }

        public List<Pet> GetPets()
        {
            
            return (List<Pet>)_petRepository.ReadPets();
        }

        public List<Pet> OrderByPrice()
        {
            return (List<Pet>)_petRepository.OrderByPrice();
        }

        public void RemovePet(int petID)
        {
            _petRepository.deletePet(petID);
        }

        public void UpdatePet(int petId, string name, string type, DateTime birthDate, DateTime soldDate, string color, string privousOwner, double price)
        {
            _petRepository.UpdatePet(petId, name, type, birthDate, soldDate, color, privousOwner, price);
        }
    }
}
