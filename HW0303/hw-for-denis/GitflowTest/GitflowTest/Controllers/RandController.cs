using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitflowTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandController : ControllerBase
    {
        public int Rand([FromQuery] int a, int b)
        {
            if (a > b)
                return new Random().Next(b, a);
            else
                return new Random().Next(a, b);
        }
    }
}
