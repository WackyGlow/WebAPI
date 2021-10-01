using System;
using System.Collections.Generic;
using PetShop.Core.Filtering;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }

        public List<Insurance> ReadAll(Filter filter)
        {
            if (filter.Limit <= 0 || filter.Limit > 100 || filter.Limit == null)
            {
                throw new ArgumentException("Filter limit must between 1 and 100");
            }

            var totalCount = TotalCount();
            var maxCount = totalCount / filter.Limit;
            
            if (filter.Page <= 0 || filter.Page > maxCount)
            {
                throw new ArgumentException($"Filter page must be above 0 and {maxCount}");
            }
            return _insuranceRepository.ReadAll(filter);
        }

        public string DeleteInsuranceById(int id)
        {
            return _insuranceRepository.DeleteInsuranceById(id);
        }

        public Insurance PutInsurance(Insurance insurance)
        {
            return _insuranceRepository.UpdateInsurance(insurance);
        }

        public int TotalCount()
        {
            return _insuranceRepository.TotalCount();
        }
    }
}