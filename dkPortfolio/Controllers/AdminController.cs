using dkPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dkPortfolio.Controllers
{
    public class AdminController : MyController
    {
        dkPortfolioContext db = new dkPortfolioContext();
       
        //
        // GET: /Admin/
      
        public ActionResult Index()
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;

            var result = db.Articles.ToList();
            return View(result);
        }

        public ActionResult Logout()
        {
            Session["Admin"] = "0";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ListBlog()
        {
            var result = db.Articles.ToList();
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;

            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(FormCollection frm)
        {
            string pictureURL = frm["PictureUrl"].ToString();
            Picture p = db.Pictures.Add(new Picture
            {
                Path = pictureURL
            });

            int pictureID = p.ID;
            Article a = new Article
            {
                Header = frm["Header"],
                Text = frm["Text"],
                Date = DateTime.Now,
                PictureID = pictureID,
                AccountID = 1
            };
            db.Articles.Add(a);
            db.SaveChanges();
            string resulTag = frm["Tags"].ToString();
            string[] tags = resulTag.Split(',');
            foreach (string t in tags)
            {
                Tag ade = new Tag();
                ade.Textt = t;
                ade.Articles.Add(a);

                db.Tags.Add(ade);
            }
            db.SaveChanges();

            return RedirectToAction("ListBlog");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;
            Article a = db.Articles.FirstOrDefault(x => x.ID == id);
            return View(a);
        }

        [HttpPost]
        public ActionResult SaveEdit(int id, FormCollection frm)
        {
            Article a = db.Articles.FirstOrDefault(x => x.ID == id);
            a.Header = frm["Header"].ToString();
            a.Text = frm["Text"].ToString();
            a.Picture.Path = frm["PictureUrl"].ToString();
            db.SaveChanges();

            return RedirectToAction("ListBlog");
        }


        public ActionResult Delete(int id)
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;
            Article a = db.Articles.FirstOrDefault(x => x.ID == id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeleteB(int id)
        {
            Article a = db.Articles.FirstOrDefault(x => x.ID == id);
            db.Articles.Remove(a);
            db.SaveChanges();
            return RedirectToAction("ListBlog");
        }

        public ActionResult Option()
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;
            Option a = db.Options.FirstOrDefault(x => x.id == 1);
            List<Progress> listP = db.Progresses.ToList();
            ViewBag.list = listP;
            return View(a);
        }

        [HttpPost]
        public ActionResult SOption(Option f)
        {
            Option o = db.Options.FirstOrDefault(x => x.id == 1);
            o.oBook = f.oBook;
            o.oFire = f.oFire;
            o.oGlobe = f.oGlobe;
            o.oThinking = f.oThinking;
            o.oUser = f.oUser;
            db.SaveChanges();
            return RedirectToAction("Option");
        }

        [HttpPost]
        public ActionResult DeleteP(int id)
        {
            Progress p = db.Progresses.FirstOrDefault(x => x.ID == id);
            db.Progresses.Remove(p);
            db.SaveChanges();

            return RedirectToAction("Option");
        }

        [HttpPost]
        public ActionResult SaveP(Progress p)
        {
            db.Progresses.Add(p);
            db.SaveChanges();
            return RedirectToAction("Option");
        }

        public ActionResult ListWork()
        {
            ViewBag.sayi = db.Articles.ToList().Count;
            ViewBag.wSayi = db.Works.ToList().Count;
            var result = db.Works.ToList();
            return View(result);
        }

        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(FormCollection frm)
        {
            if (frm != null)
            {
                Picture p = new Picture();
                p.Path = frm["PictureUrl"].ToString();
                p.Name = "Work Picture";
                db.Pictures.Add(p);
                db.SaveChanges();
                int pId = p.ID;
                Work w = new Work()
                {
                    AccountID=1,
                    Name=frm["Name"].ToString(),
                    Type = frm["Type"].ToString(),
                    Date = DateTime.Now,
                    Text = frm["Text"].ToString(),
                    PictureID= pId,
                    LongText = frm["LongText"].ToString()
     
                    //ID, AccountID, Name, Type, Date, Text, Url, PictureID, LongText
                };
                db.Works.Add(w);
                db.SaveChanges();
            }

            return RedirectToAction("ListWork");
        }


        public ActionResult EditWork(int id=0)
        {
            if (id > 0)
            {
                Work w = db.Works.FirstOrDefault(x => x.ID == id);
                if (w != null)
                {
                    return View(w);
                }
            }
            return RedirectToAction("ListWork");    
        }
        [HttpPost]
        public ActionResult EditWork(int id,FormCollection frm)
        {
            
            if (frm != null)
            {
                Work w = db.Works.FirstOrDefault(x => x.ID == id);
                int pictureID = 0;
                if (w.Picture.Path == frm["PictureUrl"].ToString())
                    pictureID = w.Picture.ID;
                else
                {
                    Picture p = new Picture();
                    p.Path = frm["PictureUrl"].ToString();
                    p.Name = "Work Name";
                    db.Pictures.Add(p);
                    db.SaveChanges();
                    pictureID = p.ID;
                }
                if (w != null)
                {
                    w.AccountID=1;
                    w.Name=frm["Name"].ToString();
                    w.Type = frm["Type"].ToString();
                    w.Date = DateTime.Now;
                    w.Text = frm["Text"].ToString();
                    w.PictureID = pictureID;
                    w.LongText = frm["LongText"].ToString();
                    db.SaveChanges();
     
                }
            }
            return RedirectToAction("ListWork");
        }

        public ActionResult DeleteWork(int id=0)
        {
            if (id > 0)
            {
                Work w = db.Works.FirstOrDefault(x => x.ID == id);
                if (w != null)
                    return View(w);
                else
                    return RedirectToAction("ListWork");
            }
            else
            {
                return RedirectToAction("ListWork");
            }
        }
        public ActionResult DeleteWorkThis(int id=0)
        {
            if(id>0){
                Work w = db.Works.FirstOrDefault(x => x.ID == id);
                if (w != null)
                {
                    db.Works.Remove(w);
                    db.SaveChanges();
                    return RedirectToAction("ListWork");
                }
            }
            return RedirectToAction("DeleteWork",new {id=id});
            
        }

        public ActionResult OptionsAdmin()
        {
            var linklist = db.Links.ToList();
            ViewBag.social = linklist;
            Account a = db.Accounts.FirstOrDefault(x => x.isAdmin == true);
            if (a != null)
            {
                return View(a);
            }
            
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult OptionsAdmin(int id,FormCollection frm)
        {
            if (id > 0)
            {
                Account a = db.Accounts.FirstOrDefault(x => x.ID == id);
                if (a != null)
                {
                    if (frm != null)
                    {
                        int pictureID = 0;
                        if (a.Picture.Path == frm["PictureUrl"].ToString())
                        {
                            pictureID = (int)a.PictureID;
                        }
                        else
                        {
                            Picture p = new Picture
                            {
                                Path = frm["PictureUrl"].ToString(),
                                Name = "Admin Photo"                                
                            };
                            db.Pictures.Add(p);
                            db.SaveChanges();
                            pictureID = p.ID;
                        }
                        a.Name = frm["Name"].ToString();
                        a.Surname = frm["Surname"].ToString();
                        a.Birthday = DateTime.Parse(frm["Birthday"].ToString());
                        a.Email = frm["Email"].ToString();
                        a.Password = frm["Password"].ToString();
                        a.Address = frm["Address"].ToString();
                        a.Phone = frm["Phone"].ToString();
                        a.About = frm["About"].ToString();
                        a.ShortAbout = frm["ShortAbout"].ToString();
                        a.PictureID = pictureID;
                        db.SaveChanges();
                        return RedirectToAction("Index");
    //@*ID, Name, Surname, Birthday, Email, Password, Address, Phone, About, ShortAbout, PictureID, isAdmin*@

                    }
                    else
                    {
                        return RedirectToAction("OptionsAdmin");
                    }

                }
                else
                {
                    return RedirectToAction("OptionsAdmin");
                }
            }
            else
            {
                return RedirectToAction("OptionsAdmin");
            }
        }

        [HttpPost]
        public ActionResult OptionsLink(Link link)
        {
            if (link != null)
            {
                db.Links.Add(link);
                db.SaveChanges();
            }
            return RedirectToAction("OptionsAdmin");
        }
        
        [HttpPost]
        public ActionResult LinkD(int id=0)
        {
            if (id > 0)
            {
                Link l = db.Links.FirstOrDefault(x => x.ID == id);
                if (l != null)
                {
                    db.Links.Remove(l);
                    db.SaveChanges();
                   
                }
            }
            return RedirectToAction("OptionsAdmin");
        }
    }
}