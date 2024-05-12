using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.Orders;
using IMS.Application.Extension;
using IMS.Application.Service.Orders.Queries;
using IMS.Domain.Entites.Orders;
using IMS.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Orders
{
    public class GetGenericOrdersCountHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetGenericOrdersCountQuery, GetOrdersCountResponseDTO>
    {
        public async Task<GetOrdersCountResponseDTO> Handle(GetGenericOrdersCountQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var list = new List<Order>();
            if(!request.IsAdmin) 
                list = await dbContext.Orders.AsNoTracking().Where(_ => _.ClientId.ToString() == request.UserId.ToString()).ToListAsync(cancellationToken:cancellationToken);
            else
                list = await dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken);

            int ProcessingCount = list.Count(_ => _.OrderState == OrderState.Processing);
            int DeliveringCount = list.Count(_ => _.OrderState == OrderState.Delivering);
            int DeliveredCount = list.Count(_ =>_ .OrderState == OrderState.Delivered);
            int CanceledCount = list.Count(_ => _.OrderState == OrderState.Canceled);
            return new GetOrdersCountResponseDTO(ProcessingCount,  DeliveringCount, DeliveredCount, CanceledCount);
        }
    }
}
