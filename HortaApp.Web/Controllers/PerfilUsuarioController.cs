using HortaApp.Web.Models.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HortaApp.Web.Controllers
{
    public class PerfilUsuarioController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private HttpClient _client;

        public PerfilUsuarioController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63632/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        // GET: PerfilUsuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: PerfilUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerfilUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUsuario/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PerfilViewModel model)
        {
            model.Usuarioid = Session["idUsuario"].ToString();
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync("api/PerfilUsuario", model);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PerfilUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PerfilUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerfilUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
