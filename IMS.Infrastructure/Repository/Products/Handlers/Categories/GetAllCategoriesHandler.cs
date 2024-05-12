using IMS.Application.DTO.Response.Products;
using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Queries.Categories;
using IMS.Infrastructure.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repository.Products.Handlers.Categories
{
    //public class GetAllCategoriesHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetAllCategoryQuery, ServiceResponse>
    //{
    //   public async Task<IEnumerable<GetCategoryResponseDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    //    {
    //        using var dbContext = contextFactory.CreateDbContext();
    //        var data = await dbContext.Categories.AsNoTracking().ToListAsync(cancellationToken:cancellationToken);
    //        return data.Adapt<List<GetCategoryResponseDTO>>();
    //    }
    //}
}
