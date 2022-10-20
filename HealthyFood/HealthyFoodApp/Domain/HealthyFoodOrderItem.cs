using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
   public class HealthyFoodOrderItem
    {
        public int Id { get; set; }
        public int HealthyFoodId { get; set; }
        public HealthyFood HealthyFood{ get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public HealthyFoodOrderItem()
        { 
        }
        public HealthyFoodOrderItem(int healthyFoodId, int orderId, int quantity, decimal price)
        {
            HealthyFoodId = healthyFoodId;
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }

      
    }
}
