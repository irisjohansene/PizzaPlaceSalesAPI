using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlaceSalesAPI.DTO
{
    public class APIResponseModelDto<T>
    {
        /// <summary>
        /// Contains Dynamic Data to be return by API
        /// </summary>
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
    }
}
