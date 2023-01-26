using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDto.Product.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator(IProductRepository repository)
        {
            RuleFor(x => x.Name)
                 .NotNull()
                 .NotEmpty().WithMessage("{PropertyName} is Required !")
                 .MinimumLength(3).WithMessage("{PropertyName} limit with {ComprisonValue} charcture .")
                 .MaximumLength(50).WithMessage("{PropertyName} limit with {ComprisonValue} charcture .");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("{PropertyName} greater than  {ComprisonValue}");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} greater than  {ComprisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var categoryIdExist = await repository.Exisit(id);
                    return !categoryIdExist;
                })
                .WithMessage("{PropertyName} does not exisit ?");

        }
    }
}
