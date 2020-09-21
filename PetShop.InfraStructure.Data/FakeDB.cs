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
        // Pets
        public static int id = 1;
        public static List<Pet> pets = new List<Pet>();

        // Types
        public static int Tid = 1;
        public static List<PetType> types = new List<PetType>();

        // Owner
        public static int Oid = 1;
        public static List<Owner> owners = new List<Owner>();
        
        
       

       

        
        

       
        
    }
    
    
}
