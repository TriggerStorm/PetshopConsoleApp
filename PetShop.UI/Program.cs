using PetShop.Core.AppService;
using PetShop.Core.AppService.Service;
using PetShop.Core.DomainService;
using PetShop.InfraStructure.Data;
using System;
//using Microsoft.Extensions.DependencyInjection;

namespace PetShop.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            FakeDB.InitData();
            printer.StartUi();

            //IPetRepository petRepository = new PetRepository();
            //IPetService petService = new PetService(petRepository);
            //var printer = new Printer(petService);

            

        }
    }
}
