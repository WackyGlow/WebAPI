using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Filtering;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDBContext _ctx;

        public InsuranceRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurance
                .Select(ie =>new Insurance()
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            
            var entity = _ctx.Add(new InsuranceEntity(){
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public List<Insurance> ReadAll(Filter filter)
        {
            return _ctx.Insurance
                .Select(insurance => new Insurance
                {
                    Id = insurance.Id,
                    Name = insurance.Name,
                    Price = insurance.Price
                })
                .ToList();
        }

        public string DeleteInsuranceById(int id)
        {
            _ctx.Remove(new InsuranceEntity{Id = id});
            _ctx.SaveChanges();

            return "Deleted?";
        }

        public Insurance UpdateInsurance(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _ctx.Update(insuranceEntity).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public int TotalCount()
        {
            return _ctx.Insurance.Count();
        }
    }
}