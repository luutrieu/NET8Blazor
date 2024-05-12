using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Commands.Categories;
using IMS.Application.Service.Products.Commands.Locations;
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

namespace IMS.Infrastructure.Repository.Products.Handlers.Locations
{
    partial class CreateLocationHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CreateLocationCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var category = await dbContext.Locations.FirstOrDefaultAsync(_ => _.Name.ToLower().Equals(request.LocationModel.Name.ToLower()), cancellationToken: cancellationToken);
                if (category != null)
                    return GeneralDbResponses.ItemAlreadyExist(request.LocationModel.Name);

                var data = request.LocationModel.Adapt(new Location());
                dbContext.Locations.Add(data);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemCreated(request.LocationModel.Name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
