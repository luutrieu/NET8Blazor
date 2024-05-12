using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.Products;
using IMS.Application.Service.Products.Queries.Locations;
using IMS.Application.Service.Products.Queries.Products;
using IMS.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Products.Handlers.Products
{
    //public class GetProductByIdHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetProductByIdQuery, GetProductResponseDTO>
    //{
    //    public async Task<GetProductResponseDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        using var dbContext = contextFactory.CreateDbContext();
    //        var product = await dbContext.Products.AsNoTracking().Include(c => c.Category).Include(l => l.Location).SingleOrDefaultAsync(_ => _.Id == request.Id,cancellationToken);
    //        return new GetProductResponseDTO
    //        {
    //            Id=product.Id,
    //            Name=product.Name,
    //            Description=product.Description,
    //            Base64Image=product.Base64Image,
    //            CategoryId=product.CategoryId,
    //            LocationId=product.LocationId,
    //            Price=product.Price,
    //            DateAdded=product.DateAdded,
    //            Quantity=product.Quantity,
    //            SerialNumber=product.SerialNumber,
    //            Location= new GetLocationResponseDTO
    //            {
    //                Id= product.LocationId,
    //                Name = product.Location.Name
    //            },
    //            Category = new GetCategoryResponseDTO
    //            {
    //                Id=product.CategoryId,
    //                Name=product.Category.Name,
    //            }
    //        };
    //    }
    //}
}
