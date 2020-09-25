using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.AppService;
using PetShop.Core.DomainService;
using PetShop.Core.Entites;

namespace PetshopRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService petTypeService)
        {
            _ownerService = petTypeService;
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("id must be greater then 0");
            return StatusCode(200, _ownerService.getOwner(id)); 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return StatusCode(200, _ownerService.GetAllOwners());
        }

        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Name))
            {
                return BadRequest("500, Name is Required For Creating Owner");
            }

            return StatusCode(201, _ownerService.CreateOwner(owner));
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner
           )
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("500, Parameter Id and owner Id need to be the same");
            }
            var owners = _ownerService.DeleteOwner(id);

            if (owners == null) return StatusCode(404, "owner not found" + id);

            return StatusCode(202, _ownerService.UpdateOwner(owner));
        }

        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);

            if (owner == null) return StatusCode(404, "owner not found" + id);
            return StatusCode(202, $"pet with id {id} is deleted");
        }
    }
}
