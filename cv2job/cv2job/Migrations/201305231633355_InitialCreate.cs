namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilizadores",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
                    })
                .PrimaryKey(t => t.AnuncioID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anuncios");
            DropTable("dbo.Utilizadores");
        }
    }
}
