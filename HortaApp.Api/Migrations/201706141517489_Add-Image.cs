namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imagems",
                c => new
                    {
                        ImagemId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(),
                        EmailUsuario = c.String(),
                        NomeImagem = c.String(),
                    })
                .PrimaryKey(t => t.ImagemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Imagems");
        }
    }
}
