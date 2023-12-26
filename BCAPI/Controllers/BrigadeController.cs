using BCAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCAPI.Controllers
{
    [Route("api/[controller]")]
    public class BrigadeController : ControllerBase
    {
        private readonly DataContext db;
        public BrigadeController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Brigade> GetBrigades()
        {
            return db.Brigades.ToList();
        }
        [HttpGet("{id}")]
        public Brigade GetBrigade(int id)
        {
            return db.Brigades.Where(p => p.IdBrigade == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveBrigades([FromBody] Brigade brigade)
        {
            db.Brigades.Add(brigade);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateBrigades([FromBody] Brigade brigade)
        {
            db.Brigades.Update(brigade);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteBrigade(long id)
        {
            db.Brigades.Remove(db.Brigades.Where(p => p.IdBrigade == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
