using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryEmpleadoRepository:IEmpleadoModel
    {
        public RAFContext context;
        public const int SIZE = 600;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext("empleado", SIZE);
        }

        public Empleado GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public void Add(Empleado t)
        {
            context.Create<Empleado>(t);
        }

        public void Delete(Empleado t)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> Read()
        {
            return context.GetAll<Empleado>();
        }
    }
}
