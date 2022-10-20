using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Abstraction
{
    public interface IHealthyFoodOrderItemService
    {
        HealthyFoodOrderItemViewModel GetById(int it);
        void Edit(HealthyFoodOrderItemViewModel model);
        void Create(HealthyFoodOrderItemViewModel model);
        int Delete(int id);
    }
}
