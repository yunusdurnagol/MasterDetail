using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MasterDetail.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //ApplicationDbContext context = new ApplicationDbContext();
            //context.WorkOrders.Add(
            //    new WorkOrder() { Description = "Description", CustomerId =1, WorkOrderStatus = WorkOrderStatus.Approved }
            //    );
            //context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}