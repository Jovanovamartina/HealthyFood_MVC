using DataAccess.Abstraction;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public class OrderRepository : IRepository<Order>
    {

        private readonly DataBaseContext _context;

        public OrderRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Orders.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Include(x => x.Healthyfood).ThenInclude(y => y.HealthyFood).ToList();

        }

        public Order GetById(int id)
        {
            return _context.Orders.Include(x => x.Healthyfood).ThenInclude(y => y.HealthyFood).FirstOrDefault(x => x.Id == id);

        }

        public void Insert(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
