using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class PetRepository: IPetRepositories
    {
        private readonly PetShopDBContext _ctx;

        PetRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }


        public List<Pet> GetAllPets()
        {
            return _ctx.Pet
                .Select(p => new Pet()
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Color = p.Color,
                    Price = p.Price,
                    SoldDate = p.SoldDate,
                    PetType = p.PetType
                }).ToList();
        }

        public Pet Create(Pet pet)
        {
            var beforeSaveEntity = new PetEntity()
            {
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                Color = pet.Color,
                
            };
        }

        public string Delete(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}