using System;
using System.ComponentModel.DataAnnotations;

namespace fruitstand.Models
{
    public class Fruit
    {
        public string Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value.ToLower();
            }
        }

        [Required]
        [Range(.01, double.MaxValue)]
        public double PricePerUnit { get; set; }

        public Fruit(string name, double price, string id)
        {
            Name = name.ToLower();
            PricePerUnit = price;
            Id = id;
        }
    }
}