using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Micro_Ejemplo.Controllers
{
    [ApiController]
    [Route("/")]

    public class DefaultController
    {
        [HttpGet]
        public string Index()
        {
            return "INICIADO";
        }
    }
}
