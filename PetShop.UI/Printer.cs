using PetShop.Core.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.UI
{
    public class Printer
    {
        private IPetService _petService;
        
        public void PrintAllPets()
        {
            var listOfPets = _petService.GetPets();
            Console.WriteLine("Printing all Pets.\n");
            foreach (var pet in listOfPets)
            {
                Console.WriteLine($"name {pet.Name}");
            }

        }
        public void CreatePet()
        {
            Console.WriteLine("Type Pet Name");
            var name = Console.ReadLine();
            Console.WriteLine("Type In Pet Type");
            var type = Console.ReadLine();
            Console.WriteLine("Type In BirthDate fx. 2020-06-13");
            var birthDate = Console.ReadLine();
            DateTime bd = Convert.ToDateTime(birthDate);
            Console.WriteLine("Type In Soldt date fx. 2020-06-13");
            var soldDate = Console.ReadLine();
            DateTime sd = Convert.ToDateTime(soldDate);
            Console.WriteLine("Type In Color of pet");
            var color = Console.ReadLine();
            Console.WriteLine("Type In PreviousOwner name");
            var previousOwner = Console.ReadLine();
            Console.WriteLine("Type In Price fx, 20.85");
            var price = Console.ReadLine();
            double p = Convert.ToDouble(price);
            var newPet = _petService.CreatePet(name, type, bd, sd, color, previousOwner, p);
            Console.WriteLine($"A new Pet with ID {newPet.Id}");

        }
        public void DeletePet()
        {
            Console.WriteLine("pet id to delete");
            var listOfPets = _petService.GetPets();
            Console.WriteLine("Printing all Pets.\n");
            foreach (var pet in listOfPets)
            {
                Console.WriteLine($"name {pet.Name} ID {pet.Id}");
            }
            var petId = Console.ReadLine();
            var Id = Convert.ToInt32(petId);
            _petService.RemovePet(Id);
            Console.WriteLine($"Pet deleted");

        }
        public void UpdatePet()
        {
            Console.WriteLine("Type Id Of Pet To Update");
            var petId = Console.ReadLine();
            var Id = Convert.ToInt32(petId);
            Console.WriteLine("Type Pet Name");
            var name = Console.ReadLine();
            Console.WriteLine("Type In Pet Type");
            var type = Console.ReadLine();
            Console.WriteLine("Type In BirthDate fx. 2020-06-13");
            var birthDate = Console.ReadLine();
            DateTime bd = Convert.ToDateTime(birthDate);
            Console.WriteLine("Type In Soldt date fx. 2020-06-13");
            var soldDate = Console.ReadLine();
            DateTime sd = Convert.ToDateTime(soldDate);
            Console.WriteLine("Type In Color of pet");
            var color = Console.ReadLine();
            Console.WriteLine("Type In PreviousOwner name");
            var previousOwner = Console.ReadLine();
            Console.WriteLine("Type In Price fx, 20.85");
            var price = Console.ReadLine();
            double p = Convert.ToDouble(price);
            
             _petService.UpdatePet(Id,name,type,bd,sd,color,previousOwner,p);
            Console.WriteLine($"Pet with id {petId} Have been Updated");
        }
        public void SearchPetsByType()
        {
            var t = Console.ReadLine();
            var listOfPets = _petService.GetOneTypeOfPets(t);
            Console.WriteLine("Printing all Pets.\n");
            foreach (var pet in listOfPets)
            {
                Console.WriteLine($"name {pet.Name} type {pet.Type}");
            }

        }
        public void PetsByPrice()
        {
            var pricelist = _petService.OrderByPrice();
            Console.WriteLine("Printing all Pets by price.\n");
            foreach (var pet in pricelist)
            {
                Console.WriteLine($"price {pet.Price} name {pet.Name} type {pet.Type}");
            }
        }
        public void FiveCheepest()
        {
            var pricelist = _petService.OrderByPrice();
            while (pricelist.Count > 5)
                pricelist.RemoveAt(pricelist.Count - 1);
            Console.WriteLine("Printing 5 Cheepest pets.\n");
            foreach (var pet in pricelist)
                {
                    Console.WriteLine($"price {pet.Price} name {pet.Name} type {pet.Type}");
                }
            
        }

        readonly String[] menuItems =
        {
            "Show List Of All Pets",
            "Search Pets By Type",
            "Create a New Pet",
            "Delete pet",
            "Update a pet",
            "Sorted List Of Pets By Price",
            "Get 5 cheapest available Pets",
            "Exit"
        };

        public Printer(IPetService petService)
        {
            _petService = petService;
            var selection = ShowMenu();

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("List Of All Pets");
                        PrintAllPets();
                        break;
                    case 2:
                        Console.WriteLine("Search Pets By Type Fx Cat");
                        SearchPetsByType();
                        break;
                    case 3:
                        Console.WriteLine("Create a New Pet");
                        CreatePet();
                        break;
                    case 4:
                        Console.WriteLine("Delete pet");
                        DeletePet();
                        break;
                    case 5:
                        Console.WriteLine("Update a pet");
                        Console.WriteLine("pet Id To Update");
                        var listOfPets = _petService.GetPets();
                        foreach (var pet in listOfPets)
                        {
                            Console.WriteLine($"ID {pet.Id} Name {pet.Name} Type {pet.Type} BirthDate{pet.BirthDate} SoldDate {pet.SoldDate} Color {pet.Color} PreviousOwner {pet.PreviousOwner} Price {pet.Price}");
                        }
                        UpdatePet();
                        break;
                    case 6:
                        Console.WriteLine("Sorted List Of Pets By Price");
                        PetsByPrice();
                        break;
                    case 7:
                        Console.WriteLine("Get 5 cheapest available Pets");
                        FiveCheepest();
                        break;
                    case 8:
                        Console.WriteLine("Exit");
                        break;

                }
                selection = ShowMenu();
            }
            Console.WriteLine("Cyaa");

            Console.ReadLine();
        }
        int ShowMenu()
        {
            Console.WriteLine("Select An Option From The List:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Plz pick Number 1 - 8");
            }
            return selection;
        }

    }

}
