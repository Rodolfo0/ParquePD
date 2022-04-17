namespace CU_08_Pago_Estacionamiento
{
    partial class frmPantallaPrincipal
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
            this.tlControlMaquinasCobro = new MetroFramework.Controls.MetroTile();
            this.tlMaquinaCobro = new MetroFramework.Controls.MetroTile();
            this.tlMaquinaAcceso = new MetroFramework.Controls.MetroTile();
            this.tlMaquinaSalida = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // tlControlMaquinasCobro
            // 
            this.tlControlMaquinasCobro.ActiveControl = null;
            this.tlControlMaquinasCobro.Location = new System.Drawing.Point(100, 76);
            this.tlControlMaquinasCobro.Name = "tlControlMaquinasCobro";
            this.tlControlMaquinasCobro.Size = new System.Drawing.Size(334, 162);
            this.tlControlMaquinasCobro.TabIndex = 0;
            this.tlControlMaquinasCobro.Text = "Control de Máquinas de Cobro";
            this.tlControlMaquinasCobro.UseSelectable = true;
            this.tlControlMaquinasCobro.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // tlMaquinaCobro
            // 
            this.tlMaquinaCobro.ActiveControl = null;
            this.tlMaquinaCobro.Location = new System.Drawing.Point(100, 244);
            this.tlMaquinaCobro.Name = "tlMaquinaCobro";
            this.tlMaquinaCobro.Size = new System.Drawing.Size(167, 135);
            this.tlMaquinaCobro.TabIndex = 1;
            this.tlMaquinaCobro.Text = "Máquina de Cobro";
            this.tlMaquinaCobro.UseSelectable = true;
            this.tlMaquinaCobro.Click += new System.EventHandler(this.tlMaquinaCobro_Click);
            // 
            // tlMaquinaAcceso
            // 
            this.tlMaquinaAcceso.ActiveControl = null;
            this.tlMaquinaAcceso.Location = new System.Drawing.Point(440, 76);
            this.tlMaquinaAcceso.Name = "tlMaquinaAcceso";
            this.tlMaquinaAcceso.Size = new System.Drawing.Size(210, 303);
            this.tlMaquinaAcceso.TabIndex = 2;
            this.tlMaquinaAcceso.Text = "Máquina de Acceso";
            this.tlMaquinaAcceso.UseSelectable = true;
            this.tlMaquinaAcceso.Click += new System.EventHandler(this.tlMaquinaAcceso_Click);
            // 
            // tlMaquinaSalida
            // 
            this.tlMaquinaSalida.ActiveControl = null;
            this.tlMaquinaSalida.Location = new System.Drawing.Point(273, 244);
            this.tlMaquinaSalida.Name = "tlMaquinaSalida";
            this.tlMaquinaSalida.Size = new System.Drawing.Size(161, 135);
            this.tlMaquinaSalida.TabIndex = 3;
            this.tlMaquinaSalida.Text = "Máquina de Salida";
            this.tlMaquinaSalida.UseSelectable = true;
            this.tlMaquinaSalida.Click += new System.EventHandler(this.tlMaquinaSalida_Click);
            // 
            // frmPantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 408);
            this.Controls.Add(this.tlMaquinaSalida);
            this.Controls.Add(this.tlMaquinaAcceso);
            this.Controls.Add(this.tlMaquinaCobro);
            this.Controls.Add(this.tlControlMaquinasCobro);
            this.Name = "frmPantallaPrincipal";
            this.Text = "PA-08-02 Pantalla Principal Estacionamiento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPantallaPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPantallaPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile tlControlMaquinasCobro;
        private MetroFramework.Controls.MetroTile tlMaquinaCobro;
        private MetroFramework.Controls.MetroTile tlMaquinaAcceso;
        private MetroFramework.Controls.MetroTile tlMaquinaSalida;
    }
}