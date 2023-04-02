using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithFilterForCountSpecification :BaseSpecifcation<Entities.Product>
    
    {
         public ProductsWithFilterForCountSpecification(ProductSpecParams productParams) : base(x =>
            
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }

    }
}