using FurnitureSolutions.Models;
using FurnitureSolutions.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FunritureSolutions.WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            OrderService orderService = CreateOrderService();
            var order = orderService.GetOrders();
            return Ok(order);
        }

        public IHttpActionResult Get(int id)
        {
            OrderService OrderService = CreateOrderService();
            var order = OrderService.GetOrderById(id);
            return Ok(order);
        }

        public IHttpActionResult Post(OrderCreate order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (!service.CreateOrder(order))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(OrderEdit order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (!service.EditOrder(order))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateOrderService();

            if (!service.DeleteOrder(id))
                return InternalServerError();

            return Ok();
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderService = new OrderService(userId);
            return orderService;
        }
    }
}
