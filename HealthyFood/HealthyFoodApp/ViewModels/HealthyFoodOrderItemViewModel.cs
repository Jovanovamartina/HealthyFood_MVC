using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class HealthyFoodOrderItemViewModel
    {
        public int Id { get; set; }
        public HealthyFoodViewModel HealthyFood{ get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
