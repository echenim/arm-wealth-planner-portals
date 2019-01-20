using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //Log.Information("Log: Log.Information First");
            //Log.Warning("Log: Log.Warning Second");
            //Log.Error("Log: Log.Error Third");
            //Log.Fatal("Log: Log.Fatal Fourth");

            double a = 98, b = 0;
            double result = 0;

            result = SafeDivision(a, b);
            Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            //// Log.Information("Log: successfful");

            //try
            //{
            //    result = SafeDivision(a, b);
            //    Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            //    Log.Information("Log: successfful");
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Attempted divide by zero.");
            //    Log.Error(e.Message);
            //}

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }
    }
}