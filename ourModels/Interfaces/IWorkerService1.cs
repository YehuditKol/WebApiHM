using ourProject.ourModels.models;

namespace ourProject.ourModels.Interfaces
{
    public interface IWorkerService
    {
        public List<Worker> GetWorkers();
        public void SetWorkers(List<Worker> value);

        public DateTime createDate { get; set; }
        public String NameOf(int id);
        public void Add(Worker worker);
        public bool Update(int id, Worker worker);
    }
}
