using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;
using System.Text.Json; 

namespace ourProject.pizzaProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class WorkerController : ControllerBase
    {
        private IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
            _workerService.createDate = DateTime.Now;
            Console.WriteLine(_workerService.createDate);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var name=_workerService.NameOf(id);
            return Ok(name);
        }

        [HttpPost]
        public IActionResult Post(Worker worker)
        {
              _workerService.Add(worker);
              return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Worker worker)
        {
            var isworkerService = _workerService.Update(id, worker);
            if (isworkerService)
                return Ok();
            return NotFound();

        }
    }
}
