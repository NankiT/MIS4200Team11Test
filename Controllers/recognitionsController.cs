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
using Microsoft.AspNet.Identity;


namespace MIS4200Team11.Controllers
{
    public class recognitionsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: recognitions
        public ActionResult Index()
        {
            var recognitions = db.Recognitions.Include(r => r.CoreValues).Include(r => r.UserData);

            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
                
            var rec = db.Recognitions.Where(r =>r.userID == memberID);
            return View(recognitions.ToList().OrderByDescending(a=>a.recognitionDate));
        }

        public ActionResult Leaderboard()
        {
            var recognitions = db.Recognitions.Include(r => r.CoreValues).Include(r => r.UserData);

          Guid memberID;
          Guid.TryParse(User.Identity.GetUserId(), out memberID);

           var rec = db.Recognitions.Where(r => r.userID == memberID);
            return View(recognitions.ToList());
        }



        // GET: recognitions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: recognitions/Create
        public ActionResult Create()
        {
            ViewBag.valueId = new SelectList(db.CoreValues, "valueId", "valueName");
            string UserId = User.Identity.GetUserId();
            SelectList userList = new SelectList(db.UserData, "userID", "fullName");
            userList = new SelectList(userList.Where(x => x.Value != UserId).ToList(), "Value", "Text");
            ViewBag.userID = userList;
            return View();
        }

        // POST: recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,recognitionTitle,recognitionDescription,recognitionDate,userID,valueId")] recognition recognition)
        {
            if (ModelState.IsValid)
            {
                recognition.recognitionID = Guid.NewGuid();
                db.Recognitions.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.valueId = new SelectList(db.CoreValues, "valueId", "valueName", recognition.valueId);
            ViewBag.userID = new SelectList(db.UserData, "userID", "fullName", recognition.userID);
            return View(recognition);
        }

        // GET: recognitions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.valueId = new SelectList(db.CoreValues, "valueId", "valueName", recognition.valueId);
            ViewBag.userID = new SelectList(db.UserData, "userID", "firstName", recognition.userID);
            return View(recognition);
        }

        // POST: recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,recognitionTitle,recognitionDescription,recognitionDate,userID,valueId")] recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.valueId = new SelectList(db.CoreValues, "valueId", "valueName", recognition.valueId);
            ViewBag.userID = new SelectList(db.UserData, "userID", "fullName", recognition.userID);
            return View(recognition);
        }

        // GET: recognitions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            recognition recognition = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognition);
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
