using LearnTodayWebAPIDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPIDb.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            using( LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
            {
                return dbEntities.Courses.ToList();
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCourseById(int id)
        {
            using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
            {
                var entity = dbEntities.Courses.FirstOrDefault(s => s.CourseId == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }
    }
}
