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
    public class TurnosController : ControllerBase
    {
        private readonly AppTurnoTucDbContext context;

        public TurnosController(AppTurnoTucDbContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IEnumerable<Turno> GetTurnos()
        {
            return context.Turnos.Where(s => s.Numero >= 0).ToArray();
        }
    }
}