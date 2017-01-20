using System.Threading.Tasks;
using HelloWebApi.Repositories;

namespace HelloWebApi.UnitsOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveChangesAsync();
    }
}