using HWW8WithEF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HWW8WithEF.Enums;

namespace HWW8WithEF.Entities
{
    public abstract class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public FoodCategoryEnum Category { get; set; }
        public int RestaurantId { get; set; }     
        public Restaurant Restaurant { get; set; } 
    }
}
