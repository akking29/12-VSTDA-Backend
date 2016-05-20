namespace FullStackToDo.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTasktoText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "Text", c => c.String());
            DropColumn("dbo.ToDoTasks", "Task");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoTasks", "Task", c => c.String());
            DropColumn("dbo.ToDoTasks", "Text");
        }
    }
}
