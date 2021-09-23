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

        public PetRepository(PetShopDBContext ctx)
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
                })
                .ToList();
        }

        public Pet Create(Pet pet)
        {
            var beforeSaveEntity = _ctx.Add(new PetEntity()
                {
                    Name = pet.Name,
                    BirthDate = pet.BirthDate,
                    Color = pet.Color,
                    Price = pet.Price

                })
                .Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = beforeSaveEntity.Id,
                Name = beforeSaveEntity.Name,
                BirthDate = beforeSaveEntity.BirthDate,
                Color = beforeSaveEntity.Color,
                Price = beforeSaveEntity.Price,
                SoldDate = beforeSaveEntity.SoldDate,
            };

        }

        public string Delete(int petId)
        {
            _ctx.Remove(new PetEntity() {Id = petId});
            _ctx.SaveChanges();
            return "Deleted?";
        }

        public Pet UpdatePet(Pet pet)
        {
            var Entity = new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                Color = pet.Color,
                Price = pet.Price

            };
            var PetEntity = _ctx.Update(Entity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = PetEntity.Id,
                Name = PetEntity.Name,
                BirthDate = PetEntity.BirthDate,
                Color = PetEntity.Color,
                Price = PetEntity.Price,
                SoldDate = PetEntity.SoldDate,
            };
        }
    }
}