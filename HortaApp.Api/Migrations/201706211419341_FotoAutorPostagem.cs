namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoAutorPostagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postagems", "FotoAutorPostagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postagems", "FotoAutorPostagem");
        }
    }
}
