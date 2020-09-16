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
    /*[Authorize]*/
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomer();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerName = detail.CustomerName,
                    Address = detail.Address,
                    Contact = detail.Contact
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.EditCustomer(model))
            {
                TempData["SaveResult"] = "The Customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Customer could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Customer was deleted";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}