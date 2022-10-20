using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using ViewModels;

namespace HealthyFoodApp.Controllers
{
    public class HealthyFoodController : Controller
    {
        private readonly IHealthyFoodService _healthyFoodService;


        public HealthyFoodController(IHealthyFoodService healthyFoodService)
        {
            _healthyFoodService = healthyFoodService;
           
        }
        public IActionResult Index()
        {
            List<HealthyFoodViewModel> food =_healthyFoodService.GetAll();
            return View(food);
        }

        public IActionResult Details(int id)
        {
            HealthyFoodViewModel food =_healthyFoodService.GetById(id);
            return View(food);
        }

        public IActionResult Edit(int id)
        {
            HealthyFoodViewModel burger = _healthyFoodService.GetById(id);
            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(HealthyFoodViewModel model)
        {
            _healthyFoodService.Edit(model);
            return RedirectToAction("Index", "HealthyFood");
        }

        public IActionResult Create()
        {
            return View(new HealthyFoodViewModel());
        }

        [HttpPost]
        public IActionResult Create(HealthyFoodViewModel model)
        {
            int id = _healthyFoodService.Create(model);
            return RedirectToAction("Details", "HealthyFood", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            _healthyFoodService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
