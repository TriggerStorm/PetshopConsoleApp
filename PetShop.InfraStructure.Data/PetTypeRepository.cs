using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class PetTypeRepository: IPetTypeRepository
    {
        public PetTypeRepository()
        {

        }

        public PetType CreatePetType(PetType petType)
        {
            petType.TypeId = FakeDB.Tid++;
            FakeDB.types.Add(petType);
            return petType;
        }

        public PetType PetTypeToDelete(int id)
        {
            var petTypeFound = ReadById(id);
            if (petTypeFound == null) return null;

            FakeDB.types.Remove(petTypeFound);

            return petTypeFound;
        }

        public IEnumerable<PetType> ReadAllPetTypes()
        {
            return FakeDB.types;
        }

        public PetType ReadById(int id)
        {
            foreach (var petType in FakeDB.types)
            {
                if(petType.TypeId == id)
                {
                    return petType;
                }
            }
            return null;
        }

        public PetType UpdatePetType(PetType petTypeToUpdate)
        {
            var petTypeFromDb = ReadById(petTypeToUpdate.TypeId);
            if (petTypeFromDb == null) return null;

            petTypeFromDb.Name = petTypeToUpdate.Name;

            return petTypeToUpdate;
        }
    }
}
