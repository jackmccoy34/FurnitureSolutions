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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            var model = service.GetOrders();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOrderService();

            if (service.CreateOrder(model))
            {
                TempData["SaveResult"] = "Order was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Order not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateOrderService();
            var detail = service.GetOrderById(id);
            var model =
                new OrderEdit
                {
                    OrderId = detail.OrderId,
                    CustomerId = detail.CustomerId,
                    ProductId = detail.ProductId,
                    RepId = detail.RepId,
                    Quantity = detail.Quantity,
                    TotalPrice = detail.TotalPrice
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOrderService();

            if (service.EditOrder(model))
            {
                TempData["SaveResult"] = "Order was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Order could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(int id)
        {
            var service = CreateOrderService();

            service.DeleteOrder(id);

            TempData["SaveResult"] = "The Order was deleted";

            return RedirectToAction("Index");
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }
    }
}