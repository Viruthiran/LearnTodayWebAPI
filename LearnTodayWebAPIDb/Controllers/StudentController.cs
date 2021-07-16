using LearnTodayWebAPIDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPIDb.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
            {
                return dbEntities.Courses.ToList();
            }
        }
        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody] Student student)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
                {
                    dbEntities.Students.Add(student);
                    dbEntities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, student);
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteStudentEnrollment(int id)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
                {
                    var enity = dbEntities.Students.FirstOrDefault(s => s.StudentId == id);
                    if(enity == null )
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No enrollement information found");
                    }
                    else
                    {
                        dbEntities.Students.Remove(enity);
                        dbEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
