using PetShop.Core.AppService;
using PetShop.Core.AppService.Service;
using PetShop.Core.DomainService;
using PetShop.InfraStructure.Data;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace PetShop.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            IPetRepository petRepository = new PetRepository();
            FakeDB.InitData();
            IPetService petService = new PetService(petRepository);
            //var Printer = new Printer();
            var printer = new Printer(petService);
            //printer.PrintAllPets();


        }
    }
}
