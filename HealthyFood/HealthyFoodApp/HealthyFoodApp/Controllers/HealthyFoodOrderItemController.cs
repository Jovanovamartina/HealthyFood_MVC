using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using System.Web.WebPages.Html;
using ViewModels;

namespace HealthyFoodApp.Controllers
{
    public class HealthyFoodOrderItemController : Controller
    {
        private readonly IHealthyFoodOrderItemService _healthyFoodOrderItemService;
        private readonly IHealthyFoodService _healthyFoodService;

        public HealthyFoodOrderItemController(IHealthyFoodOrderItemService healthyFoodOrderItemService, IHealthyFoodService HealthyFoodService)
        {
            _healthyFoodOrderItemService = healthyFoodOrderItemService;
            _healthyFoodService = HealthyFoodService;
        }
      
        [HttpPost]
        public IActionResult Create(HealthyFoodOrderItemViewModel model)
        {
            _healthyFoodOrderItemService.Create(model);
            return RedirectToAction("Edit", "Order", new { id = model.OrderId });
        }
        public IActionResult Edit(int id)
        {
            var item = _healthyFoodOrderItemService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(HealthyFoodOrderItemViewModel model)
        {
            _healthyFoodOrderItemService.Edit(model);
            return RedirectToAction("Edit", "Order", new { Id = model.OrderId });
        }
        public IActionResult Delete(int id)
        {
            var orderId = _healthyFoodOrderItemService.Delete(id);
            return RedirectToAction("Edit", "Order", new { id = orderId });
        }
    }
}
