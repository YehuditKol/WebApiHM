using Microsoft.AspNetCore.Mvc;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.pizzaProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private  IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
         _orderService = orderService;
         _orderService.createDate= DateTime.Now;
         Console.WriteLine(_orderService.createDate);
        }
        [HttpPost]
        public ActionResult Post(Order order)
        {
            _orderService.Add(order);
            return Ok();
        }
    }
}
