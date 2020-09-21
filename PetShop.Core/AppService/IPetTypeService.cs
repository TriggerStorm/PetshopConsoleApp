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

        PetType UpdatePetType(PetType petTypeToUpdate);

        PetType DeletePetType(int id);
    }
}
