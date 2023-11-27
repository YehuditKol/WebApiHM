using ourProject.ourModels.models;

namespace ourProject.ourModels.Interfaces
{
    public interface IWorkerService
    {
        public DateTime createDate { get; set; }
        public String NameOf(int id);
        public bool Update(int id, Worker worker);
    }
}
