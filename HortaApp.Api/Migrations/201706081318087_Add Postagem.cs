namespace HortaApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postagems",
                c => new
                    {
                        PostagemId = c.Int(nullable: false, identity: true),
                        Usuarioid = c.String(),
                        Conteudo = c.String(),
                        FotoPostagem = c.String(),
                    })
                .PrimaryKey(t => t.PostagemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Postagems");
        }
    }
}
