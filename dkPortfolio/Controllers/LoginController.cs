using dkPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dkPortfolio.Controllers
{
    public class LoginController : Controller
    {
        dkPortfolioContext db = new dkPortfolioContext();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account ac)
        {
            Account ad = db.Accounts.FirstOrDefault(x => x.Email == ac.Email && x.Password == ac.Password);
            if (ad != null)
            {
                Session["Admin"] = "1";
                return Redirect("~/Admin");
            }
            else//burası panel bitince giriş için kaldırılacak
            {
                Session["Admin"] = "0";
                return RedirectToAction("Index", "Login");
            }
            
            
        }
	}
}