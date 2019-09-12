using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Model;

namespace RestServiceDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly List<Car> cars = new List<Car>()
        {
            new Car(12345678, 2008, "Yellow"),
            new Car(23456789,2010, "Blue"),
            new Car(02749387,2011, "Red"),
            new Car(62739562,2012, "Green"),
            new Car(87654321,2013, "Black"),
        };
        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cars;
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "Get")]
        public Car Get(int id)
        {
            return cars.Find(i => i.Id == id);
        }

        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            cars.Add(value);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            Car car = Get(id);
            if (cars != null)
            {
                car.Id = value.Id;
                car.Year = value.Year;
                car.Color = value.Color;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Car car = Get(id);
            cars.Remove(car);
        }
    }
}
