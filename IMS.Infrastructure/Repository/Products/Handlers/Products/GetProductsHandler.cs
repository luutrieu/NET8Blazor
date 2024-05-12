using IMS.Application.DTO.Response.Products;
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
    //partial class GetProductsHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<GetProductsQuery, GetProductResponseDTO>
    //{
    //    public async Task<GetProductResponseDTO> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    //    {
    //        using var context = contextFactory.CreateDbContext();
    //        var data = await context.Products.AsNoTracking().Include(c => c.Category).Include(l => l.Category);
    //        return data.Select(product => new GetProductResponseDTO
    //        {
    //            Id = product.Id,
    //            Name = product.Name,
    //            Description = product.Description,
    //            Base64Image = product.Base64Image,
    //            CategoryId = product.CategoryId,
    //            LocationId = product.LocationId,
    //            Price = product.Price,
    //            //DateAdded = product.Da
    //            Quantity = product.Quantity,
    //            SerialNumber = product.SerialNumber,
    //            Location = new GetLocationResponseDTO
    //            {
    //                Id= product.LocationId,
    //                Name= product.Location.Name,
    //            },
    //            Category = new GetCategoryResponseDTO
    //            {
    //                Id= product.CategoryId,
    //                Name= product.Category.Name,
    //            }
    //        }).ToListAsync();
    //    }
    //}
}
