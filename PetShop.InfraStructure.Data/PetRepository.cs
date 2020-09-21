using PetShop.Core.AppService.Service;
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
                InitData();
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

        public Pet deletePet(int PetID)
        {
            var petFound = ReadyById(PetID);
            if (petFound == null) return null;
            //FakeDB.pets.RemoveAt(1);
            FakeDB.pets.Remove(petFound);
            return petFound;

        }

        public Pet ReadyById(int id)
        {
            foreach (var pet in FakeDB.pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        // THIS IS SOME SHIT  WEEEEEE need to talk about !!!
        /* public Pet ReadyById(int id) 
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

         }*/

        public Pet UpdatePet(Pet updatePet)
        {
            Pet petFromDB = ReadyById(updatePet.Id);
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
                if (type == pet.Type.ToString())
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
        public static void InitData()
        {


            var p1 = new Pet()
            {
                
                Id = FakeDB.id++,
                Name = "Jimmy",
                BirthDate = DateTime.Now.AddDays(-350),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
                Price = 200.50



            };
            FakeDB.pets.Add(p1);
            
            var p2 = new Pet()
            {
                Id = FakeDB.id++,
                Name = "Felix",
               
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
               
                Price = 150
            };
            FakeDB.pets.Add(p2);
            var p3 = new Pet()
            {
                Id = FakeDB.id++,
                Name = "Felixy",
               
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
              
                Price = 1500
            };
            FakeDB.pets.Add(p3);
            var p4 = new Pet()
            {
                Id = FakeDB.id++,
                Name = "Fel",
              
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
              
                Price = 120
            };
            FakeDB.pets.Add(p4);
            var p5 = new Pet()
            {
                Id = FakeDB.id++,
                Name = "Fexy",
               
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
              
                Price = 350
            };
            FakeDB.pets.Add(p5);
            var p6 = new Pet()
            {
                Id = FakeDB.id++,
                Name = "Fuu",
             
                BirthDate = DateTime.Now.AddDays(-80),
                SoldDate = DateTime.Now.AddDays(-1),
                Color = "black",
               
                Price = 1100
            };
            FakeDB.pets.Add(p6);
        }
    }
}
