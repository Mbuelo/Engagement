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
    public class IndividualsController : Controller
    {
        private AgapeDBContext db = new AgapeDBContext();
        DateTime dt = DateTime.Now;

        //GET: SearchIndividuals
        public ActionResult Index(string searchBy, string search)
        {
            switch (searchBy)
            {
                case "Name":
                    return View(db.Individual.Where(x => x.IndividualName.Contains(search) || search == null).ToList());
                case "Surname":
                    return View(db.Individual.Where(x => x.IndividualLastName.Contains(search) || search == null).ToList());
                    //todo: .include to include group
                default:
                    return View(db.Individual.ToList());

            }

        }

        // GET: Individuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = db.Individual.Find(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            return View(individual);
        }

        // GET: Individuals/Create
        public ActionResult Create()
        {
            ViewBag.Groups = db.Group;
            ViewBag.IndividualTitle = new SelectList(db.Title, "_Title", "_Title");
            ViewBag.IndividualLanguage = new SelectList(new List<string>()
                                           {"Sepedi",
                                            "Sesotho",
                                            "Setswana",
                                            "siSwati",
                                            "Tshivenda",
                                            "Xitsonga",
                                            "Afrikaans",
                                            "English",
                                            "isiNdebele",
                                            "isiXhosa",
                                            "isiZulu"
                                            });

            return View();
        }


        // POST: Individuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int[] GroupIds, [Bind(Include = "IndividualId,IndividualEntryDate,IndividualTitle,IndividualName,IndividualLastName,IndividualIDNumber,IndividualAddress,IndividualNumber,IndividualEmail,IndividualLanguage,IndividualBaptismalDate,IndividualStatus")] Individual individual)
        {
            if (ModelState.IsValid)
            {
                individual.IndividualEntryDate = dt.ToString("yyyy-MM-dd");
                individual.IndividualStatus = true;
                db.Individual.Add(individual);
                foreach (int grpId in GroupIds)
                {
                    IndividualGroup indiGroup = new IndividualGroup();
                    indiGroup.GroupId = grpId;
                    indiGroup.IndividualId = individual.IndividualId;
                    db.IndividualGroup.Add(indiGroup);
                    
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(individual);
        }

        // GET: Individuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = db.Individual.Find(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            ViewBag.Groups = db.Group;
            ViewBag.IndividualTitle = new SelectList(db.Title, "_Title", "_Title");
            ViewBag.IndividualLanguage = new SelectList(new List<string>()
                                           {"Sepedi",
                                            "Sesotho",
                                            "Setswana",
                                            "siSwati",
                                            "Tshivenda",
                                            "Xitsonga",
                                            "Afrikaans",
                                            "English",
                                            "isiNdebele",
                                            "isiXhosa",
                                            "isiZulu"
                                            });

            return View(individual);
        }

        // POST: Individuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int[] GroupIds, [Bind(Include = "IndividualId,IndividualTitle,IndividualName,IndividualLastName,IndividualEmail,IndividualNumber,IndividualAddress,IndividualLanguage")] Individual individual)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(individual).State = EntityState.Modified;
                foreach (int grpId in GroupIds)
                {
                    IndividualGroup indiGroup = new IndividualGroup();
                    indiGroup.GroupId = grpId;
                    indiGroup.IndividualId = individual.IndividualId;
                    //db.Entry(indiGroup).State = EntityState.Modified;
                   //db.SaveChanges();
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(individual);
        }

        // GET: Individuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = db.Individual.Find(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            return View(individual);
        }

        // POST: Individuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Individual individual = db.Individual.Find(id);
            db.Individual.Remove(individual);
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
