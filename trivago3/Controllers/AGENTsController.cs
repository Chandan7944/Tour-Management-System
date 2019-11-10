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
    public class AGENTsController : Controller
    {
        private TRIVAGO2Entities db = new TRIVAGO2Entities();

        // GET: AGENTs
        public ActionResult Index()
        {
            return View(db.AGENTs.ToList());
        }

        // GET: AGENTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENTs.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // GET: AGENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AGENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AGENTID,NAME,LOCATION,CONTACT,EMAIL,PASSWORD")] AGENT aGENT)
        {
            if (ModelState.IsValid)
            {
                db.AGENTs.Add(aGENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aGENT);
        }

        // GET: AGENTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENTs.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // POST: AGENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AGENTID,NAME,LOCATION,CONTACT,EMAIL,PASSWORD")] AGENT aGENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aGENT);
        }

        // GET: AGENTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENTs.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // POST: AGENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AGENT aGENT = db.AGENTs.Find(id);
            db.AGENTs.Remove(aGENT);
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
