using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HTeval.Models;

namespace HTeval.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public async Task<ActionResult> Index()
        {
            ViewData["AddressStats"] = db.Database.SqlQuery<AddressStats>("AddressStats");
            return View(await db.Contacts.ToListAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}