using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.AppService.Service
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.AddOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
          
            return _ownerRepository.deleteOwner(id);
        }

        public List<Owner> GetAllOwners()
        {
           return _ownerRepository.ReadOwner().ToList();
        }

        public Owner getOwner(int id)
        {
          Owner owner =  _ownerRepository.ReadyById(id);
            return owner;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _ownerRepository.UpdateOwner(ownerUpdate);
        }
    }
}
