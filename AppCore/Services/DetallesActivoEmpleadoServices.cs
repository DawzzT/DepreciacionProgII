using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class DetallesActivoEmpleadoServices:BaseServices<DetallesActivoEmpleado>,IDetallesActivoEmpleado
    {
        IDetallesActivoEmpleado detallesActivoEmpleado;
        public DetallesActivoEmpleadoServices(IDetallesActivoEmpleado model) : base(model)
        {
            this.detallesActivoEmpleado = model;
        }

        public DetallesActivoEmpleado GetById(int id)
        {
            return detallesActivoEmpleado.GetById(id);
        }

       
    }
}
