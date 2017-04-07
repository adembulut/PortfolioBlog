using dkPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dkPortfolio.Controllers
{
    public class HomeController : Controller
    {
        
        dkPortfolioContext db = new dkPortfolioContext();
        //
        // GET: /Home/
        public void ilkGirisKontrol()//ilk açılışta kullanici yoksa burdan kontrol et olustur verilerden bikaçtane
        {
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            if (a == null)
            {
                List<Account> liste = db.Accounts.ToList();
                if (liste.Count > 1 || liste.Count == 0){
                //{ID, Name, Surname, Birthday, Email, Password, Address, Phone, About, ShortAbout, PictureID, isAdmin
                    Picture p = new Picture()
                    {
                        Name="test",
                        Path = "http://placehold.it/200x200"
                    };
                    db.Pictures.Add(p);
                    db.SaveChanges();
                    Account ade = new Account()
                    {
                        Name = "Name",
                        Surname = "Surname",
                        Birthday = DateTime.Parse("06.04.2017 00.00.00"),
                        Email = "demo@demo.com",
                        Password = "demo",
                        Address = "Example Adress",
                        Phone = "+90 444 333 22 11",
                        ShortAbout = "Short About",
                        PictureID = p.ID,
                        isAdmin = true

                    };
                    db.Accounts.Add(ade);
                    db.SaveChanges();
                }
            }
        }
        public ActionResult Index()
        {

            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;
            Account ac = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            List<Link> links = db.Links.ToList();
            List<Work> wo = db.Works.ToList();
            ViewBag.Link = links;
            ViewBag.Work = wo;
            return View(ac);
        }

        public ActionResult About()
        {
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;

            List<Link> links = db.Links.ToList();
            ViewBag.Link = links;

            List<Work> wo = db.Works.ToList();
            ViewBag.Work = wo;

            List<Progress> pList = db.Progresses.ToList();
            ViewBag.pList = pList;

            Option o = db.Options.FirstOrDefault(x => x.id == 1);
            ViewBag.O = o;
            

            Account ac = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            return View(ac);
        }

        public ActionResult Contact()
        {
            List<Link> links = db.Links.ToList();
            ViewBag.Link = links;

            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Mail mail)
        {
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;
            db.Mails.Add(mail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Work()
        {
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;
            Account ac = db.Accounts.FirstOrDefault(x => x.isAdmin == true);

            var isler = db.Works.Where(x => x.AccountID == 1).ToList();
            ViewBag.isler = isler;
            List<Link> linkler = db.Links.ToList();
            ViewBag.Link = linkler;
            return View(ac);
        }

        public ActionResult Blog()
        {
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;

            List<Link> links = db.Links.ToList();
            ViewBag.Link = links;

            List<Work> wo = db.Works.ToList();
            ViewBag.Work = wo;

            List<Progress> pList = db.Progresses.ToList();
            ViewBag.pList = pList;

            Option o = db.Options.FirstOrDefault(x => x.id == 1);
            ViewBag.O = o;

            return View(a);
        }
        public ActionResult Tag(string tag)
        {

            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            ViewBag.Account = a;
            List<Link> links = db.Links.ToList();
            ViewBag.Link = links;

            List<Work> wo = db.Works.ToList();
            ViewBag.Work = wo;

            List<Progress> pList = db.Progresses.ToList();
            ViewBag.pList = pList;

            Option o = db.Options.FirstOrDefault(x => x.id == 1);
            ViewBag.O = o;


            var sonuc = db.Articles.Where(x => x.Tags.Any(t => t.Textt == tag)).ToList();
            //var sonuc = db.Articles.SqlQuery
            //    ("select * from Article where Article.ID in (select ArticleID from TagArticle where TagArticle.TagID in(select ID from Tag where Tag.Textt='"+tag+"'))").ToList();
            ViewBag.listBlog = sonuc;
            return View(a);//burdaki sorguyu hocaya sor
        }
        public ActionResult Blogs(int id=0)
        {
            Article a = db.Articles.FirstOrDefault(x => x.ID == id);
            if (a != null)
            {
                List<Link> linkler = db.Links.ToList();
                ViewBag.Link = linkler;
                Account acount = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
                ViewBag.Account = acount;
                ViewBag.Article = a;
                return View(acount);
            }
            else
            {
                Account ac = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
                ViewBag.Account = ac;
                return RedirectToAction("Blog");
            }
        }
       

        
        public ActionResult DetailWork(int id =0)
        {
            List<Link> linkler = db.Links.ToList();
            ViewBag.Link = linkler;
            Work w = db.Works.FirstOrDefault(x => x.ID == id);
            if (w!=null) {

                Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
                ViewBag.Account = a;
                ViewBag.Work = w;
                return View(a);
            }
            else
            {
                Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
                ViewBag.Account = a;
                return RedirectToAction("Work");
            }
               
            
            
        }


    }
}