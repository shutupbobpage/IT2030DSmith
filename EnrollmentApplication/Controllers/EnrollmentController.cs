﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnrollmentApplication.Models;

namespace EnrollmentApplication.Controllers
{
    public class EnrollmentController : Controller
    {
        private EnrollmentDB db = new EnrollmentDB();

        public ActionResult CourseSearch(string q)
        {
            var courses = GetCourses(q);
            return PartialView("_CourseSearch", courses);
        }

        private List<Course> GetCourses(string searchString)
        {
            return db.Courses
                .Where(a => a.CourseTitle.Contains(searchString) || a.CourseDescription.Contains(searchString))
                .ToList();
        }

        public ActionResult StudentSearch(string q)
        {
            var students = GetStudents(q);
            return PartialView("_StudentSearch", students);
        }

        private List<Student> GetStudents(string searchString)
        {
            return db.Students
                .Where(a => a.StudentFirstName.Contains(searchString) || a.StudentLastName.Contains(searchString))
                .ToList();
        }



        // GET: Enrollment
        public ActionResult Index()
        {
       
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseTitle");
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentLastName");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
           

            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentID);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentID);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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
