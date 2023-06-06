// See https://aka.ms/new-console-template for more information
using NewDay.BusinessLogic;

Console.WriteLine("Hello, World!");

string AppleQtyStr;
string OrgQtyStr; 

Console.Write("Enter Quantity of Apples to Order - ");
AppleQtyStr = Console.ReadLine();
Console.Write("Enter Quantity of Oranges to Order - ");
OrgQtyStr = Console.ReadLine();

if (int.TryParse(AppleQtyStr, out int AppleQty) && int.TryParse(OrgQtyStr, out int OrgQty))
{
    IOrderRepository _OrderRepository;

    _OrderRepository = new OrderRepository();

    var TesService = new OrderService(_OrderRepository);

    //prepare items to order 
    List<OrderItem> OrderItems = new List<OrderItem>{
        new OrderItem
        {
            Fruit = new Fruit { Name = "Apple", Price = 5.0 },
            Quatity = Convert.ToInt32(AppleQty)
        },
         new OrderItem
         {
             Fruit = new Fruit { Name = "Orange", Price = 7.0 },
             Quatity = Convert.ToInt32(OrgQty)
         } };

    var OrderResult = TesService.GetTotalPrice(OrderItems);

    Console.Write($"Total Price for {AppleQty} Apple(s) and {OrgQty} orange(s) is - {OrderResult.TotalPrice}");
}
else
{
    Console.Write("Invalid quantity entered");
}
