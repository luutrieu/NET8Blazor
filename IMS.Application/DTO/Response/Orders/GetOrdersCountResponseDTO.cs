﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO.Response.Orders
{
    public record GetOrdersCountResponseDTO(int Processing, int Delivering, int Delivered, int Canceled);

}
