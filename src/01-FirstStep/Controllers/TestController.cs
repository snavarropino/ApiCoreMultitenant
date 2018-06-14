using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("index")]
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
    }
}
