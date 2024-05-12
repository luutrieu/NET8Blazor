using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Commands.Products;
using IMS.Domain.Entites.Products;
using IMS.Infrastructure.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repository.Products.Handlers.Products
{
    public class CreateProductHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<CreateProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var category = await dbContext.Products.FirstOrDefaultAsync(_ => _.Name.ToLower().Equals(request.ProductModel.Name.ToLower()), cancellationToken: cancellationToken);
                if (category != null)
                    return GeneralDbResponses.ItemAlreadyExist(request.ProductModel.Name);

                var data = request.ProductModel.Adapt(new Product());
                dbContext.Products.Add(data);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemCreated(request.ProductModel.Name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }
        }
    }
}
