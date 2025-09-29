using HWW8WithEF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<Food> Foods { get; set; } = [];
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; } 
        public OrderStatusEnum Status { get; set; }
        public decimal TotalPrice { get;  set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
