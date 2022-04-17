namespace CU_08_Pago_Estacionamiento
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
            this.txtHoraActual = new MetroFramework.Controls.MetroLabel();
            this.txtFechaActual = new MetroFramework.Controls.MetroLabel();
            this.txtNumeroMaquina = new MetroFramework.Controls.MetroLabel();
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.btnPagarBoleto = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtHoraActual
            // 
            this.txtHoraActual.AutoSize = true;
            this.txtHoraActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraActual.Location = new System.Drawing.Point(333, 265);
            this.txtHoraActual.Name = "txtHoraActual";
            this.txtHoraActual.Size = new System.Drawing.Size(101, 25);
            this.txtHoraActual.TabIndex = 15;
            this.txtHoraActual.Text = "Hora Actual";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.AutoSize = true;
            this.txtFechaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFechaActual.Location = new System.Drawing.Point(636, 84);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(108, 25);
            this.txtFechaActual.TabIndex = 14;
            this.txtFechaActual.Text = "Fecha Actual";
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.AutoSize = true;
            this.txtNumeroMaquina.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtNumeroMaquina.Location = new System.Drawing.Point(31, 84);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(171, 25);
            this.txtNumeroMaquina.TabIndex = 13;
            this.txtNumeroMaquina.Text = "Número de Máquina";
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(669, 30);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 12;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // btnPagarBoleto
            // 
            this.btnPagarBoleto.Location = new System.Drawing.Point(600, 334);
            this.btnPagarBoleto.Name = "btnPagarBoleto";
            this.btnPagarBoleto.Size = new System.Drawing.Size(144, 44);
            this.btnPagarBoleto.TabIndex = 11;
            this.btnPagarBoleto.Text = "Pagar Boleto";
            this.btnPagarBoleto.UseSelectable = true;
            this.btnPagarBoleto.Click += new System.EventHandler(this.btnPagarBoleto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 116);
            this.label1.TabIndex = 10;
            this.label1.Text = "BIENVENIDO A\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(440, 334);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(144, 44);
            this.metroButton1.TabIndex = 16;
            this.metroButton1.Text = "He Perdido Mi Boleto";
            this.metroButton1.UseSelectable = true;
            // 
            // frmPagarBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 408);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtHoraActual);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnPagarBoleto);
            this.Controls.Add(this.label1);
            this.Name = "frmPagarBoleto";
            this.Text = "PA-08-08 Pagar Boleto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPagarBoleto_FormClosed);
            this.Load += new System.EventHandler(this.frmPagarBoleto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel txtHoraActual;
        private MetroFramework.Controls.MetroLabel txtFechaActual;
        private MetroFramework.Controls.MetroLabel txtNumeroMaquina;
        private MetroFramework.Controls.MetroLabel lblRegresar;
        private MetroFramework.Controls.MetroButton btnPagarBoleto;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}