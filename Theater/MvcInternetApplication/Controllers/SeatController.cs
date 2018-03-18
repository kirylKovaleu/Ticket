using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcInternetApplication.Models;
using MvcInternetApplication.Controllers.Filters;

namespace MvcInternetApplication.Controllers
{
    [Culture]
    public class SeatController : Controller
    {
        private TheaterContext db = new TheaterContext();

        //
        // GET: /Seat/

        public ActionResult Index(int id)
        {
            Performance performance = db.Performances.Find(id);

            if (performance == null)
            {
                return HttpNotFound();
            }

            IQueryable<Seat> seats = from s in db.Seats
                                     where !db.UserPaid.Any(r => r.SeatId == s.SeatId && r.PerformanceId == id)
                                     select s;

            ViewBag.Message = performance.Name;
            ViewBag.Id = id;
            return View(seats);
        }
        //
        // GET: /Seat/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Seat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Seats.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Cabinet","Home");
            }

            return View(seat);
        }
        

    }
}