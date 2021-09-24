﻿using System.Collections.Generic;
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
                    Type = new PetType(){Id = p.PetType.Id,Name = p.PetType.Name},
                    Insurance = new Insurance(){Id = p.InsuranceId,Name = p.Insurance.Name,Price = p.Insurance.Price}
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
                    SoldDate = pet.SoldDate,
                    Price = pet.Price,
                    PetTypeId = pet.Type.Id,
                    InsuranceId = pet.Insurance.Id

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
                Type = new PetType(){Id = beforeSaveEntity.PetTypeId},
                Insurance = new Insurance(){Id = beforeSaveEntity.InsuranceId}
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
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                Color = pet.Color,
                SoldDate = pet.SoldDate,
                Price = pet.Price,
                PetTypeId = pet.Type.Id,
                InsuranceId = pet.Insurance.Id

            };
            var PetEntity = _ctx.Update(Entity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                BirthDate = Entity.BirthDate,
                Color = Entity.Color,
                Price = Entity.Price,
                SoldDate = Entity.SoldDate,
                Type = new PetType(){Id = Entity.PetTypeId},
                Insurance = new Insurance(){Id = Entity.InsuranceId}
            };
        }
    }
}