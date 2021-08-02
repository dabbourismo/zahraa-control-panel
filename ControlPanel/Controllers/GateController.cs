using ControlPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class GateController : Controller
    {
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            return View();      
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(GateDto dto)
        {
            if (dto.Password == "z123")
            {
                dto.Error = "";
                Session["logged"] = "logged";
                Session["userId"] = 4;
                return RedirectToAction("Index", "Level");
            }
            else
            {
                dto.Error = "كلمة المرور غير صحيحة";
                return View(dto);
            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Gate");
        }
    }
}