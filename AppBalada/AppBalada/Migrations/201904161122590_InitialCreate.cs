namespace AppBalada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bilheterias",
                c => new
                    {
                        BilheteriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.BilheteriaId);
            
            CreateTable(
                "dbo.Ingressoes",
                c => new
                    {
                        IngressoId = c.Int(nullable: false, identity: true),
                        IsVip = c.Boolean(nullable: false),
                        PessoaId = c.Int(),
                        EventoId = c.Int(nullable: false),
                        BilheteriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngressoId)
                .ForeignKey("dbo.Bilheterias", t => t.BilheteriaId, cascadeDelete: true)
                .ForeignKey("dbo.Eventoes", t => t.EventoId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId)
                .Index(t => t.EventoId)
                .Index(t => t.BilheteriaId);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.String(),
                        Inicio = c.String(),
                        Fim = c.String(),
                        IsRestrito = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingressoes", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Ingressoes", "EventoId", "dbo.Eventoes");
            DropForeignKey("dbo.Ingressoes", "BilheteriaId", "dbo.Bilheterias");
            DropIndex("dbo.Ingressoes", new[] { "BilheteriaId" });
            DropIndex("dbo.Ingressoes", new[] { "EventoId" });
            DropIndex("dbo.Ingressoes", new[] { "PessoaId" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Eventoes");
            DropTable("dbo.Ingressoes");
            DropTable("dbo.Bilheterias");
        }
    }
}
