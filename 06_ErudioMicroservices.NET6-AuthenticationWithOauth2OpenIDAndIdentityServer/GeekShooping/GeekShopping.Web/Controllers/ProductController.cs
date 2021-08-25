using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var products = await _productService.FindAllProducts(accessToken);
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model, accessToken);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, accessToken);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model, accessToken);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
}
            return View(model);
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, accessToken);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductById(model.Id, accessToken);
            if (response) return RedirectToAction(
                    nameof(ProductIndex));
            return View(model);
        }
    }
}