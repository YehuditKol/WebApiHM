using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices.Services
{
    public class OrderService : IOrderService
    {
        private static readonly List<Order> orders = new List<Order>() { };

        public DateTime createDate { get; set; }
        public void Add(Order order)
        {
           orders.Add(new Order() { CustomerId=order.CustomerId,Date=order.Date,Items=order.Items,TotalAmount=order.TotalAmount}); 
        }
    }
}
