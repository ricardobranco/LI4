namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mENSAGem2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensagems", "Utilizador_UserId", "dbo.Utilizadores");
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UserId" });
            DropColumn("dbo.Mensagems", "Utilizador_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagems", "Utilizador_UserId", c => c.Int());
            CreateIndex("dbo.Mensagems", "Utilizador_UserId");
            AddForeignKey("dbo.Mensagems", "Utilizador_UserId", "dbo.Utilizadores", "UserId");
        }
    }
}
