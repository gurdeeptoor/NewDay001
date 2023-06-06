using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDay.BusinessLogic
{
    public class OrderService
    {
        private IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository) 
        {
            _OrderRepository = OrderRepository;
        }
        public OrderResult GetTotalPrice(List<OrderItem> orderItems)
        {
            return _OrderRepository.OrderFruits(orderItems);
        } 
    }
}