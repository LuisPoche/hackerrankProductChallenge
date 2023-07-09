﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrderApi.Data.Entities;
using ProductOrderApi.Helpers;
using ProductOrderApi.Services;

namespace ProductOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          var product = await   _productService.GetProduct(id);
          if(product== null)
          return NotFound();
           return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
                      return Ok(await   _productService.AddProduct(product));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
           var productDb = await   _productService.GetProduct(id);
          if(productDb== null)
          return NotFound();
          if(id != productDb.Id)
          return BadRequest();
                       return Ok(await   _productService.UpdateProduct(product));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
           var productDb = await   _productService.GetProduct(id);
          if(productDb== null)
          return NotFound();
          await   _productService.DeleteProduct(id);
             return NoContent();

        }       
    }
}
