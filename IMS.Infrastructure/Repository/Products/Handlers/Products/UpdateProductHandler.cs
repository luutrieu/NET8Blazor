using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Commands.Locations;
using IMS.Application.Service.Products.Commands.Products;
using IMS.Domain.Entites.Products;
using IMS.Infrastructure.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Products.Handlers.Products
{
    public class UpdateProductHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<UpdateProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var category = await dbContext.Products.FirstOrDefaultAsync(_ => _.Id.Equals(request.ProductModel.Id), cancellationToken: cancellationToken);
                if (category == null)
                    return GeneralDbResponses.ItemNotFound(request.ProductModel.Name);

                dbContext.Entry(category).State = EntityState.Detached;
                var adaptData = request.ProductModel.Adapt(new Product());
                dbContext.Products.Update(adaptData);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemUpdate(request.ProductModel.Name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
