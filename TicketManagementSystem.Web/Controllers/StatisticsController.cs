﻿using System.Web.Mvc;
using System.Web.UI;

namespace TicketManagementSystem.Web.Controllers
{
    [OutputCache(Duration = 30, Location = OutputCacheLocation.ServerAndClient)]
    public class StatisticsController : Controller
    {
        public ActionResult Index() => View("~/Views/Statistics/Engine/Index.cshtml");

        public ActionResult Legacy() => View("~/Views/Statistics/Index.cshtml");

        public ActionResult Monthly() => View();
    }
}