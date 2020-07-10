using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgapeChurchMemberApplication.Models;

namespace AgapeChurchMemberApplication.Controllers
{
    public class VisitorEventsController : Controller
    {
        private AgapeDBContext db = new AgapeDBContext();

        // GET: VisitorEvents
        public ActionResult Index()
        {
            var visitorEvent = db.VisitorEvent.Include(v => v.Event).Include(v => v.Visitor);
            return View(visitorEvent.ToList());
        }

        // GET: VisitorEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorEvent visitorEvent = db.VisitorEvent.Find(id);
            if (visitorEvent == null)
            {
                return HttpNotFound();
            }
            return View(visitorEvent);
        }

        // GET: VisitorEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Event, "EventId", "EventName");
            ViewBag.VisitorId = new SelectList(db.Visitor, "VisitorId", "VisitorEntryDate");
            return View();
        }

        // POST: VisitorEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitorId,EventId")] VisitorEvent visitorEvent)
        {
            if (ModelState.IsValid)
            {
                db.VisitorEvent.Add(visitorEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Event, "EventId", "EventName", visitorEvent.EventId);
            ViewBag.VisitorId = new SelectList(db.Visitor, "VisitorId", "VisitorEntryDate", visitorEvent.VisitorId);
            return View(visitorEvent);
        }

        // GET: VisitorEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorEvent visitorEvent = db.VisitorEvent.Find(id);
            if (visitorEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Event, "EventId", "EventName", visitorEvent.EventId);
            ViewBag.VisitorId = new SelectList(db.Visitor, "VisitorId", "VisitorEntryDate", visitorEvent.VisitorId);
            return View(visitorEvent);
        }

        // POST: VisitorEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitorId,EventId")] VisitorEvent visitorEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitorEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Event, "EventId", "EventName", visitorEvent.EventId);
            ViewBag.VisitorId = new SelectList(db.Visitor, "VisitorId", "VisitorEntryDate", visitorEvent.VisitorId);
            return View(visitorEvent);
        }

        // GET: VisitorEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorEvent visitorEvent = db.VisitorEvent.Find(id);
            if (visitorEvent == null)
            {
                return HttpNotFound();
            }
            return View(visitorEvent);
        }

        // POST: VisitorEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitorEvent visitorEvent = db.VisitorEvent.Find(id);
            db.VisitorEvent.Remove(visitorEvent);
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
