using FluentValidation;
using Northwind.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ConCreate.Validation.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>// eklediğimiz kütüphaneden aldık
    {
        public ProductValidator()
        {
            RuleFor(P => P.CategoryID).NotEmpty().WithMessage("ürün ismi boş olamaz");//yazmazsan kendi üretir kullanıcı diline göre
            //RuleFor(p => p.ProductID).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);//hexa aldığından
            RuleFor(p => p.UnitPrice).GreaterThan(25).When(p => p.CategoryID == 2);

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Start With A Please!");//kendi metodunu da ekleyebilirsin
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
