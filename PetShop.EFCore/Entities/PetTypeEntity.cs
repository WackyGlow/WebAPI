using System.Collections.Generic;

namespace PetShop.EFCore.Entities
{
    public class PetTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<PetEntity> petsFromType { get; set; }
    }
}