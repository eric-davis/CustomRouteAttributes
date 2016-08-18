using System.Collections.Generic;
using CustomRouteAttributes.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CustomRouteAttributes.Controllers
{
    using Models;

    [Route("api/[controller]")]
    public class ThingsController : Controller
    {
        private static readonly List<Thing> Things;

        static ThingsController()
        {
            Things = new List<Thing>();
            for (var i = 1; i <= 5; i++)
            {
                Things.Add(new Thing
                {
                    Id = i,
                    Name = $"Thing {i}"
                });
            }
        }

        [CustomHttpHeaderPost("X-Testing", "This is only a test!")]
        public IActionResult GetAll()
        {
            return Ok(Things);
        }
    }
}
