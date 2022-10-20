using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Abstraction
{
    public interface IHealthyFoodService
    {
        List<HealthyFoodViewModel> GetAll();
       HealthyFoodViewModel GetById(int id);
        int Create(HealthyFoodViewModel model);
        void Edit(HealthyFoodViewModel model);
        void Delete(int id);
    }
}
