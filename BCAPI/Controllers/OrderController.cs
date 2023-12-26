using BCAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext db;
        public OrderController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.ToList();
        }
        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            return db.Orders.Where(p => p.IdOrder == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveOrders([FromBody] Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateOrders([FromBody] Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteOrders(long id)
        {
            db.Orders.Remove(db.Orders.Where(p => p.IdOrder == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
