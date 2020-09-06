using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public static class FakeDB
    {
        private static int _id = 1;
        private static List<Pet> _pets = new List<Pet>();
        public static IEnumerable<Pet> GetAllPets()
        {
            return _pets;
        }
        public static IEnumerable<Pet> OrderByPrice()
        {
            List<Pet> sortetPrice = _pets.OrderBy(Pet => Pet.Price).ToList();
            return sortetPrice;
        }
        public static IEnumerable<Pet> GetOneTypeOfPets(string type)
        {
           var _typePets = new List<Pet>();
            foreach (var pet in _pets)
            {
                if (type == pet.Type)
                {
                    _typePets.Add(pet);
                }
                
            }
            return _typePets;
        }

        public static Pet AddPet(Pet pet)
        {
            pet.Id = _id++;
            _pets.Add(pet);
            return pet;
        }

        public static void InitData()
        {
            _pets = new List<Pet>() {

                new Pet
                {
                    Id = _id++,
                    Name = "Jimmy",
                    Type = "Doggo",
                    BirthDate = DateTime.Now.AddDays(-350),
                    SoldDate = DateTime.Now.AddDays(-1),
                    Color = "black",
                    PreviousOwner = "non",
                    Price = 200.50



                },

                new Pet
                 {
                Id = _id++,
                Name = "Felix",
                Type = "Catt",
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                PreviousOwner = "non",
                Price = 150
                },
                
                new Pet
                 {
                Id = _id++,
                Name = "Felixy",
                Type = "Catt",
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                PreviousOwner = "non",
                Price = 1500
                },
                new Pet
                 {
                Id = _id++,
                Name = "Fel",
                Type = "Catt",
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                PreviousOwner = "non",
                Price = 120
                },
                new Pet
                 {
                Id = _id++,
                Name = "Fexy",
                Type = "Catt",
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                PreviousOwner = "non",
                Price = 350
                },
                new Pet
                 {
                Id = _id++,
                Name = "Fuu",
                Type = "Gote",
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                PreviousOwner = "non",
                Price = 1100
                },
                };




        }
        public static void deletePet(int Id)
        {
            foreach (var pet in _pets)
            {
                if(Id == pet.Id)
                {
                    _pets.Remove(pet);
                    break;
                }
            }
        }

        public static void UpdatePet(int petId, string name, string type,DateTime birthDate, DateTime soldDate, string color, string privousOwner, double price)
        {
            foreach (var pet in _pets)
            {
                if (petId == pet.Id)
                {
                    pet.Name = name;
                    pet.Type = type;
                    pet.BirthDate = birthDate;
                    pet.SoldDate = soldDate;
                    pet.Color = color;
                    pet.PreviousOwner = privousOwner;
                    pet.Price = price;
                    break;
                    
                }
                
            }
            
        }
    }
    
    
}
