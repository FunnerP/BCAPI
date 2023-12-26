using BCAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCAPI.Controllers
{
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private DataContext db;
        public WorkerController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Worker> GetWorkers()
        {
            return db.Workers.ToList();
        }
        [HttpGet("{id}")]
        public Worker GerWorker(int id)
        {
            return db.Workers.Where(p => p.IdWorker == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveWorker([FromBody] Worker worker)
        {
            db.Workers.Add(worker);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateWorker([FromBody] Worker worker)
        {
            db.Workers.Update(worker);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteWorker(long id)
        {
            db.Workers.Remove(db.Workers.Where(p => p.IdWorker == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
