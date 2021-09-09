using CrudDapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudDapper.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Student>("ViewStudent",null));
        }

        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters para = new DynamicParameters();
                para.Add("@Id", id);
                return View(DapperORM.ReturnList<Student>("ViewStudentById",para).FirstOrDefault<Student>());
            }
                


        }
        [HttpPost]
        public ActionResult AddOrEdit(Student student)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", student.Id);
            parameters.Add("@Name", student.Name);
            parameters.Add("@Gender", student.Gender);
            parameters.Add("@Salary", student.Salary);
            parameters.Add("@Age", student.Age);
            DapperORM.Executewithoutreturn("StudentAddEdit", parameters);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("@Id", id);
            DapperORM.Executewithoutreturn("DeleteStudentById", para);
            return RedirectToAction("Index");
        }
    }
}