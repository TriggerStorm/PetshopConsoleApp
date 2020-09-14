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
        public static int id = 1;
        public static List<Pet> pets = new List<Pet>();
        
        
       

       

        public static void InitData()
        {
            pets = new List<Pet>() {

                new Pet
                {
                    Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
        

       
        
    }
    
    
}
