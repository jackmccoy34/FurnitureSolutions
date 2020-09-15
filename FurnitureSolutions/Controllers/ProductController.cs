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
    /* [Authorize]*/
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            service.CreateProduct(model);

            return RedirectToAction("Index");
        }
    }
}