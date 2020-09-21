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
            return _ownerService.getOwner(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Name))
            {
                return BadRequest("Name is Required For Creating Owner");
            }

            return _ownerService.CreateOwner(owner);
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner
           )
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("Parameter Id and owner Id need to be the same");
            }

            return Ok(_ownerService.UpdateOwner(owner));
        }

        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var petType = _ownerService.DeleteOwner(id);

            if (petType == null) return StatusCode(404, "pet not found" + id);
            return Ok($"pet with id {id} is deleted");
        }
    }
}
