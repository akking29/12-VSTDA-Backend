using FullStackToDo.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FullStackToDo.API.Data
{
    //1.create class that inherits from DbContext
    public class FullStackToDoDataContext : DbContext 
    {
        //2.setup constructor
        public FullStackToDoDataContext() : base ("FullStackToDo")
        {

        }
        //3.describe tables
        public IDbSet<ToDoTask> ToDoTasks { get; set; }
    }
}