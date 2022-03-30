using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_FirstStep
{
    [Route("api/[controller]")]
    public class TestController: ControllerBase
    {
        private readonly SuperheroContext _context;

        public TestController(SuperheroContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index()
        {
            _context.Superheros.Add(new Superhero()
            {
                Name = "Memto",
                Age = 45,
                NationalId = "76576576HH",
                IsDcSuperhero = true
            });

            _context.Superheros.Add(new Superhero()
            {
                Name = "Nuklon",
                Age = 25,
                NationalId = "111N",
                IsDcSuperhero = true
            });

            _context.SaveChanges();

            return Ok("Hi from test, we have created 2 superheros");
        }

        [HttpGet("query")]
        public async Task<ActionResult<List<Superhero>>> Query(string sql)
        {
            var connString = "DefaultEndpointsProtocol=https;AccountName=terraformlocalstate;AccountKey=VpSvQXpaaoqQ29qBUdqLXW1zLJUbh5bXZ/RB+lHDyHS+Yck1Z9K2y6t47M4yDUnFBuyjnUFdau3Oc6xqGX/u/Q==;EndpointSuffix=core.windows.net";
            var heroes = await _context.Superheros.FromSql(sql).ToListAsync();

            return heroes;
        }
    }
}
