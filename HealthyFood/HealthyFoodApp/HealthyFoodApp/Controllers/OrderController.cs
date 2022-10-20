using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using ViewModels;

namespace HealthyFoodApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IHealthyFoodService _healthyFoodService;
        private readonly ILocationService _locationService;

        public OrderController(IOrderService orderService, IHealthyFoodService healthyFoodService,  ILocationService locationService)
        {
            _orderService = orderService;
            _healthyFoodService = healthyFoodService;
            _locationService = locationService;
        }
        public IActionResult Index()
        {
            List<OrderViewModel> orders = _orderService.GetAll();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            OrderViewModel model = _orderService.GetById(id);
            return View(model);
        }

        public IActionResult Create()
        {
         
            ViewBag.food = _healthyFoodService.GetAll();
            return View(new OrderViewModel());
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            _orderService.Create(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel model)
        {
            _orderService.Edit(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CompleteOrder(int id)
        {
            _orderService.CompleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
