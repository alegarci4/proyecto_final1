using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final1
{
    public class Registro
    {
        public string Prompt { get; set; }
        public string Respuesta { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
