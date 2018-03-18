using MvcInternetApplication.Controllers.Filters;
using MvcInternetApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcInternetApplication.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private TheaterContext db = new TheaterContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize] // Запрещены анонимные обращения к данной странице
        public ActionResult Cabinet()
        {
            string name = User.Identity.Name;
            List<UserPaidShow> users = new List<UserPaidShow>();
            var user = from s in db.UserPaid
                       from s1 in db.UserProfiles
                       from s2 in db.Seats
                       from s3 in db.Performances
                       where s1.UserName == name && s1.UserId == s.UserProfileId && s.PerformanceId == s3.Id && s2.SeatId == s.SeatId
                       select new
                       {
                           s.UserPaidId,
                           s.Payment,
                           s2.SeatId,
                           s3.Name,
                           s3.Date,
                       };
            foreach (var t in user)
            {
                UserPaidShow use = new UserPaidShow();
                use.UserPaidId = t.UserPaidId;
                use.Name = name;
                use.Performance = t.Name;
                use.Date = t.Date;
                use.SeatId = t.SeatId;
                use.Payment = t.Payment;
                users.Add(use);
            }
            ViewBag.User = users;
            return View();
        }

        [Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult AdminPanel()
        {
            return View(db.Performances.ToList());
        }

        [Authorize(Roles = "Admin, Сourier")] // К данному методу действия могут получать доступ только пользователи с ролью Admin и Moderator
        public ActionResult Сourier()
        {
            ViewBag.Message = "Курьер";
            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en", "zh-hk" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

    }
}

