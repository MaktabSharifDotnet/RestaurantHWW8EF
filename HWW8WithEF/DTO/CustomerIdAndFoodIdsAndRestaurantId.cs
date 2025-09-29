using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.DTO
{
    public class CustomerIdAndFoodIdsAndRestaurantId
    {
        public int CustomerId { get; set; }
        public  int RestaurantId { get; set; }
        public List<int> FoodIds { get; set; }
    }
}
