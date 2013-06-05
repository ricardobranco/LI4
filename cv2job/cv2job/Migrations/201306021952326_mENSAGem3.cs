namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mENSAGem3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagems", "Emissor_UserId", c => c.Int());
            AddColumn("dbo.Mensagems", "Receptor_UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Mensagems", "Emissor_UserId", "dbo.Utilizadores", "UserId");
            AddForeignKey("dbo.Mensagems", "Receptor_UserId", "dbo.Utilizadores", "UserId", cascadeDelete: true);
            CreateIndex("dbo.Mensagems", "Emissor_UserId");
            CreateIndex("dbo.Mensagems", "Receptor_UserId");
            DropColumn("dbo.Mensagems", "EmissorID");
            DropColumn("dbo.Mensagems", "ReceptorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagems", "ReceptorID", c => c.Int(nullable: false));
            AddColumn("dbo.Mensagems", "EmissorID", c => c.Int(nullable: false));
            DropIndex("dbo.Mensagems", new[] { "Receptor_UserId" });
            DropIndex("dbo.Mensagems", new[] { "Emissor_UserId" });
            DropForeignKey("dbo.Mensagems", "Receptor_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Mensagems", "Emissor_UserId", "dbo.Utilizadores");
            DropColumn("dbo.Mensagems", "Receptor_UserId");
            DropColumn("dbo.Mensagems", "Emissor_UserId");
        }
    }
}
