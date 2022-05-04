namespace ParqueProcesoDesarollo_Estacionamiento
{
    partial class frmSalidaEstacionamiento
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
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.txtHoraActual = new MetroFramework.Controls.MetroLabel();
            this.txtFechaActual = new MetroFramework.Controls.MetroLabel();
            this.txtNumeroMaquina = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresarBoleto = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(682, 83);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 13;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // txtHoraActual
            // 
            this.txtHoraActual.AutoSize = true;
            this.txtHoraActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraActual.Location = new System.Drawing.Point(339, 309);
            this.txtHoraActual.Name = "txtHoraActual";
            this.txtHoraActual.Size = new System.Drawing.Size(101, 25);
            this.txtHoraActual.TabIndex = 19;
            this.txtHoraActual.Text = "Hora Actual";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.AutoSize = true;
            this.txtFechaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFechaActual.Location = new System.Drawing.Point(613, 152);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(108, 25);
            this.txtFechaActual.TabIndex = 18;
            this.txtFechaActual.Text = "Fecha Actual";
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.AutoSize = true;
            this.txtNumeroMaquina.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtNumeroMaquina.Location = new System.Drawing.Point(23, 152);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(171, 25);
            this.txtNumeroMaquina.TabIndex = 17;
            this.txtNumeroMaquina.Text = "Número de Máquina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 116);
            this.label1.TabIndex = 16;
            this.label1.Text = "BIENVENIDO A\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIngresarBoleto
            // 
            this.btnIngresarBoleto.Location = new System.Drawing.Point(613, 373);
            this.btnIngresarBoleto.Name = "btnIngresarBoleto";
            this.btnIngresarBoleto.Size = new System.Drawing.Size(144, 44);
            this.btnIngresarBoleto.TabIndex = 20;
            this.btnIngresarBoleto.Text = "Ingresar Boleto";
            this.btnIngresarBoleto.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(6, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // frmSalidaEstacionamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 440);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIngresarBoleto);
            this.Controls.Add(this.txtHoraActual);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRegresar);
            this.Name = "frmSalidaEstacionamiento";
            this.Resizable = false;
            this.Text = "PA-08-12 Salida del Estacionamiento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalidaEstacionamiento_FormClosed);
            this.Load += new System.EventHandler(this.PA_08_12_Salida_del_Estacionamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblRegresar;
        private MetroFramework.Controls.MetroLabel txtHoraActual;
        private MetroFramework.Controls.MetroLabel txtFechaActual;
        private MetroFramework.Controls.MetroLabel txtNumeroMaquina;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btnIngresarBoleto;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}