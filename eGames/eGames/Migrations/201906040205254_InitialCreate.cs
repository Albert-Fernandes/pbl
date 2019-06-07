namespace eGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        JogadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Idade = c.Int(nullable: false),
                        Elo = c.String(),
                        TimeId = c.Int(),
                    })
                .PrimaryKey(t => t.JogadorId)
                .ForeignKey("dbo.Times", t => t.TimeId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Vitoria = c.Int(),
                        IsVencedor = c.Boolean(nullable: false),
                        PartidaId = c.Int(),
                    })
                .PrimaryKey(t => t.TimeId)
                .ForeignKey("dbo.Partidas", t => t.PartidaId)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        PartidaId = c.Int(nullable: false, identity: true),
                        Premiacao = c.String(),
                        TempoPartida = c.String(),
                    })
                .PrimaryKey(t => t.PartidaId);
            
            CreateTable(
                "dbo.Time_Patrocinador",
                c => new
                    {
                        Time_PatrocinadorId = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(),
                        PatrocinadorId = c.Int(),
                    })
                .PrimaryKey(t => t.Time_PatrocinadorId)
                .ForeignKey("dbo.Patrocinadors", t => t.PatrocinadorId)
                .ForeignKey("dbo.Times", t => t.TimeId)
                .Index(t => t.TimeId)
                .Index(t => t.PatrocinadorId);
            
            CreateTable(
                "dbo.Patrocinadors",
                c => new
                    {
                        PatrocinadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Especialidade = c.String(),
                    })
                .PrimaryKey(t => t.PatrocinadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Time_Patrocinador", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Time_Patrocinador", "PatrocinadorId", "dbo.Patrocinadors");
            DropForeignKey("dbo.Times", "PartidaId", "dbo.Partidas");
            DropForeignKey("dbo.Jogadors", "TimeId", "dbo.Times");
            DropIndex("dbo.Time_Patrocinador", new[] { "PatrocinadorId" });
            DropIndex("dbo.Time_Patrocinador", new[] { "TimeId" });
            DropIndex("dbo.Times", new[] { "PartidaId" });
            DropIndex("dbo.Jogadors", new[] { "TimeId" });
            DropTable("dbo.Patrocinadors");
            DropTable("dbo.Time_Patrocinador");
            DropTable("dbo.Partidas");
            DropTable("dbo.Times");
            DropTable("dbo.Jogadors");
        }
    }
}
