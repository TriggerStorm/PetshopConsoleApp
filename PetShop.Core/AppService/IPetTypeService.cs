using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AppService
{
    public interface IPetTypeService
    {
        public PetType CreatPetType(PetType petType);

        List<PetType> GetPetTypes();

        public PetType getType(int id);

        PetType UpdatePetType(PetType petTypeToUpdate);

        PetType DeletePetType(int id);
    }
}
