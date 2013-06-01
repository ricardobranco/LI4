namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualicolinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilizadores",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Corporacao_CorpID = c.Int(),
                        Corporacao_CorpID1 = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Corporacoes", t => t.Corporacao_CorpID)
                .ForeignKey("dbo.Corporacoes", t => t.Corporacao_CorpID1)
                .Index(t => t.Corporacao_CorpID)
                .Index(t => t.Corporacao_CorpID1);
            
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        AnuncioID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        InfoAdiconal = c.String(),
                        TipoEmprego = c.String(),
                        eRenumerado = c.Boolean(nullable: false),
                        Renumeracao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Corporacao_CorpID = c.Int(),
                    })
                .PrimaryKey(t => t.AnuncioID)
                .ForeignKey("dbo.Corporacoes", t => t.Corporacao_CorpID)
                .Index(t => t.Corporacao_CorpID);
            
            CreateTable(
                "dbo.Corporacoes",
                c => new
                    {
                        CorpID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Sector = c.String(nullable: false),
                        Website = c.String(),
                        Pais = c.String(),
                        CodPostal = c.String(),
                        Morada = c.String(),
                        Cidade = c.String(),
                        Email = c.String(),
                        Contacto = c.String(),
                        PathLogo = c.String(),
                    })
                .PrimaryKey(t => t.CorpID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID1" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID" });
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes");
            DropTable("dbo.Corporacoes");
            DropTable("dbo.Anuncios");
            DropTable("dbo.Utilizadores");
        }
    }
}
