using DataAccess.Abstraction;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
 public class HealthyFoodRepository : IRepository<HealthyFood>
    {
        private readonly DataBaseContext _context;
        public HealthyFoodRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.HealthyFood.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<HealthyFood> GetAll()
        {
            return _context.HealthyFood.ToList();
        }

        public HealthyFood GetById(int id)
        {
            return _context.HealthyFood.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(HealthyFood entity)
        {
            _context.HealthyFood.Add(entity);
            _context.SaveChanges();
        }

        public void Update(HealthyFood entity)
        {
            _context.HealthyFood.Update(entity);
            _context.SaveChanges();
        }
    }
}


