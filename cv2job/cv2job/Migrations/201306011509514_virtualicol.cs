namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualicol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID", c => c.Int());
            AddColumn("dbo.Utilizadores", "Corporacao_CorpID1", c => c.Int());
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
            AddForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes", "CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID");
            CreateIndex("dbo.Utilizadores", "Corporacao_CorpID1");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID1" });
            DropIndex("dbo.Utilizadores", new[] { "Corporacao_CorpID" });
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID1", "dbo.Corporacoes");
            DropForeignKey("dbo.Utilizadores", "Corporacao_CorpID", "dbo.Corporacoes");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID1");
            DropColumn("dbo.Utilizadores", "Corporacao_CorpID");
        }
    }
}
