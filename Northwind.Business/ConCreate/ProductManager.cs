using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.ConCreate.Validation.FluentValidation;
using Northwind.Business.Utilities;
using Northwind.DataAcces.ConCreate;
using Northwind.DataAcces.ConCreate.EntityFramework;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ConCreate
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validater(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            //business code
            return _productDal.GetAll();
        }

        public List<Product> GetBySearcText(string text)
        {

            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(text));
        }

        public List<Product> GetProductByCategoryID(int categoryID)
        {
            return _productDal.GetAll(p => p.CategoryID == categoryID);
        }

        public void Update(Product product)
        {
            ValidationTool.Validater(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
