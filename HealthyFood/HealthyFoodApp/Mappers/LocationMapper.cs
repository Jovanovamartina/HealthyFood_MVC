using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Mappers
{
   public static class LocationMapper
    {
        public static LocationViewModel ToViewModel(this Location location)
        {
            return new LocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt
            };
        }
    }
}
