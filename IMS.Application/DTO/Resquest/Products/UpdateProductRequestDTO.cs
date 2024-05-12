using IMS.Application.DTO.Response.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO.Resquest.Products
{
    public class UpdateProductRequestDTO:ProductBaseDTO
    {
        public Guid Id { get; set; }
    }
}
