using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public List<HealthyFoodOrderItemViewModel>?HealthyFood { get; set; }
      
        public decimal TotalPrice => (HealthyFood != null ?HealthyFood.Sum(x => x.Price * x.Quantity) : 0);
    }
}
