using BusinessLayer.Abstrsact;
using ClosedXML.Excel;
using CoreLayer.DefaultValues;
using DocumentFormat.OpenXml.Spreadsheet;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
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

            var value = _orderService.TUpdate(orderDTOs);
            if (value.IsSuccess)
            {
            return RedirectToAction("Index");
            }
             return View(orderDTOs);
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
            return File(result.Data, DefaultConstantValue.ExelExport, DefaultConstantValue.ExelExporFolderName);
        }
    }
}
