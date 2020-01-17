using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_store.Models;
using book_store.Models.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers
{
    public class AutherController : Controller
    {
        // GET: Auther
        private readonly repositoriesInterface<Auther> autherrepository;

        // GET: auther
        public AutherController(repositoriesInterface<Auther> autherrepository)
        {
            this.autherrepository = autherrepository;
        }
        public ActionResult Index()
        {
            var authers = autherrepository.list();
            return View(authers);
        }

        // GET: auther/Details/5 Details page view
        public ActionResult Details(int id)
        {
            var authers = autherrepository.find(id);
            return View(authers);
        }

        // GET: auther/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: auther/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther auther)
        {
            try
            {
                autherrepository.add(auther);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: auther/Edit/5
        public ActionResult Edit(int id)
        {
            var auther = autherrepository.find(id);
            return View(auther);
        }

        // POST: auther/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther auther)
        {
            try
            {
                // TODO: Add update logic here
                autherrepository.update(id, auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: auther/Delete/5
        public ActionResult Delete(int id)
        {
            var auther = autherrepository.find(id);
            return View(auther);
        }

        // POST: auther/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auther auther)
        {
            try
            {
                // TODO: Add delete logic here
                autherrepository.delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}