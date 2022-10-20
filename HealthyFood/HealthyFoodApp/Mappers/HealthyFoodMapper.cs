using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
   public static class HealthyFoodMapper
    {
        public static HealthyFoodViewModel ToViewModel(this HealthyFood healthyfood)
        {
            return new HealthyFoodViewModel
            {
                Id = healthyfood.Id,
                Name = healthyfood.Name,
                Ingredients = healthyfood.Ingredients,
                ImageUrl = healthyfood.ImageUrl,
                Price = healthyfood.Price
            };
        }

        public static List<HealthyFoodViewModel> HealthyFoodViewModels(this List<HealthyFood> healthyfood)
        {
            return healthyfood.Select(x => x.ToViewModel()).ToList();
        }
    }
}
