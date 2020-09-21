using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Pet CreatePet(Pet pet)
        {
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

            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> OrderByPrice()
        {
            return _petRepository.OrderByPrice().ToList();
        }

        public Pet RemovePet(int petID)
        {
            return _petRepository.deletePet(petID);
        }

        public Pet UpdatePet(Pet UpdatePet)
        {
            var pett = ReadyById(UpdatePet.Id);
            //if (pett == null) return null;

            pett.Name = UpdatePet.Name;
            pett.Type = UpdatePet.Type;
            pett.BirthDate = UpdatePet.BirthDate;
            pett.SoldDate = UpdatePet.SoldDate;
            pett.Color = UpdatePet.Color;
            pett.PreviousOwner = UpdatePet.PreviousOwner;
            pett.Price = UpdatePet.Price;


            return pett;
           // return _petRepository.UpdatePet(UpdatePet);
        }

        public Pet ReadyById(int id)
        {
            return _petRepository.ReadyById(id);
        }

        public List<Pet> GetPetByProp(string prop, string val)
        {
            IEnumerable<Pet> searchList;
            var ListOfPets = _petRepository.ReadPets();
            searchList = ListOfPets.Where(pet => pet.Color.ToLower().Contains(val));
            return searchList.ToList();

        }
    }
}
