using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace turnotucapp.Models
{


    public class Sucursal
    {
        public int SucursalID { get; set; }
        public string NombreSucursal { get; set; }
        public ICollection<BocaDeAtencion> Atencions { get; set; }
        public ICollection<Turno> Turnos { get; set; }
    }

    public class BocaDeAtencion
    {
        public int BocaDeAtencionID { get; set; }
        public int NumeroDeAtencion { get; set; }

        public string TipoAtencion { get; set; }
        public string DescripcionAtencion { get; set; }
    }

    public class Turno
    {
        public int TurnoID { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public Paciente Paciente { get; set; }
        public string Estado { get; set; }

    }

    public class ObraSocial
    {
        public int ObraSocialID { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public double Cuit { get; set; }
        public ICollection<Sucursal> Sucursals { get; set; }
    }

    public class Paciente
    {
        public int PacienteID { get; set; }
    }

}