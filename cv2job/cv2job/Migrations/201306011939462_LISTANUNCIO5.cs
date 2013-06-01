namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "Cargo", c => c.String(nullable: false));
            AddColumn("dbo.Anuncios", "Descricao", c => c.String());
            AddColumn("dbo.Anuncios", "Funcao", c => c.String());
            DropColumn("dbo.Anuncios", "Titulo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncios", "Titulo", c => c.String(nullable: false));
            DropColumn("dbo.Anuncios", "Funcao");
            DropColumn("dbo.Anuncios", "Descricao");
            DropColumn("dbo.Anuncios", "Cargo");
        }
    }
}
