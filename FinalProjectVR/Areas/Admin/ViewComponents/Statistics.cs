using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class Statistics: ViewComponent
    {
        private readonly IOrderService _orderService;
        private readonly IBlogService _blogService;
        private readonly ITeamService _teamService;
        private readonly IEmailSubscriptionService _emailSubscription;

        public Statistics(IOrderService orderService, IBlogService blogService, ITeamService teamService, IEmailSubscriptionService emailSubscription)
        {
            _orderService = orderService;
            _blogService = blogService;
            _teamService = teamService;
            _emailSubscription = emailSubscription;
        }

        public IViewComponentResult Invoke()
        {
                ViewBag.ordercount = _orderService.TCount().Data;
            ViewBag.blogcount = _blogService.TCount().Data;
            ViewBag.teamcount = _teamService.TCount().Data;
            ViewBag.emailcount = _emailSubscription.TCount().Data;
            return View();
        }
    }
}
