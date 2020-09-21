using PetShop.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AppService
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);

        List<Owner> GetAllOwners();
        Owner getOwner(int id);

        Owner UpdateOwner(Owner ownerUpdate);

        Owner DeleteOwner(int id);
    }
}
