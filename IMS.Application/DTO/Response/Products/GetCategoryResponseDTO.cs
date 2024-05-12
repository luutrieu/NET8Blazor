﻿using IMS.Application.DTO.Resquest.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMS.Application.DTO.Response.Products
{
    public class GetCategoryResponseDTO: UpdateCategoryRequestDTO
    {
        [JsonIgnore]
        public virtual ICollection<GetProductResponseDTO> Products { get; set; } = null;
    }
}
