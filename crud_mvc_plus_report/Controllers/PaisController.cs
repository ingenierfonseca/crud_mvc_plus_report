using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_mvc_plus_report.Controllers
{
    public class PaisController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        // GET: Pais
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string countries()
        {
            return JsonConvert.SerializeObject(db.Paises.ToList());
        }
    }
}