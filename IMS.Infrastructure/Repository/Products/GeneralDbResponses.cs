using IMS.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Products
{
    public class GeneralDbResponses
    {
        public static ServiceResponse ItemAlreadyExist(string itemName) => new(false, $"{itemName} already created");
        public static ServiceResponse ItemNotFound(string itemName) => new (false, $"{itemName} not found");
        public static ServiceResponse ItemCreated(string itemName) => new(false, $"{itemName} successfully creaded");
        public static ServiceResponse ItemUpdate(string itemName) => new(false, $"{itemName} successfully updated");
        public static ServiceResponse ItemDelete(string itemName) => new(false, $"{itemName} successfully deleted");

    }
}
