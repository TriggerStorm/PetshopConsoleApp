using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entites
{
    public class Pet
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public String Color { get; set; }
        public String PreviousOwner { get; set; }
        public double Price { get; set; }

    }
}
