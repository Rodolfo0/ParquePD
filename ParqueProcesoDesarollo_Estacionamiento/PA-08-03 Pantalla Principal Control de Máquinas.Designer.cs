﻿namespace ParqueProcesoDesarollo_Estacionamiento
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
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.btnComprobarMonto = new MetroFramework.Controls.MetroButton();
            this.btnRegistrarMonto = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(677, 105);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 7;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // btnComprobarMonto
            // 
            this.btnComprobarMonto.Location = new System.Drawing.Point(608, 373);
            this.btnComprobarMonto.Name = "btnComprobarMonto";
            this.btnComprobarMonto.Size = new System.Drawing.Size(144, 44);
            this.btnComprobarMonto.TabIndex = 6;
            this.btnComprobarMonto.Text = "Comprobar Monto Actual";
            this.btnComprobarMonto.UseSelectable = true;
            this.btnComprobarMonto.Click += new System.EventHandler(this.btnComprobarMonto_Click);
            // 
            // btnRegistrarMonto
            // 
            this.btnRegistrarMonto.Location = new System.Drawing.Point(449, 373);
            this.btnRegistrarMonto.Name = "btnRegistrarMonto";
            this.btnRegistrarMonto.Size = new System.Drawing.Size(144, 44);
            this.btnRegistrarMonto.TabIndex = 5;
            this.btnRegistrarMonto.Text = "Registrar Monto Inicial";
            this.btnRegistrarMonto.UseSelectable = true;
            this.btnRegistrarMonto.Click += new System.EventHandler(this.btnRegistrarMonto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 156);
            this.label1.TabIndex = 4;
            this.label1.Text = "ESTACIONAMIENTO\r\nFUZZY ROAD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(6, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // frmPantallaPrincipalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 440);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnComprobarMonto);
            this.Controls.Add(this.btnRegistrarMonto);
            this.Controls.Add(this.label1);
            this.Name = "frmPantallaPrincipalControl";
            this.Resizable = false;
            this.Text = "PA-08-03 Pantalla Principal Control de Máquinas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPantallaPrincipalControl_FormClosed);
            this.Load += new System.EventHandler(this.frmPantallaPrincipalControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblRegresar;
        private MetroFramework.Controls.MetroButton btnComprobarMonto;
        private MetroFramework.Controls.MetroButton btnRegistrarMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}