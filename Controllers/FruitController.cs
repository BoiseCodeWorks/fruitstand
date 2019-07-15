using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruitstand.Models;
using Microsoft.AspNetCore.Mvc;

namespace fruitstand.Controllers
{

    // hostname/api/fruits
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        //THIS IS ONLY TEMPORARY FOR TODAY!!!!!!!
        List<Fruit> Fruits = new List<Fruit>(){
            new Fruit("Apple",1, "12lk"),
            new Fruit("banana",.1, "1e3k"),
            new Fruit("orange",.5, "3jg9")
        };

        // GET api/fruits
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(Fruits);
        }

        // GET api/fruits/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(Fruits[id]);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/fruits/5/otherValue
        [HttpGet("{id}/otherValue/")]
        public ActionResult<string> GetExtra(int id)
        {
            return "other value";
        }

        // POST api/fruits
        [HttpPost]
        public ActionResult<IEnumerable<Fruit>> Post([FromBody] Fruit newFruit)
        {
            Fruits.Add(newFruit);
            return Ok(Fruits);
        }

        // PUT api/fruits/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/fruits/5
        [HttpDelete("{fruitId}")]
        public ActionResult Delete(string fruitId)
        {
            try
            {
                Fruit found = Fruits.Find(fruit => fruit.Id == fruitId);
                if (found == null) return BadRequest(new { message = "Bad Id" });
                Fruits.Remove(found);
                return Ok(new { message = "Deleted" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
