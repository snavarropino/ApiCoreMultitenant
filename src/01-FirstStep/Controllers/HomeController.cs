using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace _01_FirstStep
{
    [Route("api/[controller]/")]
    public class HomeController:Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        public IEnumerable<string> SomeGreetings()
        {
            return new string[] {"Hi", "Hello", "Hope you are doing well!", "How are you doing?", "How do you do?"};
        }

        [HttpGet("AnotherGreetings")]
        public IEnumerable<string> AnotherGreetings()
        {
            return new string[] {"Hi", "Hello", "Hope you are doing well!", "How are you doing?", "How do you do?"};
        }

        [HttpGet("NoGreetings")]
        public IEnumerable<string> NoGreetings()
        {
            return new string[] { "Bye" };
        }

        [HttpGet("Test")]
        public string Test()
        {
            return "Test";
        }
    }
}