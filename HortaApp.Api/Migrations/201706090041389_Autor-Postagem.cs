namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutorPostagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postagems", "AutorPostagem", c => c.String());
            DropColumn("dbo.Postagems", "NomePerfilUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Postagems", "NomePerfilUsuario", c => c.String());
            DropColumn("dbo.Postagems", "AutorPostagem");
        }
    }
}
