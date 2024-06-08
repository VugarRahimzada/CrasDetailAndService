using BusinessLayer.Abstrsact;
using CoreLayer.DefaultValues;
using EntityLayer.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var value = _orderService.GetOrderWithPricingCategory().Data;
            return View(value);
        }


        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            var value = _orderService.TGetById(id).Data;
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateOrder(Order orderDTOs)
        {

            var result = _orderService.TUpdate(orderDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(orderDTOs);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetById(id).Data;
             _orderService.TDelete(value);

            return RedirectToAction("Index");

        }
        public IActionResult HardDeleteOrder(int id)
        {
            var value = _orderService.TGetById(id).Data;
            _orderService.THardDelete(value);

            return RedirectToAction("Index");

        }

        public IActionResult ExportExelOrder()
        {
            var result = _orderService.ExportExelOrder();
            var datetime = DateTime.Now.ToString("/dd/MM/yyyy/mm/ss");
            return File(result.Data, DefaultConstantValue.ExelExport, DefaultConstantValue.ExelExporFolderName+ datetime + ".xlsx");
        }
    }
}
