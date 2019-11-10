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
    public class HOTELsController : Controller
    {
        private TRIVAGO2Entities db = new TRIVAGO2Entities();

        // GET: HOTELs
        public ActionResult Index()
        {
            var hOTELs = db.HOTELs.Include(h => h.AGENT);
            return View(hOTELs.ToList());
        }

        // GET: HOTELs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.HOTELs.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // GET: HOTELs/Create
        public ActionResult Create()
        {
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME");
            return View();
        }

        // POST: HOTELs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HOTELID,NAME,CONTACT,LOCATION,DESCRIPTION,AGENTID")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.HOTELs.Add(hOTEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", hOTEL.AGENTID);
            return View(hOTEL);
        }

        // GET: HOTELs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.HOTELs.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", hOTEL.AGENTID);
            return View(hOTEL);
        }

        // POST: HOTELs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HOTELID,NAME,CONTACT,LOCATION,DESCRIPTION,AGENTID")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", hOTEL.AGENTID);
            return View(hOTEL);
        }

        // GET: HOTELs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.HOTELs.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // POST: HOTELs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOTEL hOTEL = db.HOTELs.Find(id);
            db.HOTELs.Remove(hOTEL);
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
