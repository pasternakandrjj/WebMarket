using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using MyMagazine.Models;
using MyMagazine.Helpers; 

namespace MyMagazine.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext phoneContext = new PhoneContext(); 
        public ActionResult Index(int page = 1)
        {
            int pageSize = 4; // количество объектов на страницу
            IEnumerable<Phone> phonesPerPages = phoneContext.Phones
                .OrderBy(x=>x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phoneContext.Phones.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phonesPerPages };
            return View(ivm);
        }
        //public ActionResult Index()
        //{
        //    //get data
        //    IEnumerable<Phone> phones = phoneContext.Phones;

        //    //phones to dynamic ViewBag
        //    ViewBag.Phones = phones;
        //    return View();
        //}

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

        public RedirectResult ToBasket()
        {
            return RedirectPermanent("/Home/Basket");
        }
    }
}