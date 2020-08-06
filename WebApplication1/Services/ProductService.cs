using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{

    public class ProductService : IProductService
    {
        List<Product> prodLst = new List<Product>()
        {
            new Product() { Id= 1, Name="Mobile", Price= 120.10 },
            new Product() { Id= 2, Name="Laptop", Price= 200},
            new Product() { Id= 3, Name="Watch", Price= 12.10 },
            new Product() { Id= 4, Name="Telivision", Price= 150.10 },
            new Product() { Id= 5, Name="Camera", Price= 80.10 }
        };

        public List<Product> GetAllProducts()
        {
            return prodLst;
        }

        public Product GetProductById(int id)
        {
            Product currProd = prodLst.Find(prd => prd.Id == id);
            return currProd;
        }

        public Boolean SaveProduct(Product product)
        {
            try
            {
                prodLst.Add(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean UpdateProduct(int id, Product product)
        {
            Product currPrd = prodLst.Find(prd => prd.Id == id);
            if (currPrd == null)
                return false;
            else
            {
                currPrd.Price = product.Price;
                currPrd.Name = product.Name;
                return true;
            }
        }

        public Boolean DeleteProduct(int id)
        {
            Product currPrd = prodLst.Find(prd => prd.Id == id);
            if (currPrd == null)
                return false;
            else
                return prodLst.Remove(currPrd);
        }

    }
}
