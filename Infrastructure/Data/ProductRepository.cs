using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return  await _context.Products
             .Include(p => p.ProductType)
            .Include(p => p.ProductBrand).
            FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task<IReadOnlyList<Product>> GetProducsAsync()
        {
            return   _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand).
            ToList();
        }

       public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
           return  await _context.ProductBrands.FindAsync(id);
        }

       public async  Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
             return   _context.ProductBrands.ToList();
        }

       public async  Task<ProductType> GetProductTypeByIdAsync(int id)
        {
           return  await _context.ProductTypes.FindAsync(id);
        }

        public async   Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return   _context.ProductTypes.ToList();
        }
    }
}

