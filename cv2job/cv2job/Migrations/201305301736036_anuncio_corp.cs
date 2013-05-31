namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncio_corp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Anuncios", name: "Corporacao_CorpID", newName: "Corporacao_CorpID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Anuncios", name: "Corporacao_CorpID", newName: "Corporacao_CorpID");
        }
    }
}
