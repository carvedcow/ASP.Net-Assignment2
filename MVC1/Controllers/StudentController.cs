using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class StudentController : Controller
    {

        
        // GET: Student
        public ActionResult Index()
        {
            //MvcApplication.studentsList.Clear();

            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 1, StudentName = "Dan", Age = 18 });
            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 2, StudentName = "Calin", Age = 28 });

            return View(MvcApplication.studentsList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MVC1.Models.Student student)
        {
            try
            {
                // TODO: Add insert logic here
                student.StudentId = ++ MvcApplication.globalStudentId;
                MvcApplication.studentsList.Add(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var selectedStud = MvcApplication.studentsList.Single(s => s.StudentId == id);

            return View(selectedStud);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var selectedStud = MvcApplication.studentsList.Single(s => s.StudentId == id);
                selectedStud.StudentName = collection["StudentName"];
                selectedStud.Age = int.Parse(collection["Age"]);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var selectedStud = MvcApplication.studentsList.Single(s => s.StudentId == id);
            return View(selectedStud);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var selectedStud = MvcApplication.studentsList.Single(s => s.StudentId == id);
                MvcApplication.studentsList.Remove(selectedStud);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
