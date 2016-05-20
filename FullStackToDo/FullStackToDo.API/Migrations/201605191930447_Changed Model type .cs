namespace FullStackToDo.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModeltype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "Priority", c => c.Int(nullable: false));
            DropColumn("dbo.ToDoTasks", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoTasks", "Text", c => c.String());
            DropColumn("dbo.ToDoTasks", "Priority");
        }
    }
}
