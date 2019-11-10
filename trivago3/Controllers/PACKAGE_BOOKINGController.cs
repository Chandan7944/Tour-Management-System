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
    public class PACKAGE_BOOKINGController : Controller
    {
        private TRIVAGO2Entities db = new TRIVAGO2Entities();

        // GET: PACKAGE_BOOKING
        public ActionResult Index()
        {
            var pACKAGE_BOOKING = db.PACKAGE_BOOKING.Include(p => p.CUSTOMER).Include(p => p.PACKAGE);
            return View(pACKAGE_BOOKING.ToList());
        }

        // GET: PACKAGE_BOOKING/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE_BOOKING pACKAGE_BOOKING = db.PACKAGE_BOOKING.Find(id);
            if (pACKAGE_BOOKING == null)
            {
                return HttpNotFound();
            }
            return View(pACKAGE_BOOKING);
        }

        // GET: PACKAGE_BOOKING/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME");
            ViewBag.PACKAGEID = new SelectList(db.PACKAGES, "PACKAGEID", "PRICE");
            return View();
        }

        // POST: PACKAGE_BOOKING/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PACKAGEID,CUSTOMERID,BOOKING_DATE")] PACKAGE_BOOKING pACKAGE_BOOKING)
        {
            if (ModelState.IsValid)
            {
                db.PACKAGE_BOOKING.Add(pACKAGE_BOOKING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", pACKAGE_BOOKING.CUSTOMERID);
            ViewBag.PACKAGEID = new SelectList(db.PACKAGES, "PACKAGEID", "PRICE", pACKAGE_BOOKING.PACKAGEID);
            return View(pACKAGE_BOOKING);
        }

        // GET: PACKAGE_BOOKING/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE_BOOKING pACKAGE_BOOKING = db.PACKAGE_BOOKING.Find(id);
            if (pACKAGE_BOOKING == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", pACKAGE_BOOKING.CUSTOMERID);
            ViewBag.PACKAGEID = new SelectList(db.PACKAGES, "PACKAGEID", "PRICE", pACKAGE_BOOKING.PACKAGEID);
            return View(pACKAGE_BOOKING);
        }

        // POST: PACKAGE_BOOKING/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PACKAGEID,CUSTOMERID,BOOKING_DATE")] PACKAGE_BOOKING pACKAGE_BOOKING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACKAGE_BOOKING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMERs, "CUSTOMERID", "NAME", pACKAGE_BOOKING.CUSTOMERID);
            ViewBag.PACKAGEID = new SelectList(db.PACKAGES, "PACKAGEID", "PRICE", pACKAGE_BOOKING.PACKAGEID);
            return View(pACKAGE_BOOKING);
        }

        // GET: PACKAGE_BOOKING/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE_BOOKING pACKAGE_BOOKING = db.PACKAGE_BOOKING.Find(id);
            if (pACKAGE_BOOKING == null)
            {
                return HttpNotFound();
            }
            return View(pACKAGE_BOOKING);
        }

        // POST: PACKAGE_BOOKING/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PACKAGE_BOOKING pACKAGE_BOOKING = db.PACKAGE_BOOKING.Find(id);
            db.PACKAGE_BOOKING.Remove(pACKAGE_BOOKING);
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
