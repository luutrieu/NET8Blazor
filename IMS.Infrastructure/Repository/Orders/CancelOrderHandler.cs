using IMS.Application.DTO.Response;
using IMS.Application.Service.Orders.Commands;
using IMS.Application.Service.Products.Commands.Categories;
using IMS.Infrastructure.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Orders
{
   // public class CancelOrderHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CancelOrderCommand, ServiceResponse>
   // {
   //     public async Task<ServiceResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
   //     {
			//try
			//{
			//	using var dbContext = contextFactory.CreateDbContext();
			//	var order = await dbContext.Orders.Where(_ => _.Id ==request.id).FirstOrDefaultAsync(cancellationToken:cancellationToken);
			//	if (order == null)
			//		return new ServiceResponse(false, "Order not found");

			//	order.OrderState = OrderState.Canceled;
			//	await dbContext.SaveChangesAsync(cancellationToken);
			//	return new ServiceResponse(true, "Order canceled successfully");
			//}
			//catch (Exception ex)
			//{
			//	return new ServiceResponse(true, ex.Message);
			//}
   //     }
   // }
}
