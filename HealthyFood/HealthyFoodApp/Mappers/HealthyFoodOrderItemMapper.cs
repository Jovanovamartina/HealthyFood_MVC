using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
  public static class HealthyFoodOrderItemMapper
    {
        public static HealthyFoodOrderItemViewModel ToViewModel(this HealthyFoodOrderItem food)
        {
            return new HealthyFoodOrderItemViewModel()
            {
                Id = food.Id,
                HealthyFood = food.HealthyFood.ToViewModel(),
                Quantity =food.Quantity,
                Price = food.Price,
                IsSelected = false,
                OrderId = food.OrderId,
            };
        }
    }
}
