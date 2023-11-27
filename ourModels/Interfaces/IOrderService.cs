using ourProject.ourModels.models;

namespace ourProject.ourModels.Interfaces
{
   
    public interface IOrderService
    {
        public DateTime createDate { get; set; }
        public void Add(Order order);
    }
}
