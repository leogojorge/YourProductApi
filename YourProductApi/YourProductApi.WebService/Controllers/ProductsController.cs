using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourProductApi.Application;
using YourProductApi.Application.Models.Request;
using YourProductApi.Application.Models.Response;

namespace YourProductApi.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly ISaveProductServices saveProductServices;
        private readonly IGetProductServices getProductServices;

        public ProductsController(ISaveProductServices saveProductServices, IGetProductServices getProductServices)
        {
            this.saveProductServices = saveProductServices;
            this.getProductServices = getProductServices;
        }
        //("pageNumber/{pageNumber}", Name = "paging")
        [HttpGet]
        public GetProductsByPagingResponse Get(int pageNumber, string fields)
        {
            try
            {
                var productPerPageResponse = getProductServices.GetProductsByPaging(pageNumber, fields);

                if (!string.IsNullOrEmpty(productPerPageResponse.Error))
                    return productPerPageResponse;

                if (productPerPageResponse.ProductResponse == null)
                {
                    productPerPageResponse.Error = "Products not found";
                    return productPerPageResponse;
                }

                return productPerPageResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public GetProductResponse Get(string id)
        {
            try
            {
                var productResponse = getProductServices.GetProductsById(id);

                return productResponse;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]SaveProductRequest product)
        {
            try
            {
                var response = saveProductServices.SaveProduct(product);

                if (response.Id == null)
                    return BadRequest(response);

                return Created(HttpContext.Request.Host + "/api/products/" + response.Id,response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UpdateProductRequest productToUpdate)
        {
            UpdateProductResponse updateResponse;
            try
            {
                updateResponse = saveProductServices.UpdateProduct(id, productToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (updateResponse.Id == null)
                return BadRequest(updateResponse.ErrorMessages);

            return Ok(updateResponse.Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            DeleteProductResponse deleteResponse;
            try
            {
                deleteResponse = saveProductServices.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (!string.IsNullOrEmpty(deleteResponse.ErrorMessage))
                return BadRequest(deleteResponse.ErrorMessage);

            return Ok();
        }
    }
}
