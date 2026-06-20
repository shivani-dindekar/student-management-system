using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
 using student_management_system.Data;

namespace student_management_system.Models
{
    public class Studentmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Fees is required")]
        public Nullable<int> Fees { get; set; }

        public string SaveStudent(Studentmodel model)
        {
            string Message = "submit";
            studentmanagementsystemEntities1 db = new studentmanagementsystemEntities1();
            var studentdata = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                Course = model.Course,
                Fees = model.Fees
            };
            db.Students.Add(studentdata);
            db.SaveChanges();

            return Message;
        }
        public static List<Studentmodel> GetStudents()
        {
            studentmanagementsystemEntities1 db = new studentmanagementsystemEntities1();

            var data = db.Students.Select(x => new Studentmodel
            {
                Id = x.Id,
                Name = x.Name,
                Course = x.Course,
                Fees = x.Fees
            }).ToList();

            return data;
        }
        public Studentmodel EditStudent(int id)
        {
            studentmanagementsystemEntities1 db = new studentmanagementsystemEntities1();

            var data = db.Students.Where(x => x.Id == id).FirstOrDefault();

            Studentmodel model = new Studentmodel();

            model.Id = data.Id;
            model.Name = data.Name;
            model.Course = data.Course;
            model.Fees = data.Fees;

            return model;
        }
        public string UpdateStudent(Studentmodel model)
        {
            string Message = "Updated Successfully";

            studentmanagementsystemEntities1 db = new studentmanagementsystemEntities1();

            var data = db.Students.Where(x => x.Id == model.Id).FirstOrDefault();

            data.Name = model.Name;
            data.Course = model.Course;
            data.Fees = model.Fees;

            db.SaveChanges();

            return Message;
        }
        public string DeleteStudent(int id)
        {
            studentmanagementsystemEntities1 db = new studentmanagementsystemEntities1();

            var data = db.Students.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return "Student Not Found";
            }

            db.Students.Remove(data);
            db.SaveChanges();

            return "Deleted Successfully";
        }
        
    }
}





