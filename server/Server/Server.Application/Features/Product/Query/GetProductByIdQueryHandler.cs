using AutoMapper;
using MediatR;
using Server.Application.Contract;
using Server.Application.DTOs;

namespace Server.Application.Features.Product.Query;

public record GetProductByIdQuery(string ProductId):IRequest<ProductDto>;
public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ProductDto>
{
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepo productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _productRepo.ExistsAsync(p => p.Id == request.ProductId))
        {
            return _mapper.Map<ProductDto>(await _productRepo.GetByIdAsync(request.ProductId)) ;
        }
        return null;
    }
}