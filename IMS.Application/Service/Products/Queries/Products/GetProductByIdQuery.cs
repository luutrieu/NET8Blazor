using IMS.Application.DTO.Response.Products;
using MediatR;

namespace IMS.Application.Service.Products.Queries.Products
{
    public class GetProductByIdQuery(Guid Id):IRequest<IEnumerable<GetProductResponseDTO>>
    {
    }
}
