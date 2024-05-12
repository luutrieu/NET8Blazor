using IMS.Application.DTO.Response.Products;
using MediatR;

namespace IMS.Application.Service.Products.Queries.Locations
{
    public class GetLocationsWithProductsQuery : IRequest<IEnumerable<GetLocationResponseDTO>> 
    {
    }
}
