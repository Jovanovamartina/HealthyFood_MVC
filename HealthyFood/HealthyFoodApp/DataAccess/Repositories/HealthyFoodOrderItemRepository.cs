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

    public class HealthyFoodOrderItemRepository : IRepository<HealthyFoodOrderItem>
    {
        private readonly DataBaseContext _context;
        public HealthyFoodOrderItemRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<HealthyFoodOrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public HealthyFoodOrderItem GetById(int id)
        {
            return _context.HealthyFoodOrderItems
                .Include(x => x.HealthyFood)
                .Include(x => x.Order)
                .FirstOrDefault(x => x.Id == id);

        }

        public void Insert(HealthyFoodOrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(HealthyFoodOrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
