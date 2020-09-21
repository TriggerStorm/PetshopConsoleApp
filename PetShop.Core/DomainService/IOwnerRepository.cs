using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> ReadOwner();

        public Owner AddOwner(Owner owner);
        public Owner deleteOwner(int OwnerId);
        public Owner UpdateOwner(Owner updateOwner);
        public Owner ReadyById(int id);
    }
}
