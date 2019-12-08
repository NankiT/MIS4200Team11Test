using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team11.DAL;
using MIS4200Team11.Models;

namespace MIS4200Team11.Controllers
{
    public class UserDatasController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: UserDatas
        public ActionResult Index(string searchString)
        {
            var testusers = from u in db.UserData select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                testusers = testusers.Where(u => u.lastName.Contains(searchString) || u.firstName.Contains(searchString));
                return View(testusers.ToList());
            }
            return View(db.UserData.ToList());
            
        }

        public ActionResult Leaderboard(string searchString)
        {
            var testusers = from u in db.UserData select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                testusers = testusers.Where(u => u.lastName.Contains(searchString) || u.firstName.Contains(searchString));
                return View(testusers.ToList());
            }
            return View(db.UserData.ToList().OrderByDescending(a => a.recCounter));

        }
        // GET: UserDatas/Details/5

        public ActionResult Details(Guid? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //this part only lets users see details aboout themselves
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);

            //change memberID to id to allow details on index page to view individual account details
            UserData userData = db.UserData.Find(memberID);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: UserDatas/Create
        public ActionResult Create()
        {
            ViewBag.unitID = new SelectList(db.BusinessUnit, "unitID", "businessUnit");
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,firstName,lastName,hireDate,title,unitID,recCounter")] UserData userData)
        {
            {
                if (ModelState.IsValid)
                {
                    Guid memberID;
                    Guid.TryParse(User.Identity.GetUserId(), out memberID);
                    userData.userID = memberID;
                    userData.recCounter = 0;
                    db.UserData.Add(userData);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }

                ViewBag.unitID = new SelectList(db.BusinessUnit, "unitID", "businessUnit", userData.unitID);
                return View(userData);
            }

        }

        // GET: UserDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            ViewBag.unitID = new SelectList(db.BusinessUnit, "unitID", "businessUnit", userData.unitID);
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,firstName,lastName,hireDate,title,unitID,recCounter")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.unitID = new SelectList(db.BusinessUnit, "unitID", "businessUnit", userData.unitID);
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserData userData = db.UserData.Find(id);
            db.UserData.Remove(userData);
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
