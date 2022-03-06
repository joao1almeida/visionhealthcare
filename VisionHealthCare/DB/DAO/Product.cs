using System;
using System.ComponentModel.DataAnnotations;

namespace DB.DAO
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid ProductGroupId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
