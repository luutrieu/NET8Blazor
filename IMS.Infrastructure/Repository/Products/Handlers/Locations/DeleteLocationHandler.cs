using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Commands.Categories;
using IMS.Application.Service.Products.Commands.Locations;
using IMS.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Products.Handlers.Locations
{
    public class DeleteLocationHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<DeleteLocationCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var data = await dbContext.Locations.FirstOrDefaultAsync(_ => _.Id.Equals(request.Id));
                if (data == null)
                    return GeneralDbResponses.ItemNotFound("Category");

                dbContext.Locations.Remove(data);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemDelete(data.Name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
