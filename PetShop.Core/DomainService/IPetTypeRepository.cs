using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public  interface IPetType
    {
        PetType CreatePetType(PetType petType);

        PetType ReadById(int id);
        IEnumerable<PetType> ReadAllPetTypes();

        PetType UpdatePetType(PetType petTypeToUpdate);

        PetType PetTypeToDelete(int id);
    }
}
