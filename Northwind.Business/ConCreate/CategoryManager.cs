using Northwind.Business.Abstract;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.ConCreate.EntityFramework;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ConCreate
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _CategoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _CategoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _CategoryDal.GetAll();
        }
    }
}
