using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        //[ForeignKey("Pais")]
        public int IdPais { get; set; }
        //public Pais pais { get; set; }
    }
}
