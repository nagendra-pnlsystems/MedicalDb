using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalDb.Models;

namespace MedicalDb.Controllers
{
    public class AdminController : Controller
    {
        private medicaldbEntities db = new medicaldbEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult ViewUsers()
        {
            var allusers = context.Users.ToList();
            List<ApplicationUser> formattedusers = new List<ApplicationUser>();
            foreach (ApplicationUser auser in allusers)
            {
                var newuser = new ApplicationUser();
                newuser.Id = auser.Id;


                newuser.Email = auser.Email;


                newuser.UserName = auser.UserName;

                formattedusers.Add(newuser);
            }

            return View(formattedusers);
        }
        public ActionResult DeleteUser(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return RedirectToAction("ViewUsers");
            }
            try
            {
                var users = context.Users.ToList();
                var user = users.Find(u => u.Id == userid);
                context.Users.Remove(user);
                context.SaveChanges();
                return RedirectToAction("ViewUsers");
            }
            catch (Exception exp)
            {
                ViewBag.Message = exp.Message;
            }
            return View();
        }

        // GET: GrossSalaries
        public ActionResult GrossSalary()
        {
            return View(db.grosssalaries.ToList());
        }



        // GET: GrossSalaries/Create
        public ActionResult CreateGrossSalary()
        {
            return View();
        }

        // POST: GrossSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGrossSalary([Bind(Include = "Sid,Value")] grosssalary grossSalary)
        {
            if (ModelState.IsValid)
            {
                db.grosssalaries.Add(grossSalary);
                db.SaveChanges();
                return RedirectToAction("GrossSalary");
            }

            return View(grossSalary);
        }

        // GET: GrossSalaries/Edit/5
        public ActionResult EditGrossSalary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grosssalary grossSalary = db.grosssalaries.Find(id);
            if (grossSalary == null)
            {
                return HttpNotFound();
            }
            return View(grossSalary);
        }

        // POST: GrossSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGrossSalary([Bind(Include = "Sid,Value")] grosssalary grossSalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grossSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GrossSalary");
            }
            return View(grossSalary);
        }

        // GET: GrossSalaries/Delete/5
        public ActionResult DeleteGrossSalary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grosssalary grossSalary = db.grosssalaries.Find(id);
            if (grossSalary == null)
            {
                return HttpNotFound();
            }
            return View(grossSalary);
        }

        // POST: GrossSalaries/Delete/5
        [HttpPost, ActionName("DeleteGrossSalary")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grosssalary grossSalary = db.grosssalaries.Find(id);
            db.grosssalaries.Remove(grossSalary);
            db.SaveChanges();
            return RedirectToAction("GrossSalary");
        }
        public ActionResult Relationship()
        {
            return View(db.relationships.ToList());
        }
        // GET: Relationships/Create
        public ActionResult CreateRelationship()
        {
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRelationship([Bind(Include = "Rid,RelationName")] relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.relationships.Add(relationship);
                db.SaveChanges();
                return RedirectToAction("Relationship");
            }

            return View(relationship);
        }

        // GET: Relationships/Edit/5
        public ActionResult EditRelationship(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relationship relationship = db.relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRelationship([Bind(Include = "Rid,RelationName")] relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Relationship");
            }
            return View(relationship);
        }

        // GET: Relationships/Delete/5
        public ActionResult DeleteRelationship(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relationship relationship = db.relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("DeleteRelationship")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRelationshipConfirmed(int id)
        {
            relationship relationship = db.relationships.Find(id);
            db.relationships.Remove(relationship);
            db.SaveChanges();
            return RedirectToAction("Relationship");
        }

        //Visa_Category
        public ActionResult Visa_Category()
        {
            return View(db.visa_category.ToList());
        }
        // GET: Visa_Category/Create
        public ActionResult Create_Visa_Category()
        {
            return View();
        }

        // POST: Visa_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Visa_Category([Bind(Include = "visacategory_id,Name")] visa_category visa_category)
        {
            if (ModelState.IsValid)
            {
                db.visa_category.Add(visa_category);
                db.SaveChanges();
                return RedirectToAction("Visa_Category");
            }

            return View(visa_category);
        }

        // GET: Visa_Category/Edit/5
        public ActionResult Edit_Visa_Category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visa_category visa_category = db.visa_category.Find(id);
            if (visa_category == null)
            {
                return HttpNotFound();
            }
            return View(visa_category);
        }

        // POST: Visa_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Visa_Category([Bind(Include = "visacategory_id,Name")] visa_category visa_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visa_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Visa_Category");
            }
            return View(visa_category);
        }

        // GET: Visa_Category/Delete/5
        public ActionResult Delete_Visa_Category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visa_category visa_category = db.visa_category.Find(id);
            if (visa_category == null)
            {
                return HttpNotFound();
            }
            return View(visa_category);
        }

        // POST: Visa_Category/Delete/5
        [HttpPost, ActionName("Delete_Visa_Category")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Visa_Category_Confirmed(int id)
        {
            visa_category visa_category = db.visa_category.Find(id);
            db.visa_category.Remove(visa_category);
            db.SaveChanges();
            return RedirectToAction("Visa_Category");
        }
        //ends Visa_Category
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