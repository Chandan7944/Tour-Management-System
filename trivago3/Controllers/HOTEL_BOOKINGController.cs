using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trivago3.Models;

namespace trivago3.Controllers
{
    public class HOTEL_BOOKINGController : Controller
    {
        private TRIVAGO2Entities db = new TRIVAGO2Entities();

        // GET: HOTEL_BOOKING
        public ActionResult Index()
        {
            var hOTEL_BOOKING = db.HOTEL_BOOKING.Include(h => h.CUSTOMER).Include(h => h.HOTEL);
            return View(hOTEL_BOOKING.ToList());
        }

        // GET: HOTEL_BOOKING/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_BOOKING hOTEL_BOOKING = db.HOTEL_BOOKING.Find(id);
            if (hOTEL_BOOKING == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_BOOKING);
        }

        // GET: HOTEL_BOOKING/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME");
            ViewBag.HOTELID = new SelectList(db.HOTELs, "HOTELID", "NAME");
            return View();
        }

        // POST: HOTEL_BOOKING/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HOTELID,CUSTOMERID,CHECK_IN,CHECK_OUT")] HOTEL_BOOKING hOTEL_BOOKING)
        {
            if (ModelState.IsValid)
            {
                db.HOTEL_BOOKING.Add(hOTEL_BOOKING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", hOTEL_BOOKING.CUSTOMERID);
            ViewBag.HOTELID = new SelectList(db.HOTELs, "HOTELID", "NAME", hOTEL_BOOKING.HOTELID);
            return View(hOTEL_BOOKING);
        }

        // GET: HOTEL_BOOKING/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_BOOKING hOTEL_BOOKING = db.HOTEL_BOOKING.Find(id);
            if (hOTEL_BOOKING == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", hOTEL_BOOKING.CUSTOMERID);
            ViewBag.HOTELID = new SelectList(db.HOTELs, "HOTELID", "NAME", hOTEL_BOOKING.HOTELID);
            return View(hOTEL_BOOKING);
        }

        // POST: HOTEL_BOOKING/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HOTELID,CUSTOMERID,CHECK_IN,CHECK_OUT")] HOTEL_BOOKING hOTEL_BOOKING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL_BOOKING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", hOTEL_BOOKING.CUSTOMERID);
            ViewBag.HOTELID = new SelectList(db.HOTELs, "HOTELID", "NAME", hOTEL_BOOKING.HOTELID);
            return View(hOTEL_BOOKING);
        }

        // GET: HOTEL_BOOKING/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL_BOOKING hOTEL_BOOKING = db.HOTEL_BOOKING.Find(id);
            if (hOTEL_BOOKING == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL_BOOKING);
        }

        // POST: HOTEL_BOOKING/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOTEL_BOOKING hOTEL_BOOKING = db.HOTEL_BOOKING.Find(id);
            db.HOTEL_BOOKING.Remove(hOTEL_BOOKING);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
