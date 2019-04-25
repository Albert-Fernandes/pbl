namespace AppBalada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingressoes", "Cont", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingressoes", "Cont");
        }
    }
}
