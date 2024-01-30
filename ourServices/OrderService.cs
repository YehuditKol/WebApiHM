using ourProject.FileService;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices
{
    public class OrderService : IOrderService
    {
        private Ifile _fileService;
        private static readonly List<Order> orders = new List<Order>() { };
        private static int count = 0;
        public OrderService(Ifile fileService)
        {
            _fileService = fileService;
            count++;
            _fileService.FileName = $"emails/{count}.json";
        }
        public DateTime createDate { get; set; }
        public async void Add(Order order)
        {
           orders.Add(new Order() { CustomerId=order.CustomerId,Date=order.Date,Items=order.Items,TotalAmount=order.TotalAmount});
            Task task=Pay(order.Payment);
            //הכנת פיצה
            MakingPizza(order.Items);
            await task;
            //הנפקת חשבונית
            PrintingPizza(order);
        }
        public async Task Pay(CreditCardPay creditCard)
        {
            await Task.Delay(3000);
           
        }
        public void MakingPizza(List<Pizza> list)
        {
            Console.WriteLine("the pizzas in the order-");
            foreach (var p in list)
                Console.WriteLine(p.ToString());
           
        }
        public void PrintingPizza(Order order)
        {
            _fileService.FileName = $"emails/{count}.json";
            _fileService.WriteMessage($"Hello customer number {order.CustomerId}!!\nyour pizza is ready📝\nThe order will reach you in about an hour  with appetite The pizza shop🍕🍕🍕\ntotal amount-{order.TotalAmount}₪");



        } 

    }
}
