
using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
       Product FindId(long id);
    }
}