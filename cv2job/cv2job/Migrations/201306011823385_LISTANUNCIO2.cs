namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            AlterColumn("dbo.Anuncios", "Corporacao_CorpID", c => c.Int());
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            AlterColumn("dbo.Anuncios", "Corporacao_CorpID", c => c.Int(nullable: false));
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID", cascadeDelete: true);
        }
    }
}
