using InternalOrderBusiness.BusinessInterfaces;
using InternalOrderBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InternalOrderApi.Controllers.V1
{
    public class OrdersController: BaseV1Controller
    {
        private readonly IBusinessServiceOrder _iBusinessServiceOrder;

        public OrdersController(IBusinessServiceOrder iBusinessServiceOrder)
        {
            _iBusinessServiceOrder = iBusinessServiceOrder;
        }

        [HttpPut]
        public IActionResult Create(Order order)
        {
            //Todo: Below code is a cross cutting concern
            return new ObjectResult(_iBusinessServiceOrder.Create(order))
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}