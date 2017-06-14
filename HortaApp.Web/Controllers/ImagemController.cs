using HortaApp.Web.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HortaApp.Web.Controllers
{
    public class ImagemController : Controller
    {
        private HttpClient _client;

        public ImagemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63632/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        ImageService imageService = new ImageService();

        // GET: Imagem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo)
        {
            var imageUrl = await imageService.UploadImageAsync(photo);


            var idusuario = Session["idUsuario"].ToString();
            var emailUsuario = Session["EmailUsuario"].ToString();
            var foto = imageUrl.ToString();

            var uri = "api/Imagems/Create?idUsuario=" + idusuario + "&emailUsuario=" + emailUsuario + "&foto=" + foto;

            var response = await _client.GetAsync(uri);




            return RedirectToAction("LatestImage");
        }
    }
}