using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.EFCore.Entities
{
    public class OwnerRepository : IOwnerRepositories
    {
        private readonly PetShopDBContext _ctx;

        public OwnerRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Owner> GetAllOwner()
        {
            return _ctx.Owner
                .Select(o => new Owner
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            var beforeEntitySave = _ctx.Add(new OwnerEntity 
                {
                    Id = owner.Id,
                    Name = owner.Name
                })
                .Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = beforeEntitySave.Id,
                Name = beforeEntitySave.Name
            };
        }

        public string DeleteOwner(int ownerid)
        {
            _ctx.Remove(new OwnerEntity() {Id = ownerid});
            _ctx.SaveChanges();
            return "Deleted?";
        }

        public Owner UpdateOwner(Owner owner)
        {
            var beforeEntitySave = new OwnerEntity
            {
                Id = owner.Id,
                Name = owner.Name
            };
            var OwnerEntity = _ctx.Update(beforeEntitySave).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = OwnerEntity.Id,
                Name = OwnerEntity.Name
            };
        }
    }
}