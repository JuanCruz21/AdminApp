using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public decimal Suma(decimal a, decimal b)
        {
            return a + b;
        }
        [HttpPost]
        public decimal Resta(decimal a, decimal b)
        {
            return a - b;
        }
        [HttpPut]
        public decimal Multiplicacion(decimal a, decimal b)
        {
            return a * b;
        }
        [HttpDelete]
        public decimal Division(decimal a, decimal b)
        {
            return a / b;
        }
    }
}