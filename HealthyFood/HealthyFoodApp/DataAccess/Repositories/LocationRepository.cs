using DataAccess.Abstraction;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly DataBaseContext _context;

        public LocationRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);

            if (item != null)
            {
                _context.Locations.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return _context.Locations.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Location entity)
        {
            _context.Locations.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Location entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                _context.Locations.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
