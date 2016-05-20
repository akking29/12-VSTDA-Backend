namespace FullStackToDo.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RidDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ToDoTasks", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoTasks", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
