using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.AppService.Service
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _PetTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository) 
        {
            _PetTypeRepository = petTypeRepository;
        }
        public PetType CreatPetType(PetType petType)
        {
            return _PetTypeRepository.CreatePetType(petType);
        }

        public PetType DeletePetType(int id)
        {
            return _PetTypeRepository.PetTypeToDelete(id);
        }

        public List<PetType> GetPetTypes()
        {
            return _PetTypeRepository.ReadAllPetTypes().ToList();
        }

        public PetType UpdatePetType(PetType petTypeToUpdate)
        {
            return _PetTypeRepository.UpdatePetType(petTypeToUpdate);
        }
    }
}
