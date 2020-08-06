using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Boolean SaveProduct(Product product);
        Boolean UpdateProduct(int id, Product product);
        Boolean DeleteProduct(int id);
    }
}
