using System.ComponentModel.DataAnnotations;

namespace HortaApp.Web.Models.ViewModels
{
    public class PerfilViewModel
    {
        
        [Display(Name = "Id")]
        public int PerfilUsuarioId { get; set; }


        [Display(Name = "UsuarioId")]
        public string Usuarioid { get; set; }

        [Required]
        [Display(Name = "Nome do usuário")]
        public string NomeUsuario { get; set; }

        [Required]
        [Display(Name = "Foto de perfil")]
        public string FotoPerfil { get; set; }
    }
}