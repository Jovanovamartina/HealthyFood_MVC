using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
   public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order model)
        {
            return new OrderViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
               HealthyFood = model.Healthyfood.Select(x => x.ToViewModel()).ToList(),
               
            };
        }
        public static List<OrderViewModel> OrderViewModels(this List<Order> orders)
        {
            return orders.Select(x => x.ToViewModel()).ToList();
        }
    }
}
