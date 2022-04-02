using AppCore.IServices;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class FrmEmpleado : Form
    {
        public IEmpleadoServices eservices { get; set; }
        int index;
        public FrmEmpleado(int index)
        {
            this.index = index;
            InitializeComponent();
        }

        private void IndexVerification()
        {
            if (index < 0)
            {
                btnModificar.Visible = false;
                btnEnviar.Visible = true;
            }
            else
            {
                btnModificar.Visible = true;
                btnEnviar.Visible = false;
                Empleado a = eservices.Read()[index];
                txtNombre.Text = a.Nombre;
                txtApellido.Text = a.Apellidos;
                txtCedula.Text = a.Cedula;
                txtDireccion.Text = a.Direccion;
                txtEmail.Text = a.Email;
                txtTelefono.Text = a.Telefono;
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado emp = eservices.Read()[index];
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {
                EstadoEmpleado estEmp = (EstadoEmpleado)Enum.GetValues(typeof(EstadoEmpleado)).
                   GetValue(cmbEstado.SelectedIndex);
                Empleado empleado = new Empleado()
                {
                    Id = emp.Id,
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    Cedula = txtCedula.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Estado = estEmp.ToString()

                };

                eservices.Update(empleado);
                limpiar();
                Dispose();

            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
           
        }

        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(txtCedula.Text)
                || String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtTelefono.Text)|| cmbEstado.SelectedIndex == -1)
            {

                return false;
            }
            return true;
        }
        private void limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.txtCedula.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtTelefono.Text = String.Empty;
            cmbEstado.SelectedIndex = -1;
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            IndexVerification();
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {
                EstadoEmpleado estEmp = (EstadoEmpleado)Enum.GetValues(typeof(EstadoEmpleado)).
                   GetValue(cmbEstado.SelectedIndex);
                Empleado empleado = new Empleado()
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    Cedula = txtCedula.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Estado = estEmp.ToString()

                };
                MessageBox.Show($"{empleado.Nombre}, {empleado.Apellidos},{empleado.Cedula},{empleado.Direccion},{empleado.Email},{empleado.Telefono}, {empleado.Estado}" );
                eservices.Add(empleado);
                limpiar();
                Dispose();

            }
        }
    }
}
