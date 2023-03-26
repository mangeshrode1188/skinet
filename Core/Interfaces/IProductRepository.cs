

using Core.Entities;


namespace Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id);
        public Task<List<Product>> GetProducsAsync();
        public Task<ProductBrand> GetProductBrandByIdAsync(int id);
        public Task<List<ProductBrand>> GetProductBrandAsync();

        public Task<ProductType> GetProductTypeByIdAsync(int id);
        public Task<List<ProductType>> GetProductTypeAsync();


    }
}