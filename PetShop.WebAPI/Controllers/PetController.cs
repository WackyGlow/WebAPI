using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.WebAPI.DTO.Pets;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<List<GetAllPetsDTO>> getAllPets()
        {
            return Ok(_petService.GetAllPets()
                .Select(p => new GetAllPetsDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    PetTypeName = p.Type.Name,
                    BirthDate = p.BirthDate,
                    SoldDate = p.SoldDate,
                    Color = p.Color,
                    Price = p.Price,
                    InsuranceName = p.Insurance.Name
                }));
        }

        [HttpGet("{id}")]
        //api/Pet/id
        //api/Pet/7
        public ActionResult<Pet> GetById(long id)
        {
            return StatusCode(500, "Vi er ikke klar endnu, ring igen senere bums");
        }

        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody]Pet pet)
        {
            return Created($"https://localhost/api/Pet/{pet.Id}",_petService.Create(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeletePet(int id)
        {
            return _petService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> PutPet( int id, [FromBody]Pet pet)
        {
            return Ok(_petService.UpdatePet(new Pet()
            {
                Id = id,
                Name = pet.Name,
                Type = pet.Type,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            }));
        }
    }
}