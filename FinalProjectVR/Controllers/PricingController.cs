using BusinessLayer.Abstrsact;
using DataAccessLayer.Context;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Order()
        {
            var pricingOptions = _pricingService.TGetActiv().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();
            ViewBag.PricingOptions = pricingOptions;
    
            return View();
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
