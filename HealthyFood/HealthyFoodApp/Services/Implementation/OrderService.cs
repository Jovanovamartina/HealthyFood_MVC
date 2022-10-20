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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;


        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;

        }
    
public void CompleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order.Healthyfood.Count == 0)
            {
                throw new Exception("You must have at least one item in cart to proceed");
            }
          
            _orderRepository.Update(order);
        }

        public void Create(OrderViewModel model)
        {
            List<HealthyFoodOrderItemViewModel> selectedFood = model.HealthyFood.Where(x => x.IsSelected && x.Quantity > 0).ToList();
          
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("Name and Address fields cannot be empty");
            }
            else if (selectedFood.Count == 0 )
            {
                throw new Exception("Cannot make an order without items");
            }
            Order newOrder = new Order(model.FirstName, model.LastName, model.Address);

            List<HealthyFoodOrderItem> healthyfood = new List<HealthyFoodOrderItem>();
           
            foreach (var item in selectedFood)
            {
               healthyfood.Add(new HealthyFoodOrderItem(item.HealthyFood.Id, newOrder.Id, item.Quantity, item.Price));
            }
      
            newOrder.Healthyfood = healthyfood;
    
            _orderRepository.Insert(newOrder);
        }

        public void Delete(int id)
        {
            var item = _orderRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Order with Id:{id} does not exist");
            }
            _orderRepository.DeleteById(id);
        }

        public void Edit(OrderViewModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("All text fields must be filled");
            }
            Order order = _orderRepository.GetById(model.Id);
            if (order == null)
            {
                throw new Exception($"Order with id : {model.Id} does not exist");
            }
          
            order.Update(model);
            _orderRepository.Update(order);
        }

        public List<OrderViewModel> GetAll()
        {
            var items = _orderRepository.GetAll();
            return _orderRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public OrderViewModel GetById(int id)
        {
            Order model = _orderRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"Item with id :{id} does not exist");
            }
            return model.ToViewModel();
        }
    }
}
