namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corporacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Corporacoes",
                c => new
                    {
                        CorpID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CorpID);
            
            AddColumn("dbo.Utilizadores", "Corporcao_CorpID", c => c.Int());
            AddColumn("dbo.Utilizadores", "Corporcao_CorpID1", c => c.Int());
            AddColumn("dbo.Anuncios", "Corporcao_CorpID", c => c.Int());
            AddForeignKey("dbo.Utilizadores", "Corporcao_CorpID", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporcao_CorpID1", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Anuncios", "Corporcao_CorpID", "dbo.Corporacoes", "CorpID");
            CreateIndex("dbo.Utilizadores", "Corporcao_CorpID");
            CreateIndex("dbo.Utilizadores", "Corporcao_CorpID1");
            CreateIndex("dbo.Anuncios", "Corporcao_CorpID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "Corporcao_CorpID" });
            DropIndex("dbo.Utilizadores", new[] { "Corporcao_CorpID1" });
            DropIndex("dbo.Utilizadores", new[] { "Corporcao_CorpID" });
            DropForeignKey("dbo.Anuncios", "Corporcao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporcao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporcao_CorpID", "dbo.Corporacoes");
            DropColumn("dbo.Anuncios", "Corporcao_CorpID");
            DropColumn("dbo.Utilizadores", "Corporcao_CorpID1");
            DropColumn("dbo.Utilizadores", "Corporcao_CorpID");
            DropTable("dbo.Corporacoes");
        }
    }
}
