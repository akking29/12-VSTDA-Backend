using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Description;
using FullStackToDo.API.Data;
using FullStackToDo.API.Models;

namespace FullStackToDo.API.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ToDoTasksController : ApiController
    {
        private FullStackToDoDataContext db = new FullStackToDoDataContext();

        // GET: api/ToDoTasks
        public IQueryable<ToDoTask> GetToDoTasks()
        {
            return db.ToDoTasks;
        }

        // GET: api/ToDoTasks/5
        [ResponseType(typeof(ToDoTask))]
        public IHttpActionResult GetToDoTask(int id)
        {
            ToDoTask toDoTask = db.ToDoTasks.Find(id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return Ok(toDoTask);
        }

        // PUT: api/ToDoTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDoTask(int id, ToDoTask toDoTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoTask.ToDoTaskId)
            {
                return BadRequest();
            }

            db.Entry(toDoTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ToDoTasks
        [ResponseType(typeof(ToDoTask))]
        public IHttpActionResult PostToDoTask(ToDoTask toDoTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoTasks.Add(toDoTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDoTask.ToDoTaskId }, toDoTask);
        }

        // DELETE: api/ToDoTasks/5
        [ResponseType(typeof(ToDoTask))]
        public IHttpActionResult DeleteToDoTask(int id)
        {
            ToDoTask toDoTask = db.ToDoTasks.Find(id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            db.ToDoTasks.Remove(toDoTask);
            db.SaveChanges();

            return Ok(toDoTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoTaskExists(int id)
        {
            return db.ToDoTasks.Count(e => e.ToDoTaskId == id) > 0;
        }
    }
}