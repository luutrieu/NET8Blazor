using IMS.Application.DTO.Response;
using IMS.Application.Extension;
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
   // public class CreateOrderHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CreateOrderCommand, ServiceResponse>
   // {
   //     public async Task<ServiceResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
   //     {
			//try
			//{
   //             using var dbContext = contextFactory.CreateDbContext();

   //             var product = await dbContext.Products.FirstOrDefaultAsync(_ => _.Id == request.Model.ProductId,cancellationToken: cancellationToken);
   //             var data = request.Model.Adapt<Order>();
   //             data.TotalAmount = product.Price * data.Quantity;
   //             data.OrderState = OrderState.Processing;
   //             data.Price = product.Price;
   //             dbContext.Orders.Add(data);
   //             await dbContext.SaveChangesAsync(cancellationToken);
   //             return new ServiceResponse(true, "Order placed successfully");
			//}
			//catch (Exception ex)
			//{
   //             return new ServiceResponse(true, ex.Message);
			//}
   //     }
   // }
}
