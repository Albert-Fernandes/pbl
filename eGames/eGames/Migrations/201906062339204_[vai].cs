namespace eGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vai : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Times", "PartidaId", "dbo.Partidas");
            DropIndex("dbo.Times", new[] { "PartidaId" });
            CreateTable(
                "dbo.Time_Partida",
                c => new
                    {
                        Time_PartidaId = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(),
                        PartidaId = c.Int(),
                    })
                .PrimaryKey(t => t.Time_PartidaId)
                .ForeignKey("dbo.Partidas", t => t.PartidaId)
                .ForeignKey("dbo.Times", t => t.TimeId)
                .Index(t => t.TimeId)
                .Index(t => t.PartidaId);
            
            DropColumn("dbo.Times", "PartidaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Times", "PartidaId", c => c.Int());
            DropForeignKey("dbo.Time_Partida", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Time_Partida", "PartidaId", "dbo.Partidas");
            DropIndex("dbo.Time_Partida", new[] { "PartidaId" });
            DropIndex("dbo.Time_Partida", new[] { "TimeId" });
            DropTable("dbo.Time_Partida");
            CreateIndex("dbo.Times", "PartidaId");
            AddForeignKey("dbo.Times", "PartidaId", "dbo.Partidas", "PartidaId");
        }
    }
}
