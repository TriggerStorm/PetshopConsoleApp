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

        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            return _petTypeService.GetPetTypes();
        }
        
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.Name))
            {
                return BadRequest("Name is Required For Creating PetType");
            }

            return _petTypeService.CreatPetType(petType);
        }

        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType
            )
        {
            if (id < 1 || id != petType.TypeId)
            {
                return BadRequest("Parameter Id and PetType Id need to be the same");
            }

            return Ok(_petTypeService.UpdatePetType(petType));
        }

        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            var petType = _petTypeService.DeletePetType(id);

            if (petType == null) return StatusCode(404, "pet not found" + id);
            return Ok($"pet with id {id} is deleted");
        }

    }
}
