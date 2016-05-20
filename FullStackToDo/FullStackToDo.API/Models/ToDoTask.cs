using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackToDo.API.Models
{
    public class ToDoTask
    {
        //Primary key
        public int ToDoTaskId { get; set; }
        //foreign key *optional
        //user data
        public string Text { get; set; }
        public int Priority { get; set; }
    }
}