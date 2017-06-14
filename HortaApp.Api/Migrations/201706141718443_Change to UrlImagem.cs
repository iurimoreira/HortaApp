namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetoUrlImagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagems", "UrlImagem", c => c.String());
            DropColumn("dbo.Imagems", "NomeImagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagems", "NomeImagem", c => c.String());
            DropColumn("dbo.Imagems", "UrlImagem");
        }
    }
}
