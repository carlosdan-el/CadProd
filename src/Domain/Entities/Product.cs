using System;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Product : IDatabaseEntity
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string CategoryId { get; set; }
        
        public string TypeId { get; set; }
        
        public string SizeId { get; set; }
        
        public decimal Price { get; set; }
        
        public string Tags { get; set; }
        
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public string UpdatedBy { get; set; }
    }
}