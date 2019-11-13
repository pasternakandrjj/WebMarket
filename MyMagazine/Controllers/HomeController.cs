using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMagazine.Models;
using MyMagazine.Helpers;
using System.Web.Security;
using System.Net;

namespace MyMagazine.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext phoneContext = new PhoneContext();

        public ActionResult Index(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Phone> phonesPerPages = phoneContext.Phones
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phonesPerPages };
            return View(ivm);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Buy(Purchase purchase, int id)
        {
            if (purchase.Email == User.Identity.Name)
            {
                purchase.DateTime = DateTime.Now;
                purchase.PhoneId = id;
                phoneContext.Purchases.Add(purchase);
                phoneContext.SaveChanges();
            }

            return RedirectToAction("Basket", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                }
                if (user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Email = model.Email, Password = model.Password, Age = model.Age, RoleId = 2 });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);//Створює квиток перевірки справжності для зазначеного імені користувача і додає його до колекції файлів Cookie відповіді або до URL-адресу
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User already exist!");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);//Створює квиток перевірки справжності для зазначеного імені користувача і додає його до колекції файлів Cookie відповіді або до URL-адресу
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User is not real!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Basket(int page = 1)
        {
            int pageSize = 20;
            IEnumerable<Purchase> phonesPerPages = phoneContext.Purchases
                .Where(x => x.Email == User.Identity.Name)
                .OrderBy(x => x.DateTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Purchases.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Purchases = phonesPerPages };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult SortedApple(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Phone> iphones = phoneContext.Phones
                .Where(x => x.Producer == "Apple")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Apple").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = iphones };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult SortedHuawei(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Phone> huaweis = phoneContext.Phones
                .Where(x => x.Producer == "Huawei")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Huawei").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = huaweis };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult SortedMicrosoft(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Phone> microsofts = phoneContext.Phones
                .Where(x => x.Producer == "WindowsPhone")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "WindowsPhone").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = microsofts };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult SortedSamsung(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Phone> microsofts = phoneContext.Phones
                .Where(x => x.Producer == "Samsung")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Samsung").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = microsofts };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult SortedXiaomi()
        {
            IEnumerable<Phone> xiaomis = phoneContext.Phones
                .Where(x => x.Producer == "Xiaomi")
                .OrderBy(x => x.Id);

            return View(xiaomis);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddGoods()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddGoods(Phone phone)
        {
            phoneContext.Phones.Add(phone);
            phoneContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditGoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var toupdate = phoneContext.Phones.Find(id);
            if (toupdate == null)
            {
                return HttpNotFound();
            }
            return View(toupdate);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditGoods(int id, Phone phone)
        {
            phoneContext.Phones.Find(id).Name = phone.Name;
            phoneContext.Phones.Find(id).Price = phone.Price;
            phoneContext.Phones.Find(id).Producer = phone.Producer;

            phoneContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteGoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone todelete = phoneContext.Phones.Find(id);
            if (todelete == null)
            {
                return HttpNotFound();
            }
            return View(todelete);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteGoods(int id)
        {
            Phone todelete = phoneContext.Phones.Find(id);
            phoneContext.Phones.Remove(todelete);
            phoneContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}