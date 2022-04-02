using AppCore.IServices;
using Domain.Entities;
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
    
    public partial class Form1 : Form
    {
        IActivoServices activoServices;
        IEmpleadoServices empleadoServices;
        int index;
        public Form1(IActivoServices ActivoServices, IEmpleadoServices EmpleadoServices)
        {
            this.activoServices = ActivoServices;
            this.empleadoServices = EmpleadoServices;
            InitializeComponent();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }

    

    
       
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmDepreciacion depreciacion = new FrmDepreciacion(activoServices.Read()[e.RowIndex]);
                depreciacion.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activoServices.Read();
            mostrarActivosToolStripMenuItem.Enabled = false;
            mostrarEmpleadosToolStripMenuItem.Enabled = true;
            depreciarToolStripMenuItem.Enabled = true;
            asignarActivoToolStripMenuItem.Enabled = true;
        }

       

        private void nuevoActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = -1;
            FrmActivo nuevo = new FrmActivo(index);
            nuevo.aservices = activoServices;
            nuevo.ShowDialog();

            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource = activoServices.Read();
            mostrarActivosToolStripMenuItem.Enabled = false;
            mostrarEmpleadosToolStripMenuItem.Enabled = true;
            depreciarToolStripMenuItem.Enabled = true;
            asignarActivoToolStripMenuItem.Enabled = true;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarActivosToolStripMenuItem.Enabled == false)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    Activo a = activoServices.Read()[index];
                    activoServices.Delete(a);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = activoServices.Read();
                }
            }
            else
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    Empleado emp = empleadoServices.Read()[index];
                    empleadoServices.Delete(emp);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = empleadoServices.Read();
                }
            }
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarActivosToolStripMenuItem.Enabled== false)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index >= 0)
                {
                    FrmActivo modificar = new FrmActivo(index);
                    modificar.aservices = activoServices;
                    modificar.ShowDialog();

                    dataGridView1.DataSource = null;

                    dataGridView1.DataSource = activoServices.Read();
                }
            }
            else
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index >= 0)
                {
                    FrmEmpleado modificar = new FrmEmpleado(index);
                    modificar.eservices = empleadoServices;
                    modificar.ShowDialog();

                    dataGridView1.DataSource = null;

                    dataGridView1.DataSource = empleadoServices.Read();
                }
            }
           
        }

        private void depreciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if(index>= 0)
            {
                FrmDepreciacion depreciacion = new FrmDepreciacion(activoServices.Read()[index]);
                depreciacion.ShowDialog();
            }
            
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = -1;
            FrmEmpleado nuevo = new FrmEmpleado(index);
            nuevo.eservices = empleadoServices;
            nuevo.ShowDialog();

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = empleadoServices.Read();
            mostrarActivosToolStripMenuItem.Enabled = true;
            mostrarEmpleadosToolStripMenuItem.Enabled = false;
            depreciarToolStripMenuItem.Enabled = false;
            asignarActivoToolStripMenuItem.Enabled = false;
        }

        private void mostrarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = empleadoServices.Read();
            mostrarActivosToolStripMenuItem.Enabled = true;
            mostrarEmpleadosToolStripMenuItem.Enabled = false;
            depreciarToolStripMenuItem.Enabled = false;
            asignarActivoToolStripMenuItem.Enabled = false;
        }

        private void mostrarActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = activoServices.Read();
            mostrarActivosToolStripMenuItem.Enabled = false;
            mostrarEmpleadosToolStripMenuItem.Enabled = true;
            depreciarToolStripMenuItem.Enabled = true;
            asignarActivoToolStripMenuItem.Enabled = true;
        }

        private void asignarActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            btnAceptar.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (empleadoServices.GetById((int)numericUpDown1.Value).Id >=1)
                {
                    activoServices.AsignarActivo(activoServices.Read()[dataGridView1.CurrentCell.RowIndex], empleadoServices.GetById((int)numericUpDown1.Value));
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("El empleado no existe");
            }
            numericUpDown1.Visible = false;
            btnAceptar.Visible = false;

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = activoServices.Read();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buscarActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBuscar.Visible = true;
            label1.Visible = true;
            numericUpDown1.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = activoServices.GetActivoByEmpleado(empleadoServices.GetById((int)numericUpDown1.Value));
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("No hay activos asignados a este id");
            }
            btnBuscar.Visible = false;
            label1.Visible = false;
            numericUpDown1.Visible = false;
        }
    }
}
