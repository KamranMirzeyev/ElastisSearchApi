using Core;
using Core.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private IProductRepository _productRepository;
        public IProductRepository Product => _productRepository ?? new ProductRpository(context);

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }
        public async Task<int> CommitAsync()
        {
            
            return await context.SaveChangesAsync();

        }
    }
}