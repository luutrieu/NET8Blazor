using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO.Resquest.Orders
{
    public class UpdateClientOrderRequestDTO
    {
        public Guid OrderId { get; set; }
        public string OrderState { get; set; }
        public DateTime DeliveringDate { get; set; } =DateTime.Now;
    }
}
