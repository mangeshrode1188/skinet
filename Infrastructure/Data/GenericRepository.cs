using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{


    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return  _context.Set<T>().            
            ToList();
        }

    public IQueryable <T> ApplySpecification( ISpecification <T> spec){

         return   SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);

    }

     public   async Task<T> GetEntityWithSpecs(ISpecification<T> spec)
        {
            return await ApplySpecification (spec).FirstOrDefaultAsync();
        }

    public  async  Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }
    }
}