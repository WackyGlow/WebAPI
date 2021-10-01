using System;
using System.Collections.Generic;
using PetShop.Core.Filtering;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepositories _repo;
        private List<Pet> PetList = new List<Pet>();

        public PetService(IPetRepositories repo)
        {
            _repo = repo;
        }

        public List<Pet> GetAllPets(Filter filter)
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
            return _repo.GetAllPets(filter);
        }

        public List<Pet> GetPetsByType(string searchedWords)
        {
            var filter = new Filter();
            List<Pet> searchedPets = new List<Pet>();
            PetList = GetAllPets(filter);
            foreach (var pet in PetList)
            {
                if (String.Equals(pet.Type.Name, searchedWords, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
        }

        public Pet Create(Pet pet)
        {
            return _repo.Create(pet);
        }

        public string Delete(int petId)
        {
            return _repo.Delete(petId);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _repo.UpdatePet(pet);
        }

        public int TotalCount()
        {
            return _repo.TotalCount();
        }
    }
}