using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMagazine.Models;
using MyMagazine.Helpers;
using System.Web.Security;

namespace MyMagazine.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext phoneContext = new PhoneContext();
        public ActionResult Index(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу
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

            //return view
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.DateTime = DateTime.Now;

            phoneContext.Purchases.Add(purchase);
            phoneContext.SaveChanges();

            ViewBag.Message = $"Thanks , {purchase.FIO} ,we will contact you soon! :D";
            return ToBasket();
        }

        public RedirectResult ToBasket()
        {
            return RedirectPermanent("/Home/Basket");
        }

        public ActionResult Basket()
        {
            //get data
            IEnumerable<Purchase> purchases = phoneContext.Purchases;

            ////purchases to dynamic ViewBag
            ViewBag.Purchases = purchases;
            return View();
        }

        [HttpGet]
        public ActionResult GetPhone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPhone(string title, string price)
        {
            return Content($"{title} + {price}");
        }

        public ActionResult SortedApple(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу

            IEnumerable<Phone> iphones = phoneContext.Phones
                .Where(x => x.Producer == "Apple")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Apple").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = iphones };
            return View(ivm);
        }
        public ActionResult SortedHuawei(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу

            IEnumerable<Phone> huaweis = phoneContext.Phones
                .Where(x => x.Producer == "Huawei")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Huawei").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = huaweis };
            return View(ivm);
        }
        public ActionResult SortedMicrosoft(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу 
            IEnumerable<Phone> microsofts = phoneContext.Phones
                .Where(x => x.Producer == "WindowsPhone")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "WindowsPhone").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = microsofts };
            return View(ivm);
        }
        public ActionResult SortedSamsung(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу 
            IEnumerable<Phone> microsofts = phoneContext.Phones
                .Where(x => x.Producer == "Samsung")
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Where(x => x.Producer == "Samsung").Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = microsofts };
            return View(ivm);
        }
        public ActionResult SortedXiaomi()
        {
            IEnumerable<Phone> xiaomis = phoneContext.Phones
                .Where(x => x.Producer == "Xiaomi");


            return View(xiaomis);
        }

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
                // поиск пользователя в бд
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

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
                    // создаем нового пользователя
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Email = model.Email, Password = model.Password, Age = model.Age });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}