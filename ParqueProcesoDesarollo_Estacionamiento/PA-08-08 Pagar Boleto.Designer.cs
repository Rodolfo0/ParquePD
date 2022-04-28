namespace ParqueProcesoDesarollo_Estacionamiento
{
    partial class frmPagarBoleto
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtHoraActual = new MetroFramework.Controls.MetroLabel();
            this.txtFechaActual = new MetroFramework.Controls.MetroLabel();
            this.txtNumeroMaquina = new MetroFramework.Controls.MetroLabel();
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.btnPagarBoleto = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(1393, 951);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(456, 125);
            this.metroButton1.TabIndex = 23;
            this.metroButton1.Text = "He Perdido Mi Boleto";
            this.metroButton1.UseSelectable = true;
            // 
            // txtHoraActual
            // 
            this.txtHoraActual.AutoSize = true;
            this.txtHoraActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraActual.Location = new System.Drawing.Point(1054, 754);
            this.txtHoraActual.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtHoraActual.Name = "txtHoraActual";
            this.txtHoraActual.Size = new System.Drawing.Size(101, 25);
            this.txtHoraActual.TabIndex = 22;
            this.txtHoraActual.Text = "Hora Actual";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.AutoSize = true;
            this.txtFechaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFechaActual.Location = new System.Drawing.Point(2014, 329);
            this.txtFechaActual.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(108, 25);
            this.txtFechaActual.TabIndex = 21;
            this.txtFechaActual.Text = "Fecha Actual";
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.AutoSize = true;
            this.txtNumeroMaquina.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtNumeroMaquina.Location = new System.Drawing.Point(153, 329);
            this.txtNumeroMaquina.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(171, 25);
            this.txtNumeroMaquina.TabIndex = 20;
            this.txtNumeroMaquina.Text = "Número de Máquina";
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(2281, 260);
            this.lblRegresar.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 19;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // btnPagarBoleto
            // 
            this.btnPagarBoleto.Location = new System.Drawing.Point(1900, 951);
            this.btnPagarBoleto.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.btnPagarBoleto.Name = "btnPagarBoleto";
            this.btnPagarBoleto.Size = new System.Drawing.Size(456, 125);
            this.btnPagarBoleto.TabIndex = 18;
            this.btnPagarBoleto.Text = "Pagar Boleto";
            this.btnPagarBoleto.UseSelectable = true;
            this.btnPagarBoleto.Click += new System.EventHandler(this.btnPagarBoleto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(656, 384);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1075, 346);
            this.label1.TabIndex = 17;
            this.label1.Text = "BIENVENIDO A\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(15, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2428, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // frmPagarBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2454, 1161);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtHoraActual);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnPagarBoleto);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "frmPagarBoleto";
            this.Padding = new System.Windows.Forms.Padding(63, 171, 63, 57);
            this.Resizable = false;
            this.Text = "PA-08-08 Pagar Boleto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPagarBoleto_FormClosed);
            this.Load += new System.EventHandler(this.frmPagarBoleto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel txtHoraActual;
        private MetroFramework.Controls.MetroLabel txtFechaActual;
        private MetroFramework.Controls.MetroLabel txtNumeroMaquina;
        private MetroFramework.Controls.MetroLabel lblRegresar;
        private MetroFramework.Controls.MetroButton btnPagarBoleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}