﻿using System;
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
            return StatusCode(200, _petService.ReadyById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] string prop, string val)
        {
            if(prop == null) return _petService.GetPets();
            return StatusCode(200, _petService.GetPetByProp(prop, val));
            
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("500,Name is Required For Creating Pet");
            }

            return StatusCode(201, _petService.CreatePet(pet));
        }
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet) 
        { 
            if(id< 1 || id != pet.Id)
            {
                return BadRequest("500,Parameter Id and Pet Id need to be the same");
            }
           
            return StatusCode(202,_petService.UpdatePet(pet));
        }

       [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pett = _petService.RemovePet(id);

            if (pett == null) return StatusCode(404, "pet not found" + id);
            return StatusCode(202, $"pet with id {id} is deleted");
        }


    }
}
