﻿namespace CU_08_Pago_Estacionamiento
{
    partial class frmPantallaPrincipalControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarMonto = new MetroFramework.Controls.MetroButton();
            this.btnComprobarMonto = new MetroFramework.Controls.MetroButton();
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 156);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTACIONAMIENTO\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegistrarMonto
            // 
            this.btnRegistrarMonto.Location = new System.Drawing.Point(433, 321);
            this.btnRegistrarMonto.Name = "btnRegistrarMonto";
            this.btnRegistrarMonto.Size = new System.Drawing.Size(144, 44);
            this.btnRegistrarMonto.TabIndex = 1;
            this.btnRegistrarMonto.Text = "Registrar Monto Inicial";
            this.btnRegistrarMonto.UseSelectable = true;
            this.btnRegistrarMonto.Click += new System.EventHandler(this.btnRegistrarMonto_Click);
            // 
            // btnComprobarMonto
            // 
            this.btnComprobarMonto.Location = new System.Drawing.Point(595, 321);
            this.btnComprobarMonto.Name = "btnComprobarMonto";
            this.btnComprobarMonto.Size = new System.Drawing.Size(144, 44);
            this.btnComprobarMonto.TabIndex = 2;
            this.btnComprobarMonto.Text = "Comprobar Monto Actual";
            this.btnComprobarMonto.UseSelectable = true;
            this.btnComprobarMonto.Click += new System.EventHandler(this.btnComprobarMonto_Click);
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(664, 60);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 3;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // frmPantallaPrincipalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 408);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnComprobarMonto);
            this.Controls.Add(this.btnRegistrarMonto);
            this.Controls.Add(this.label1);
            this.Name = "frmPantallaPrincipalControl";
            this.Text = "PA-08-03 Pantalla Principal Control de Máquinas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPantallaPrincipalControl_FormClosed);
            this.Load += new System.EventHandler(this.frmPantallaPrincipalControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btnRegistrarMonto;
        private MetroFramework.Controls.MetroButton btnComprobarMonto;
        private MetroFramework.Controls.MetroLabel lblRegresar;
    }
}