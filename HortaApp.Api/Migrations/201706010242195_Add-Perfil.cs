namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPerfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerfilUsuarios",
                c => new
                    {
                        PerfilUsuarioId = c.Int(nullable: false, identity: true),
                        Usuarioid = c.String(),
                        NomeUsuario = c.String(),
                        FotoPerfil = c.String(),
                    })
                .PrimaryKey(t => t.PerfilUsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PerfilUsuarios");
        }
    }
}
