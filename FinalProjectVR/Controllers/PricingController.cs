using BusinessLayer.Abstrsact;
using DTOLayer.OrderDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class PricingController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPricingService _pricingService;
       

        public PricingController(IOrderService orderService, IPricingService pricingService) 
        {
            _orderService = orderService;
            _pricingService = pricingService;
        }
       
        public IActionResult Index()
        {
            var value = _pricingService.TGetActiv().Data;
            return View(value);
        }


        [HttpGet]
        public IActionResult Order(int id)
        {
            var data = _orderService.TGetById(id).Data;
            //var test = _pricingService.TGetActiv().Data;
            ViewData["Prices"] = _pricingService.TGetActiv().Data;

            //var pricingOptions = _pricingService.TGetActiv().Data.Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Title
            //}).ToList();
            //ViewBag.PricingOptions = pricingOptions;
    
            return View(data);
        }
        [HttpPost]
        public IActionResult Order(OrderDTOs orderDTOs)
        {

            _orderService.TAdd(orderDTOs);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetOrderer(string licenseplate)
        {
            var order = _orderService.FirstOrDefault(licenseplate).Data;
            return View(order);
        }


    }
}
