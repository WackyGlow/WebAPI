using System;
using System.Collections.Generic;
using PetShop.Core.Filtering;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IPetRepositories
    {
        List<Pet> GetAllPets(Filter filter);
        Pet Create(Pet pet);
        string Delete(int petId);
        Pet UpdatePet(Pet pet);
        int TotalCount();
    }
}