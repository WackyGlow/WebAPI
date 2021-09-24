using System;

namespace PetShop.WebAPI.DTO.Pets
{
    public class PostPetDTO
    {
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int InsuranceId { get; set; }
    }
}