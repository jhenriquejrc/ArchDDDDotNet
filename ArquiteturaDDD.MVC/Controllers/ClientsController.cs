using ArquiteturaDDD.Application;
using ArquiteturaDDD.Application.Interface;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArquiteturaDDD.MVC.Controllers
{
    public class ClientsController : Controller
       
    {
        private readonly IClientAppService _clientApp;
        public ClientsController(IClientAppService clientApp)
        {
            _clientApp = clientApp;
        }
        // GET: Clients
        public ActionResult Index()
        {
            var clientViewModel = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientApp.GetAll());
            return View(clientViewModel);
        }

        public ActionResult Specials()
        {
            var clientViewModel = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientApp.GetSpecialClients());
            return View(clientViewModel);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            if(ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
                _clientApp.Save(clientDomain);

                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
                _clientApp.Update(clientDomain);

                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var client = _clientApp.GetById(id);
            _clientApp.Delete(client);
            return RedirectToAction("Index");
        }
    }
}
