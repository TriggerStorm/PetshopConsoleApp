using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.AppService;
using PetShop.Core.Entites;

namespace PetshopRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetTypeController : Controller
    {
        private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            if (id < 1) return BadRequest("500, id must be greater then 0");
            return StatusCode(200,_petTypeService.getType(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            if (_petTypeService.GetPetTypes().Count < 0) return StatusCode(500, "list is length 0");
            return StatusCode(200, _petTypeService.GetPetTypes());
        }
        
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.Name))
            {
                return BadRequest("Name is Required For Creating PetType");
            }

            return StatusCode(201, _petTypeService.CreatPetType(petType));
        }

        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType
            )
        {
            if (id < 1 || id != petType.TypeId)
            {
                return BadRequest("500, Parameter Id and PetType Id need to be the same");
            }
            var petTypes = _petTypeService.UpdatePetType(petType);

            if (petTypes == null) return StatusCode(404, "petType not found" + id);

            return StatusCode(202, _petTypeService.UpdatePetType(petType));
        }

        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var petType = _petTypeService.DeletePetType(id);
            
            if (petType == null) return StatusCode(404, "petType not found" + id);
            return StatusCode(202, $"pet with id {id} is deleted");
        }

    }
}
