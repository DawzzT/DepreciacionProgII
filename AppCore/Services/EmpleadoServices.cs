﻿using AppCore.IServices;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class EmpleadoServices : BaseServices<Empleado>, IEmpleadoServices
    {

        IEmpleadoModel empleadoModel;
        public EmpleadoServices(IEmpleadoModel model) : base(model)
        {
            this.empleadoModel = model;
        }

        public void Update(Empleado empleado)
        {
            empleadoModel.Update(empleado);
        }

        public Empleado GetById(int id)
        {
            return empleadoModel.GetById(id);
        }
    }
}
