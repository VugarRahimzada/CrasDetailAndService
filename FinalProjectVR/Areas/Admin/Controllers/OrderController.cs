using BusinessLayer.Abstrsact;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var value = _orderService.TGetAll();
            return View(value);
        }


        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            var value = _orderService.TGetById(id).Data;
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateOrder(OrderDTOs orderDTOs)
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
            return File(result.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Orders.xlsx");
        }
    }
}
