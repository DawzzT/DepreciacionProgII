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
        public const int SIZE = 568;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext("Empleado", SIZE);
        }
       

        public Empleado GetById(int id)
        {
            return context.Get<Empleado>(id);
        }

        public void Update(Empleado empleado)
        {
            context.Update<Empleado>(empleado);
        }

        public void Add(Empleado t)
        {
            context.Create<Empleado>(t);
        }

        public void Delete(Empleado t)
        {
            context.Delete(t.IdEmpleado);
        }

        List<Empleado> IModel<Empleado>.Read()
        {
            return context.GetAll<Empleado>();
        }
    }
}
