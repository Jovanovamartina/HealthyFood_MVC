using DataAccess.Abstraction;
using Domain;
using Mappers;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Implementation
{
    public class HealthyFoodService : IHealthyFoodService
    {
        private readonly IRepository<HealthyFood> _healthyFoodRepository;

        public HealthyFoodService(IRepository<HealthyFood> healthyFoodRepository)
        {
            _healthyFoodRepository = healthyFoodRepository;
        }
        public int Create(HealthyFoodViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Ingredients) || string.IsNullOrEmpty(model.ImageUrl) || model.Price <= 0)
            {
                throw new Exception("All input fields must be filled , price cannot be 0 or less");
            }
            if (_healthyFoodRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                throw new Exception("food with that name already exists");
            }
            HealthyFood newFood = new HealthyFood(model.Name, model.Ingredients, model.ImageUrl, model.Price);
            _healthyFoodRepository.Insert(newFood);
            return newFood.Id;
        }

        public void Delete(int id)
        {
           HealthyFood foodToDelete = _healthyFoodRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (foodToDelete == null)
            {
                throw new Exception("Cannot perform that action");
            }
           _healthyFoodRepository.DeleteById(id);
        }

        public void Edit(HealthyFoodViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Ingredients) || string.IsNullOrEmpty(model.ImageUrl) || model.Price <= 0)
            {
                throw new Exception("All input fields must be filled , price cannot be 0 or less");
            }
            if (_healthyFoodRepository.GetAll().Any(x => x.Name == model.Name && x.Id != model.Id))
            {
                throw new Exception("Burger with that name already exists");
            }
            HealthyFood food = _healthyFoodRepository.GetById(model.Id);
            if (food == null)
            {
                throw new Exception("The endpoint does not exist");
            }
            food.Update(model);
           _healthyFoodRepository.Update(food);
        }

        public List<HealthyFoodViewModel> GetAll()
        {
            return _healthyFoodRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public HealthyFoodViewModel GetById(int id)
        {
            var item =_healthyFoodRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Burger with id : {id} does not exist");
            }
            return item.ToViewModel();
        }
    }
}
