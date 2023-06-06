using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDay.BusinessLogic
{
    public interface IOrderRepository
    {
        OrderResult OrderFruits(List<OrderItem> OrderItems);
    }
}
