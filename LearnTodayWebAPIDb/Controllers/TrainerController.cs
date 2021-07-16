using LearnTodayWebAPIDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPIDb.Controllers
{
    public class TrainerController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody] Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
                {
                    dbEntities.Trainers.Add(trainer);
                    dbEntities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, trainer);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id, [FromBody]Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities dbEntities = new LearnTodayWebAPIDbEntities())
                {
                    var entity = dbEntities.Trainers.FirstOrDefault(t => t.TrainerId == id);
                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
                    }
                    else
                    {
                        entity.Password = trainer.Password;
                        dbEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Data updated Successfully"); 
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
