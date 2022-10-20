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
    public class HealthyFoodOrderItemService:IHealthyFoodOrderItemService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<HealthyFood> _healthyFoodRepository;
        private readonly IRepository<HealthyFoodOrderItem> _healthyFoodOrderItemRepository;

        public HealthyFoodOrderItemService(IRepository<Order> orderRepository, IRepository<HealthyFood> healthyFoodRepository, IRepository<HealthyFoodOrderItem> healthyFoodOrderItemRepository)
        {
            _orderRepository = orderRepository;
            _healthyFoodRepository = healthyFoodRepository;
            _healthyFoodOrderItemRepository = healthyFoodOrderItemRepository;
        }

        public void Create(HealthyFoodOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with id: {model.OrderId} does not exist");
            }
           
            var food = _healthyFoodRepository.GetById(model.HealthyFood.Id);
            if (food == null)
            {
                throw new Exception("Please select a valid burger");
            }
            else if (model.Quantity <= 0)
            {
                throw new Exception("Quantity cannot be 0 or less");
            }
            if (order.Healthyfood.Any(x => x.HealthyFoodId == food.Id))
            {
                var existingBurger = order.Healthyfood.First(x => x.HealthyFoodId == food.Id);
                existingBurger.Quantity += model.Quantity;
            }
            else
            {
                order.Healthyfood.Add(new HealthyFoodOrderItem(food.Id, order.Id, model.Quantity,food.Price));
            }
            _orderRepository.Update(order);
        }

        public int Delete(int id)
        {
            var order = _orderRepository.GetAll().FirstOrDefault(x => x.Healthyfood.Any(y => y.Id == id));
            if (order == null)
            {
                throw new Exception($"Order with id :{order.Id} does not contain item with id : {id}");
            }
          
            var item = order.Healthyfood.FirstOrDefault(x => x.Id == id);
            order.Healthyfood.Remove(item);
            _orderRepository.Update(order);
            return order.Id;
        }

        public void Edit(HealthyFoodOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with Id : {model.OrderId} does not exist.");
            }
          
            if (model.Quantity <= 0)
            {
                throw new Exception($"Quantity cannot be 0 or less");
            }
            var editItem = order.Healthyfood.FirstOrDefault(x => x.Id == model.Id);
            editItem.Quantity = model.Quantity;
            _orderRepository.Update(order);
        }

        public HealthyFoodOrderItemViewModel GetById(int id)
        {
            var item = _healthyFoodOrderItemRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Item with id:{id} does not exist");
            }
            return item.ToViewModel();
        }
    }
}
