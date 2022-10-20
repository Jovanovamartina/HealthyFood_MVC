using DataAccess.Abstraction;
using Domain;
using Mappers;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels;

namespace Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Create(LocationViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("All field must be filled");
            }
            if (_locationRepository.GetAll().Any(x => x.Name == model.Name && x.Address == x.Address))
            {
                throw new Exception("A location with that name and address already exist");
            }
            var newLocation = new Location(model.Name, model.Address, model.OpensAt, model.ClosesAt);
            _locationRepository.Insert(newLocation);
        }

        public void Delete(int id)
        {
            var item = _locationRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Location with Id : {id} does not exist");
            }

            _locationRepository.DeleteById(id);
        }

        public void Edit(LocationViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Address))
            {
                throw new Exception("All field must be filled");
            }
            if (_locationRepository.GetAll().Any(x => x.Name == model.Name && x.Address == x.Address))
            {
                throw new Exception("A location with that name and address already exist");
            }
            var item = _locationRepository.GetById(model.Id);
            if (item == null)
            {
                throw new Exception("The location you are trying to edit does not exist");
            }
            item.Update(model);
            _locationRepository.Update(item);
        }

        public List<LocationViewModel> GetAll()
        {
            return _locationRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public LocationViewModel GetById(int id)
        {
            return _locationRepository.GetById(id).ToViewModel();
        }



     

    }
}
