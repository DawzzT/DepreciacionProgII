
namespace practicaDepreciacion
{
    partial class FrmActivo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.txtVidaU = new System.Windows.Forms.TextBox();
            this.txtValorR = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEnviar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vida util";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Valor residual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Valor";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(35, 7);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(44, 13);
            this.Nombre.TabIndex = 14;
            this.Nombre.Text = "Nombre";
            // 
            // txtVidaU
            // 
            this.txtVidaU.Location = new System.Drawing.Point(100, 141);
            this.txtVidaU.Name = "txtVidaU";
            this.txtVidaU.Size = new System.Drawing.Size(100, 20);
            this.txtVidaU.TabIndex = 13;
            this.txtVidaU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVidaU_KeyPress);
            // 
            // txtValorR
            // 
            this.txtValorR.Location = new System.Drawing.Point(100, 100);
            this.txtValorR.Name = "txtValorR";
            this.txtValorR.Size = new System.Drawing.Size(100, 20);
            this.txtValorR.TabIndex = 12;
            this.txtValorR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorR_KeyPress);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(100, 53);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(100, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtEnviar
            // 
            this.txtEnviar.Location = new System.Drawing.Point(62, 184);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(75, 23);
            this.txtEnviar.TabIndex = 9;
            this.txtEnviar.Text = "Enviar";
            this.txtEnviar.UseVisualStyleBackColor = true;
            this.txtEnviar.Click += new System.EventHandler(this.txtEnviar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(62, 184);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // FrmActivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 218);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.txtVidaU);
            this.Controls.Add(this.txtValorR);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtEnviar);
            this.Name = "FrmActivo";
            this.Text = "FrmActivo";
            this.Load += new System.EventHandler(this.FrmActivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.TextBox txtVidaU;
        private System.Windows.Forms.TextBox txtValorR;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button txtEnviar;
        private System.Windows.Forms.Button btnModificar;
    }
}