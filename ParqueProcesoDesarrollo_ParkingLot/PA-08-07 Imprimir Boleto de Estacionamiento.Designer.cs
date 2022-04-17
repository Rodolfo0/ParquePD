namespace CU_08_Pago_Estacionamiento
{
    partial class frmImprimirBoletoEstacionamiento
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
            this.btnImprimirBoleto = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroMaquina = new MetroFramework.Controls.MetroLabel();
            this.txtFechaActual = new MetroFramework.Controls.MetroLabel();
            this.txtHoraActual = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(661, 26);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 6;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // btnImprimirBoleto
            // 
            this.btnImprimirBoleto.Location = new System.Drawing.Point(592, 332);
            this.btnImprimirBoleto.Name = "btnImprimirBoleto";
            this.btnImprimirBoleto.Size = new System.Drawing.Size(144, 44);
            this.btnImprimirBoleto.TabIndex = 5;
            this.btnImprimirBoleto.Text = "Imprimir Boleto";
            this.btnImprimirBoleto.UseSelectable = true;
            this.btnImprimirBoleto.Click += new System.EventHandler(this.btnImprimirBoleto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 116);
            this.label1.TabIndex = 4;
            this.label1.Text = "BIENVENIDO A\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.AutoSize = true;
            this.txtNumeroMaquina.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtNumeroMaquina.Location = new System.Drawing.Point(23, 81);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(171, 25);
            this.txtNumeroMaquina.TabIndex = 7;
            this.txtNumeroMaquina.Text = "Número de Máquina";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.AutoSize = true;
            this.txtFechaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFechaActual.Location = new System.Drawing.Point(628, 81);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(108, 25);
            this.txtFechaActual.TabIndex = 8;
            this.txtFechaActual.Text = "Fecha Actual";
            // 
            // txtHoraActual
            // 
            this.txtHoraActual.AutoSize = true;
            this.txtHoraActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraActual.Location = new System.Drawing.Point(328, 269);
            this.txtHoraActual.Name = "txtHoraActual";
            this.txtHoraActual.Size = new System.Drawing.Size(101, 25);
            this.txtHoraActual.TabIndex = 9;
            this.txtHoraActual.Text = "Hora Actual";
            // 
            // frmImprimirBoletoEstacionamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 408);
            this.Controls.Add(this.txtHoraActual);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnImprimirBoleto);
            this.Controls.Add(this.label1);
            this.Name = "frmImprimirBoletoEstacionamiento";
            this.Text = "PA-08-07 Imprimir Boleto de Estacionamiento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImprimirBoletoEstacionamiento_FormClosed);
            this.Load += new System.EventHandler(this.frmImprimirBoletoEstacionamiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblRegresar;
        private MetroFramework.Controls.MetroButton btnImprimirBoleto;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLabel txtNumeroMaquina;
        private MetroFramework.Controls.MetroLabel txtFechaActual;
        private MetroFramework.Controls.MetroLabel txtHoraActual;
    }
}