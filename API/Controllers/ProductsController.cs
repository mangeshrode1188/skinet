
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class     ProductsController:ControllerBase
    {
       private readonly IProductRepository _repo;
        
         public    ProductsController(IProductRepository repo)
        {
            this._repo= repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
          
          var products=  await  _repo.GetProducsAsync();

            return Ok(products);

        }

      [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _repo.GetProductByIdAsync(id);

        }


           [HttpGet ("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){
          
          var productsBrand =  await  _repo.GetProductBrandAsync();

            return Ok(productsBrand);

        }

        [HttpGet ("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
          
          var productType =  await  _repo.GetProductTypeAsync();

            return Ok(productType);

        }
    }
}