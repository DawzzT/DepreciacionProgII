using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallesActivoEmpleado
    {
        public int Id { get; set; }
        public int Activo { get; set; }
        public int Empleado { get; set; }
        public long fecha { get; set; }
        public byte IsActivo { get; set; }
    }
}
