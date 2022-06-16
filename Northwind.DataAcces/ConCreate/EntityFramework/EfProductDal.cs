using Northwind.DataAcces.Abstract;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcces.ConCreate.EntityFramework
{
    public class EfProductDal :EfRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        
        
        
    }
}
