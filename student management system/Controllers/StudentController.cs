
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student_management_system.Models;


namespace student_management_system.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //public JsonResult Savestudent(Studentmodel model)
        //{
        //    string result = model.SaveStudent(model);

        //    return Json(new { Message = result }, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]


        public JsonResult Savestudent(Studentmodel model)
        {
            try
            {
                string result = model.SaveStudent(model);
                return Json(new { Message = result });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.ToString() });
            }
        }
        public ActionResult List(string search)
        {
            var students = Studentmodel.GetStudents();


if (!string.IsNullOrEmpty(search))
            {
                students = students
                            .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                            .ToList();
            }

            return View(students);

}

        public ActionResult Edit(int id)
        {
            Studentmodel model = new Studentmodel();

            var data = model.EditStudent(id);

            return View(data);
        }
        [HttpPost]

        public JsonResult UpdateStudent(Studentmodel model)
        {
            string result = model.UpdateStudent(model);

            return Json(new { Message = result });
        }
        [HttpPost]
       
        public JsonResult DeleteStudent(int id)
        {
            Studentmodel model = new Studentmodel();

            string result = model.DeleteStudent(id);

            return Json(new { Message = result });
        }

    }
}