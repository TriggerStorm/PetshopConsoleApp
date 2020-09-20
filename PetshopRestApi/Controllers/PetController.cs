using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Core.AppService;
using PetShop.Core.Entites;

namespace PetshopRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("id must be greater then 0");
            return _petService.ReadyById(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is Required For Creating Pet");
            }

            return _petService.CreatePet(pet);
        }
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet) 
        { 
            if(id< 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and Pet Id need to be the same");
            }
           
            return Ok(_petService.UpdatePet(pet));
        }

       [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pett = _petService.RemovePet(id);

            if (pett == null) return StatusCode(404, "pet not found" + id);
            return Ok($"pet with id {id} is deleted");
        }


    }
}
