using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using turnotucapp.Models;
using turnotucapp.Data;

namespace turnotucapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtencionsController : ControllerBase
    {
        private readonly AppTurnoTucDbContext context;

        public AtencionsController(AppTurnoTucDbContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IEnumerable<BocaDeAtencion> GetAtencions()
        {
            return context.Atencions.Where(s => s.TipoAtencion != null).ToArray();
        }
    }
}