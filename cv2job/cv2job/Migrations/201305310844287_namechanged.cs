namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Utilizadores", "Corporcao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporcao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropIndex("dbo.Utilizadores", new[] { "Corporcao_CorpID" });
            DropIndex("dbo.Utilizadores", new[] { "Corporcao_CorpID1" });
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
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
            
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID", c => c.Int());
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID1", c => c.Int());
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID1");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
            DropColumn("dbo.Utilizadores", "Corporcao_CorpID");
            DropColumn("dbo.Utilizadores", "Corporcao_CorpID1");
            DropTable("dbo.Corporacoes");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Utilizadores", "Corporcao_CorpID1", c => c.Int());
            AddColumn("dbo.Utilizadores", "Corporcao_CorpID", c => c.Int());
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID1" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID" });
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID1");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID");
            DropTable("dbo.Corporacoes");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
            CreateIndex("dbo.Utilizadores", "Corporcao_CorpID1");
            CreateIndex("dbo.Utilizadores", "Corporcao_CorpID");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporcao_CorpID1", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporcao_CorpID", "dbo.Corporacoes", "CorpID");
        }
    }
}
