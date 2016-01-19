using Microsoft.AspNet.Mvc;
using System;

namespace azuretest
{
    [Route("/api/[controller]")]
    public class TestController : Controller
    {
        public IActionResult Get()
        {
            return Ok(
                new { Time = DateTime.Now }
               );
        }
    }
}