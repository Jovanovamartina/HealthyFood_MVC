using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using ViewModels;

namespace HealthyFoodApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;


        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            var items = _locationService.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View(new LocationViewModel());
        }

        [HttpPost]
        public IActionResult Create(LocationViewModel model)
        {
            _locationService.Create(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = _locationService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(LocationViewModel model)
        {
            _locationService.Edit(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _locationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
