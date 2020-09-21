using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entites
{
    public class Owner
    {
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Pet> PetsOwned { get; set; }
    }
}
