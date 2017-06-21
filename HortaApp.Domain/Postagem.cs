

namespace HortaApp.Domain
{
    public class Postagem
    {
        public int PostagemId { get; set; }

        public string Usuarioid { get; set; }

        //public string NomePerfilUsuario { get; set; }

        public string AutorPostagem { get; set; }

        public string FotoAutorPostagem { get; set; }

        public string Conteudo { get; set; }

        public string FotoPostagem { get; set; }
    }
}
