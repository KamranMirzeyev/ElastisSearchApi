using Core.Repositories;
using Core.Models;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRpository :Repository<Product>, IProductRepository
    {
        private DataContext _context => Context as DataContext;
        public ProductRpository(DataContext context):base(context)
        {
            
        }

        public Product FindId(long id)
        {
           
            return _context.Products.Find(id);

        }
    }
}