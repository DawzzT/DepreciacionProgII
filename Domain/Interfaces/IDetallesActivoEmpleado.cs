using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDetallesActivoEmpleado: IModel<DetallesActivoEmpleado>
    {
        DetallesActivoEmpleado GetById(int id);

    }
}
