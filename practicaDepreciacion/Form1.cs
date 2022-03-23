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
        int index;
        public Form1(IActivoServices ActivoServices)
        {
            this.activoServices = ActivoServices;
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

    

        private void txtValor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtVidaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtEnviar_Click(object sender, EventArgs e)
        {
           
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
        }

       

        private void nuevoActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = -1;
            FrmActivo nuevo = new FrmActivo(index);
            nuevo.aservices = activoServices;
            nuevo.ShowDialog();

            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource = activoServices.Read();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void depreciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if(index>= 0)
            {
                FrmDepreciacion depreciacion = new FrmDepreciacion(activoServices.Read()[index]);
                depreciacion.ShowDialog();
            }
            
        }
    }
}
