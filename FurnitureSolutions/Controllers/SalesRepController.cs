using FurnitureSolutions.Models;
using FurnitureSolutions.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureSolutions.Controllers
{
    public class SalesRepController : Controller
    {
        // GET: SalesRep
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesRepService(userId);
            var model = service.GetSalesRep();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesRepCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSalesRepService();

            if (service.CreateSalesRep(model))
            {
                TempData["SaveResult"] = "SalesRep was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "SalesRep could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSalesRepService();
            var model = svc.GetSalesRepById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateSalesRepService();
            var detail = service.GetSalesRepById(id);
            var model =
                new SalesRepEdit
                {
                    RepId = detail.RepId,
                    RepName = detail.RepName,
                    Territory = detail.Territory
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SalesRepEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RepId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSalesRepService();

            if (service.UpdateSalesRep(model))
            {
                TempData["SaveResult"] = "The SalesRep was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The SalesRep could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSalesRepService();
            var model = svc.GetSalesRepById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSalesRepService();

            service.DeleteSalesRep(id);

            TempData["SaveResult"] = "SalesRep was deleted";

            return RedirectToAction("Index");
        }
        private SalesRepService CreateSalesRepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesRepService(userId);
            return service;
        }
    }
}