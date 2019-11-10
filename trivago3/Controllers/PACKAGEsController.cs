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
    public class PACKAGEsController : Controller
    {
        private TRIVAGO2Entities db = new TRIVAGO2Entities();

        // GET: PACKAGEs
        public ActionResult Index()
        {
            var pACKAGES = db.PACKAGES.Include(p => p.AGENT);
            return View(pACKAGES.ToList());
        }

        // GET: PACKAGEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE pACKAGE = db.PACKAGES.Find(id);
            if (pACKAGE == null)
            {
                return HttpNotFound();
            }
            return View(pACKAGE);
        }

        // GET: PACKAGEs/Create
        public ActionResult Create()
        {
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME");
            return View();
        }

        // POST: PACKAGEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PACKAGEID,PRICE,DESCRIPTION,ACTIVITIES,NO_OF_DAYS,PLACES,AGENTID")] PACKAGE pACKAGE)
        {
            if (ModelState.IsValid)
            {
                db.PACKAGES.Add(pACKAGE);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", pACKAGE.AGENTID);
            return View(pACKAGE);
        }

        // GET: PACKAGEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE pACKAGE = db.PACKAGES.Find(id);
            if (pACKAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", pACKAGE.AGENTID);
            return View(pACKAGE);
        }

        // POST: PACKAGEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PACKAGEID,PRICE,DESCRIPTION,ACTIVITIES,NO_OF_DAYS,PLACES,AGENTID")] PACKAGE pACKAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACKAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AGENTID = new SelectList(db.AGENTs, "AGENTID", "NAME", pACKAGE.AGENTID);
            return View(pACKAGE);
        }

        // GET: PACKAGEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACKAGE pACKAGE = db.PACKAGES.Find(id);
            if (pACKAGE == null)
            {
                return HttpNotFound();
            }
            return View(pACKAGE);
        }

        // POST: PACKAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PACKAGE pACKAGE = db.PACKAGES.Find(id);
            db.PACKAGES.Remove(pACKAGE);
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
