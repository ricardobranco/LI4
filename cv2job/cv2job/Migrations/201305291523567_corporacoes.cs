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
            
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID", c => c.Int());
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID1", c => c.Int());
            AddColumn("dbo.Anuncios", "Corporacao_CorpID", c => c.Int());
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID1");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID1" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID" });
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes");
            DropColumn("dbo.Anuncios", "Corporacao_CorpID");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID1");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID");
            DropTable("dbo.Corporacoes");
        }
    }
}
