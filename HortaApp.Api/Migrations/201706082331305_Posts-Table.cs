namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postagems", "NomePerfilUsuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postagems", "NomePerfilUsuario");
        }
    }
}
