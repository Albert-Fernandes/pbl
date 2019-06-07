namespace eGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partidas", "TimeVencedor", c => c.String());
            DropColumn("dbo.Times", "IsVencedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Times", "IsVencedor", c => c.Boolean(nullable: false));
            DropColumn("dbo.Partidas", "TimeVencedor");
        }
    }
}
