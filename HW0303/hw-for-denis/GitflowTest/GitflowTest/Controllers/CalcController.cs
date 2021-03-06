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
    public class CalcController : ControllerBase
    {
        [HttpGet("sum")]
        public string Sum([FromQuery]double a, double b)
        {
            return (a + b).ToString();
        }

        [HttpGet("diff")]
        public string Diff([FromQuery] double a, double b)
        {
            return (a - b).ToString();
        }

        [HttpGet("multiply")]
        public string Multiply([FromQuery] double a, double b)
        {
            return (a * b).ToString();
        }

        [HttpGet("divide")]
        public string Divide([FromQuery] double a, double b)
        {
            if (b == 0)
                return "NaN";
            return (a / b).ToString();
        }
    }
}
