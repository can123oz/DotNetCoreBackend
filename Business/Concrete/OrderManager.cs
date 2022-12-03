using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderService _orderService;
        public OrderManager(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IResult MakePayment(Order order)
        {
            Thread.Sleep(5000);
            return new SuccessResult("Payment Successful");
        }
    }
}
