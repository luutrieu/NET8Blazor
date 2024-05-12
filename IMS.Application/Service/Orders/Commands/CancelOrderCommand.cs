using IMS.Application.DTO.Response;
using MediatR;

namespace IMS.Application.Service.Orders.Commands
{
    public class CancelOrderCommand(Guid OrderId) : IRequest<ServiceResponse>
    {
    }
}
