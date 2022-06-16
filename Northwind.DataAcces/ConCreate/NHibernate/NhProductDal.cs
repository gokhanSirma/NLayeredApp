using Northwind.DataAcces.ConCreate.EntityFramework;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcces.ConCreate.NHibernate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product product)
        {
            
        }

        public void Delete(Product product)
        {
            
        }

      

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{ProductID=1,
                    CategoryID =1,
                    ProductName ="kaşık",
                    QuantityPerUnit ="6 in a box",UnitPrice=120,UnitsInStock=23
                }
            };
            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
