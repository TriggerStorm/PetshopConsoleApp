using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
            if (FakeDB.pets.Count >= 1) return;
            else
            {
                FakeDB.InitData();
            }
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.pets;
        }

        public Pet AddPet(Pet pet)
        {
            pet.Id = FakeDB.id++;
            FakeDB.pets.Add(pet);
            return pet;
            
        }

        public void deletePet(int PetID)
        {
            foreach (var pet in FakeDB.pets)
            {
                if (FakeDB.id == pet.Id)
                {
                    FakeDB.pets.Remove(pet);
                    break;
                }
            }
        }

        public Pet ReadyById(int id)
        {
            return FakeDB.pets.
                Select(p => new Pet()
                { 
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    BirthDate = p.BirthDate,
                    SoldDate = p.SoldDate,
                    Color = p.Color,
                    PreviousOwner = p.PreviousOwner,
                    Price = p.Price
                }).
                FirstOrDefault(p => p.Id == id);

        }
        public Pet UpdatePet(Pet updatePet)
        {
            var petFromDB = ReadyById(updatePet.Id);
            if (petFromDB == null) return null;

            petFromDB.Name = updatePet.Name;
            petFromDB.Type = updatePet.Type;
            petFromDB.BirthDate = updatePet.BirthDate;
            petFromDB.SoldDate = updatePet.SoldDate;
            petFromDB.Color = updatePet.Color;
            petFromDB.PreviousOwner = updatePet.PreviousOwner;
            petFromDB.Price = updatePet.Price;

            return petFromDB;
        }

        public IEnumerable<Pet> GetOneTypeOfPets(string type)
        {
            var _typePets = new List<Pet>();
            foreach (var pet in FakeDB.pets)
            {
                if (type == pet.Type)
                {
                    _typePets.Add(pet);
                }

            }
            return _typePets;
            
        }

        public IEnumerable<Pet> OrderByPrice()
        {
            List < Pet > sortetPrice = FakeDB.pets.OrderBy(Pet => Pet.Price).ToList();
            return sortetPrice;
        }
    }
}
