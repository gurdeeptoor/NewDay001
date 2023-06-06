using Moq;
using NewDay.BusinessLogic;

namespace NewDay.UnitTests
{
    [TestFixture]
    public class OrderServiiceTests
    {
        private List<OrderItem> TestOrderItems(int AppleQty, int OrangeQty)
        {
            return new List<OrderItem>
            {
              new OrderItem { Fruit = new Fruit { Name = "Apple", Price=5.0 }, Quatity = AppleQty },
              new OrderItem { Fruit= new Fruit { Name = "Orange", Price=7.0 }, Quatity = OrangeQty }
          };
        }

        private OrderResult TestOrderResult(int AppleQty, int OrangeQty)
        {
            return new OrderResult
            {
                TotalPrice = (AppleQty * 5.0) + (OrangeQty * 7.0) > 0 ? (AppleQty * 5.0) + (OrangeQty * 7.0) : 0,
                OrderId = AppleQty + OrangeQty > 0 ? "1234" : string.Empty,
                ItemsCount = AppleQty + OrangeQty <= 0 ? 0 : AppleQty + OrangeQty
            };
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Order_2Apples_5Oranges_Returns_Total_45()
        {
            int _appleQty = 2;
            int _OrgQty = 5;

            //Arrange
            var MockOrderRepository = new Mock<IOrderRepository>();

            var _OrderItems = TestOrderItems(_appleQty, _OrgQty);

            MockOrderRepository.Setup(x => x.OrderFruits(It.IsAny<List<OrderItem>>())).Returns(TestOrderResult(_appleQty, _OrgQty));

            var TesService = new OrderService(MockOrderRepository.Object);

            //Act
           var OrderResult = TesService.GetTotalPrice(_OrderItems);

            //Assert
            Assert.That(OrderResult, Is.TypeOf(typeof(OrderResult)));
            Assert.That(OrderResult.TotalPrice, Is.EqualTo(45));
            Assert.That(OrderResult.ItemsCount, Is.EqualTo(7));
            Assert.That(OrderResult.OrderId.Length, Is.GreaterThan(0));
        }

        [Test]
        public void Order_1Apples_1Oranges_Returns_Total_12()
        {
            int _appleQty = 1;
            int _OrgQty = 1;

            //Arrange
            var MockOrderRepository = new Mock<IOrderRepository>();

            var _OrderItems = TestOrderItems(_appleQty, _OrgQty);

            MockOrderRepository.Setup(x => x.OrderFruits(It.IsAny<List<OrderItem>>())).Returns(TestOrderResult(_appleQty, _OrgQty));

            var TesService = new OrderService(MockOrderRepository.Object);

            //Act
            var OrderResult = TesService.GetTotalPrice(_OrderItems);

            //Assert
            Assert.That(OrderResult, Is.TypeOf(typeof(OrderResult)));
            Assert.That(OrderResult.TotalPrice, Is.EqualTo(12));
            Assert.That(OrderResult.ItemsCount, Is.EqualTo(2));
            Assert.That(OrderResult.OrderId.Length, Is.GreaterThan(0));
        }

        [Test]
        public void Order_0Apples_0Oranges_Returns_Total_0()
        {
            int _appleQty = 0;
            int _OrgQty = 0;

            //Arrange
            var MockOrderRepository = new Mock<IOrderRepository>();

            var _OrderItems = TestOrderItems(_appleQty, _OrgQty);

            MockOrderRepository.Setup(x => x.OrderFruits(It.IsAny<List<OrderItem>>())).Returns(TestOrderResult(_appleQty, _OrgQty));

            var TesService = new OrderService(MockOrderRepository.Object);

            //Act
            var OrderResult = TesService.GetTotalPrice(_OrderItems);

            //Assert
            Assert.That(OrderResult, Is.TypeOf(typeof(OrderResult)));
            Assert.That(OrderResult.TotalPrice, Is.EqualTo(0));
            Assert.That(OrderResult.ItemsCount, Is.EqualTo(0));
            Assert.That(OrderResult.OrderId.Length, Is.EqualTo(0));
        }
    }
}