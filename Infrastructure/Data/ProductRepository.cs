using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {

        private StoreContext _context;


        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return  await _context.Products.FindAsync(id);
        }
        
        public async Task<List<Product>> GetProducsAsync()
        {
            return   _context.Products.ToList();
        }

       public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
           return  await _context.ProductBrands.FindAsync(id);
        }

       public async  Task<List<ProductBrand>> GetProductBrandAsync()
        {
             return   _context.ProductBrands.ToList();
        }

       public async  Task<ProductType> GetProductTypeByIdAsync(int id)
        {
           return  await _context.ProductTypes.FindAsync(id);
        }

        public async   Task<List<ProductType>> GetProductTypeAsync()
        {
            return   _context.ProductTypes.ToList();
        }
    }
}

