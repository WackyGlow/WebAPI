using System;
using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        List<Pet> GetPetsByType(string searchedWords);
        Pet Create(Pet pet);
        string Delete(int petId);
        Pet UpdatePet(Pet pet);
    }
}