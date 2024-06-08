using BusinessLayer.Abstrsact;
using DTOLayer.OrderDTO;
using EntityLayer.Models;
using FinalProjectVR.Areas.Admin.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class PricingController : BaseController
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

            ViewData["Prices"] = _pricingService.TGetActiv().Data;


            return View(data);
        }
        [HttpPost]
        public IActionResult Order(OrderCreateDTOs orderDTOs)
        {
            var result = _orderService.TAdd(orderDTOs);
            if (!result.IsSuccess)
            {
                return Json(new { success = false, message = result.Message });
            }
            return Json(new { success = true });
        }


        [HttpGet]
        public IActionResult GetOrderer(string licenseplate)
        {
            var order = _orderService.FirstOrDefault(licenseplate).Data;
            return View(order);
        }
    }
}