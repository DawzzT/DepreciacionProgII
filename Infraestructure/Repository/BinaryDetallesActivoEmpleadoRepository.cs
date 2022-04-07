using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryDetallesActivoEmpleadoRepository : IDetallesActivoEmpleado
    {
        public RAFContext context;
        public const int SIZE = 25;
        public BinaryDetallesActivoEmpleadoRepository()
        {
            context = new RAFContext("Detalles", SIZE);
        }
        public void Add(DetallesActivoEmpleado t)
        {
            context.Create<DetallesActivoEmpleado>(t);
        }

        public void Delete(DetallesActivoEmpleado t)
        {
            throw new NotImplementedException();
        }

        public DetallesActivoEmpleado GetById(int id)
        {
            return context.Get<DetallesActivoEmpleado>(id);
        }

        public List<DetallesActivoEmpleado> Read()
        {
            return context.GetAll<DetallesActivoEmpleado>();
        }
    }
}
