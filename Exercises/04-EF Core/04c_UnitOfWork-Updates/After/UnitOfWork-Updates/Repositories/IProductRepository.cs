using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Models;

namespace HelloWebApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task LoadCategory(Product product);
    }
}