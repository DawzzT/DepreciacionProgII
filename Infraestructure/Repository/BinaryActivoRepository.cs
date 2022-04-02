using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryActivoRepository : IActivoModel
    {
        public RAFContext context;
        public const int SIZE = 346;
        public BinaryActivoRepository()
        {
            context = new RAFContext("activo", SIZE);
        }
        public void Add(Activo t)
        {
            try
            {
                context.Create<Activo>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Activo t)
        {
            context.Delete(t.Id);
        }

        public Activo GetById(int id)
        {

            try
            {
                return context.Get<Activo>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Activo> Read()
        {
            return context.GetAll<Activo>();
            //try
            //{
                
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public void Update(Activo activo)
        {
            context.Update<Activo>(activo);
        }

        public void AsignarActivo(Activo a, Empleado e)
        {
            a.Empleado = e.Id;
            context.Update<Activo>(a);
        }

        public List<Activo> GetActivoByEmpleado(Empleado e)
        {
            List<Activo> a = new List<Activo>();
           
            foreach(Activo activo in Read())
            {
                if(activo.Empleado == e.Id)
                {
                    a.Add(activo);
                }
            }
            return a;
        }
    }
}
