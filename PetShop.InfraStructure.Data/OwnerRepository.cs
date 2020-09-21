using PetShop.Core.DomainService;
using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner AddOwner(Owner owner)
        {
             FakeDB.owners.Add(owner);
            return owner;
        }

        public Owner deleteOwner(int OwnerId)
        {

            var Owner = ReadyById(OwnerId);
            if (Owner == null) return null;

            FakeDB.owners.Remove(Owner);
            return Owner;
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return FakeDB.owners;
        }

        public Owner ReadyById(int id)
        {
            foreach (var owner in FakeDB.owners)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            var ownerFromDb = ReadyById(updateOwner.OwnerId);
            if (ownerFromDb == null) return null;

            ownerFromDb.Name = updateOwner.Name;
            ownerFromDb.Address = updateOwner.Address;
            ownerFromDb.PetsOwned = updateOwner.PetsOwned;

            return updateOwner;
        }
    }
}
