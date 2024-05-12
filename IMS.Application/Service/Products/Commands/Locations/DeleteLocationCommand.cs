﻿using IMS.Application.DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Service.Products.Commands.Locations
{
    public record DeleteLocationCommand(Guid Id): IRequest<ServiceResponse>;
}
