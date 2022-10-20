using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
   public class HealthyFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
     
        public decimal Price { get; set; }

        public HealthyFood()
        {

        }
        public HealthyFood(string name, string ingredients, string imageUrl, decimal price)
        {
            Name = name;
            Ingredients = ingredients;
            ImageUrl = imageUrl;
            Price = price;
        }
        
          public void Update(HealthyFoodViewModel model)
        {
            Name = model.Name;
            Ingredients = model.Ingredients;
            ImageUrl = model.ImageUrl;
            Price = model.Price;
        }

       
    }
}
