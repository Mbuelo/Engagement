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
    public class IndividualGroupsController : Controller
    {
        private AgapeDBContext db = new AgapeDBContext();

        // GET: IndividualGroups
        public ActionResult Index()
        {
            var individualGroup = db.IndividualGroup.Include(i => i.Group).Include(i => i.Individual);
            return View(individualGroup.ToList());
        }

        // GET: IndividualGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualGroup individualGroup = db.IndividualGroup.Find(id);
            if (individualGroup == null)
            {
                return HttpNotFound();
            }
            return View(individualGroup);
        }
        public ActionResult CreateIndividualGroups()
        {
            ViewBag.GroupId = new SelectList(db.Group, "GroupId", "GroupName");
            ViewBag.Individuals = db.Individual;
            return View();
        }

        [HttpPost]
        public ActionResult CreateIndividualGroups(int GroupId, int[] IndividualIds)
        {
            foreach (int indId in IndividualIds)
            {
                IndividualGroup indiGroup = new IndividualGroup();
                indiGroup.GroupId = GroupId;
                indiGroup.IndividualId = indId;
                db.IndividualGroup.Add(indiGroup);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: IndividualGroups/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Group, "GroupId", "GroupName");
            ViewBag.IndividualId = new SelectList(db.Individual, "IndividualId", "IndividualEntryDate");
            return View();
        }

        // POST: IndividualGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndividualId,GroupId")] IndividualGroup individualGroup)
        {
            if (ModelState.IsValid)
            {
                db.IndividualGroup.Add(individualGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Group, "GroupId", "GroupName", individualGroup.GroupId);
            ViewBag.IndividualId = new SelectList(db.Individual, "IndividualId", "IndividualEntryDate", individualGroup.IndividualId);
            return View(individualGroup);
        }

        // GET: IndividualGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualGroup individualGroup = db.IndividualGroup.Find(id);
            if (individualGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Group, "GroupId", "GroupName", individualGroup.GroupId);
            ViewBag.IndividualId = new SelectList(db.Individual, "IndividualId", "IndividualEntryDate", individualGroup.IndividualId);
            return View(individualGroup);
        }

        // POST: IndividualGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndividualId,GroupId")] IndividualGroup individualGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Group, "GroupId", "GroupName", individualGroup.GroupId);
            ViewBag.IndividualId = new SelectList(db.Individual, "IndividualId", "IndividualEntryDate", individualGroup.IndividualId);
            return View(individualGroup);
        }

        // GET: IndividualGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualGroup individualGroup = db.IndividualGroup.Find(id);
            if (individualGroup == null)
            {
                return HttpNotFound();
            }
            return View(individualGroup);
        }

        // POST: IndividualGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndividualGroup individualGroup = db.IndividualGroup.Find(id);
            db.IndividualGroup.Remove(individualGroup);
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
