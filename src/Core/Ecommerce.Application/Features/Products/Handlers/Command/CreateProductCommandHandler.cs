using Ecommerce.Application.DTOs.EntitiesDto.Product.Validators;
using Ecommerce.Application.Features.Products.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //check Validator
            var response = new BaseCommandResponse();

            var validator = new ProductValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ProductDto, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Falid While Creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var product = _mapper.Map<Product>(request.ProductDto);
            await _repository.CreateAsync(product);
            response.Success = true;
            response.Message = "Sussfully While Creation";
            response.Id = request.ProductDto.Id;
            return response;
        }
    }
}
