namespace eGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vencedors",
                c => new
                    {
                        VencedorId = c.Int(nullable: false, identity: true),
                        PartidaId = c.Int(),
                        TimeId = c.Int(),
                    })
                .PrimaryKey(t => t.VencedorId)
                .ForeignKey("dbo.Partidas", t => t.PartidaId)
                .ForeignKey("dbo.Times", t => t.TimeId)
                .Index(t => t.PartidaId)
                .Index(t => t.TimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vencedors", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Vencedors", "PartidaId", "dbo.Partidas");
            DropIndex("dbo.Vencedors", new[] { "TimeId" });
            DropIndex("dbo.Vencedors", new[] { "PartidaId" });
            DropTable("dbo.Vencedors");
        }
    }
}
