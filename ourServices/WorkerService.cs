using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices
{
    public class WorkerService : IWorkerService
    {
        private static readonly List<Worker> workers = new List<Worker>()
        {

        };
        public DateTime createDate { get; set; }
        public string NameOf(int id)
        {
            var exsitworker = workers.FirstOrDefault(worker => worker.Id == id);
            return exsitworker != null ? exsitworker.Name : string.Empty;
        }
        public bool Update(int id,Worker worker)
        {
            var existWorker = workers.FirstOrDefault(worker => worker.Id == id);
            if (existWorker != null)
            {
                existWorker.Id = worker.Id;
                existWorker.Name = worker.Name;
               
                return true;
            }
            return false;
        }
        
    }
}
