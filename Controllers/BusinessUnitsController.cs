using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team11.DAL;
using MIS4200Team11.Models;

namespace MIS4200Team11.Controllers
{
    public class BusinessUnitsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: BusinessUnits
        public ActionResult Index()
        {
            return View(db.BusinessUnit.ToList());
        }

        // GET: BusinessUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessUnit businessUnit = db.BusinessUnit.Find(id);
            if (businessUnit == null)
            {
                return HttpNotFound();
            }
            return View(businessUnit);
        }

        // GET: BusinessUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "unitID,businessUnit")] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                db.BusinessUnit.Add(businessUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessUnit);
        }

        // GET: BusinessUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessUnit businessUnit = db.BusinessUnit.Find(id);
            if (businessUnit == null)
            {
                return HttpNotFound();
            }
            return View(businessUnit);
        }

        // POST: BusinessUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "unitID,businessUnit")] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessUnit);
        }

        // GET: BusinessUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessUnit businessUnit = db.BusinessUnit.Find(id);
            if (businessUnit == null)
            {
                return HttpNotFound();
            }
            return View(businessUnit);
        }

        // POST: BusinessUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessUnit businessUnit = db.BusinessUnit.Find(id);
            db.BusinessUnit.Remove(businessUnit);
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
