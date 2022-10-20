using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels;

namespace Services.Abstraction
{
    public interface ILocationService
    {
        List<LocationViewModel> GetAll();
        LocationViewModel GetById(int id);
        void Create(LocationViewModel model);
        void Edit(LocationViewModel model);
        void Delete(int id);
        

    }
}
