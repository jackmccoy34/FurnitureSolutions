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
    public class ProductController : ApiController
    {
        /*[Authorize*/

        public IHttpActionResult Get()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetProducts();
            return Ok(products);
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }
    }
}
