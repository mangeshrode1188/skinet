
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class     ProductsController:ControllerBase
    {
       private readonly StoreContext _context;
        
         public    ProductsController(StoreContext context)
        {
            this._context=context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
          
          var products=   _context.Products.ToList();

            return products;

        }

      [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Products.FindAsync(id);

        }
    }
}