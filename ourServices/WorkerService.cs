using ourProject.FileService;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;

namespace ourProject.ourServices
{
    public class WorkerService : IWorkerService
    {
        public List<Worker> workers;

        public List<Worker> GetWorkers()
        {
            return workers;
        }

        public void SetWorkers(List<Worker> value)
        {
            workers = value;
        }

        public DateTime createDate { get; set; }
        public List<Worker> Workers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Ifile _fileService;

        public WorkerService(Ifile fileService)
        {
            _fileService = fileService;
            _fileService.FileName = "worker.json";
            SetWorkers(_fileService.Get<Worker>());
        }
        
        public string NameOf(int id)
        {
            var exsitworker = GetWorkers().FirstOrDefault(worker => worker.Id == id);
            return exsitworker != null ? exsitworker.Name : string.Empty;
        }
        public void Add(Worker worker){
            _fileService.AddItem<Worker>(worker);
            SetWorkers(_fileService.Get<Worker>());
        }
        public bool Update(int id,Worker worker)
        {
            var existWorker = GetWorkers().FirstOrDefault(worker => worker.Id == id);
            if (existWorker != null)
            {
                existWorker.Id = worker.Id;
                existWorker.Name = worker.Name;
                _fileService.Update(GetWorkers());
                SetWorkers(_fileService.Get<Worker>());
                return true;
            }
            return false;
        }
       
        
    }
}
