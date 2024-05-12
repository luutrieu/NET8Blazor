﻿using IMS.Application.DTO.Response.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Service.Orders.Queries
{
    public record GetOrderedProductsWithQuantityQuery(string UserId=null):IRequest<GetOrderedProductsWithQuantityResponseDTO>;
    
}
