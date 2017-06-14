using System.ComponentModel.DataAnnotations;

namespace HortaApp.Domain
{
    public class Imagem
    {
        [Key]
        public int ImagemId { get; set; }

        public string UsuarioId { get; set; }

        public string EmailUsuario { get; set; }

        public string UrlImagem { get; set; }
    }
}
