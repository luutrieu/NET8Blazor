using IMS.Application.DTO.Response;
using IMS.Application.DTO.Resquest.Orders;
using MediatR;

namespace IMS.Application.Service.Orders.Commands
{
    public class CreateOrderCommand(CreateOrderRequestDTO Model) : IRequest<ServiceResponse>
    {
    }
}
