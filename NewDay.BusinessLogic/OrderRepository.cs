using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewDay.BusinessLogic
{
    public class OrderRepository : IOrderRepository
    {
        public OrderResult OrderFruits(List<OrderItem> OrderItems)
        {
            double TotalPrice = 0;
            int ItemsCount = 0;
            string OrderId = string.Empty;

            foreach (OrderItem OrderItem in OrderItems)
            {
                if (OrderItem.Quatity > 0)
                {
                    TotalPrice += OrderItem.Fruit.Price * OrderItem.Quatity;
                    ItemsCount += 1;
                }

                //Update the stock - TODO() This was not asked
            }

            return new OrderResult { ItemsCount = ItemsCount, OrderId = OrderId, TotalPrice = TotalPrice };
        }
    }
}