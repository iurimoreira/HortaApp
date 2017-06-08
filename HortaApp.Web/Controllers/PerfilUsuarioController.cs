using HortaApp.Domain;
using HortaApp.Web.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> Details(string id)
        {
            var uriparameter = "api/PerfilUsuario/PerfilExiste?id=" + id;
            var response = await _client.GetAsync(uriparameter);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                var perfilUsuario = JsonConvert.DeserializeObject<List<PerfilViewModel>>    (JsonString);

                return View(perfilUsuario[0]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: PerfilUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUsuario/Create
        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PerfilViewModel model)
        {
            model.Usuarioid = Session["idUsuario"].ToString();
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync("api/PerfilUsuario/CriarPerfilUsuario", model);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: PerfilUsuario/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var uriparameter = "api/PerfilUsuario/PerfilExiste?id=" + id;
            var response = await _client.GetAsync(uriparameter);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                var perfilUsuario = JsonConvert.DeserializeObject<List<PerfilViewModel>>(JsonString);

                return View(perfilUsuario[0]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PerfilUsuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PerfilViewModel model)
        {
            var response = await _client.PostAsJsonAsync("api/PerfilUsuario/AtualizarPerfilUsuario", model);

            return RedirectToAction("Details", "PerfilUsuario", new { id = model.Usuarioid });
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
