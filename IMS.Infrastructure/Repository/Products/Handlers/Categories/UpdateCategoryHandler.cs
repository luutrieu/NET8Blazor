﻿using IMS.Application.DTO.Response;
using IMS.Application.Service.Products.Commands.Categories;
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

namespace IMS.Infrastructure.Repository.Products.Handlers.Categories
{
    partial class UpdateCategoryHandler(DataAccess.IDbContextFactory<AppDbContext> contextFactory) : IRequestHandler<UpdateCategoryCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using var dbContext = contextFactory.CreateDbContext();
                var category = await dbContext.Categories.FirstOrDefaultAsync(_ => _.Id.Equals(request.CategoryModel.Id), cancellationToken: cancellationToken);
                if (category == null)
                    return GeneralDbResponses.ItemNotFound(request.CategoryModel.Name);

                dbContext.Entry(category).State = EntityState.Detached;
                var adaptData = request.CategoryModel.Adapt(new Category());
                dbContext.Categories.Update(adaptData);
                await dbContext.SaveChangesAsync(cancellationToken);
                return GeneralDbResponses.ItemUpdate(request.CategoryModel.Name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(true, ex.Message);
            }

        }
    }
}
