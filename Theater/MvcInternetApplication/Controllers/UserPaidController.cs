using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MvcInternetApplication.Models;
using MvcInternetApplication.Controllers.Filters;
using System.Threading;

namespace MvcInternetApplication.Controllers
{
    [Culture]
    public class UserPaidController : Controller
    {
        private TheaterContext db = new TheaterContext();

        ////
        //// GET: /UserPaid/
        [Authorize(Roles = "Admin, Сourier")]
        public ActionResult Index()
        {
            List<UserPaidShow> users = new List<UserPaidShow>();
            var f = from c in db.UserProfiles
                    from c1 in db.UserPaid
                    from c2 in db.Performances
                    from c3 in db.Seats
                    where c.UserId == c1.UserProfileId && c2.Id == c1.PerformanceId && c3.SeatId == c1.SeatId
                    select new
                    {
                        c.UserName,
                        c2.Name,
                        c2.Date,
                        c3.SeatId,
                        c1.Payment,
                        c1.UserPaidId
                    };
            foreach (var t in f)
            {
                UserPaidShow use = new UserPaidShow();
                use.UserPaidId = t.UserPaidId;
                use.Name = t.UserName;
                use.Performance = t.Name;
                use.Date = t.Date;
                use.SeatId = t.SeatId;
                use.Payment = t.Payment;
                users.Add(use);
            }
            ViewBag.User = users;
            return View();
        }

        // GET: /UserPaid/Create
        [Authorize]
        public ActionResult Create(int SeatId,int Id)
        {
            Seat seat = db.Seats.Find(SeatId);
            if (seat == null || Id == 0)
            {
                return HttpNotFound();
            }

            ViewBag.perfId = Id;
            return View(seat);
        }

        //
        // POST: /UserPaid/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int PerfID, Seat seat)
        {
            if (seat == null || PerfID == 0)
            {
                return HttpNotFound();
            }
            
           var usId = from c in db.UserProfiles
                    where c.UserName.Equals(User.Identity.Name)
                    select c.UserId;
            
            UserPaid newUser = new UserPaid();
            Performance performance = db.Performances.Find(PerfID);
            newUser.UserProfileId = usId.First();
            newUser.PerformanceId = PerfID;
            newUser.SeatId = seat.SeatId;
            newUser.Payment = false;

                db.UserPaid.Add(newUser);
                db.SaveChanges();
            return RedirectToAction("Cabinet","Home");
        }
        

        [Authorize(Roles = "Сourier")]
        public ActionResult Delete(int UserPaidId)
        {
            UserPaid userpaid = db.UserPaid.Find(UserPaidId);
            db.UserPaid.Remove(userpaid);
            db.SaveChanges();
            return RedirectToAction("Index", "UserPaid");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Сourier")]
        public ActionResult Edit(int UserPaidId)
        {
            UserPaid userPaid  = db.UserPaid.Find(UserPaidId);
            if (userPaid == null)
            {
                return HttpNotFound();
            }
            userPaid.Payment = true;
            db.Entry(userPaid).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "UserPaid");
        }

        public void Report()
        {
            var f = from c in db.UserProfiles
                    from c1 in db.UserPaid
                    from c2 in db.Performances
                    from c3 in db.Seats
                    where c.UserId == c1.UserProfileId && c2.Id == c1.PerformanceId && c3.SeatId == c1.SeatId && c1.Payment == false
                    select new
                    {
                        c.UserName,
                        c2.Name,
                        c2.Date,
                        c3.SeatId,
                        c1.Payment,
                        c1.UserPaidId
                    };
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=Report.csv");
            Response.ContentType = "text/csv";
            foreach (var r in f)
            {
                Response.Write(r.UserName + ";" + r.Name + ";" + r.Date + ";" + r.SeatId + ";" + r.Payment + "\n\r");
            }
            Response.End();
        }
    }
}