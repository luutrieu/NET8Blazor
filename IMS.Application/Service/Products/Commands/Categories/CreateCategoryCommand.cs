using IMS.Application.DTO.Response;
using IMS.Application.DTO.Resquest.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Service.Products.Commands.Categories
{
    public record CreateCategoryCommand(AddCategoryRequestDTO CategoryModel) : IRequest<ServiceResponse>;
  
}
