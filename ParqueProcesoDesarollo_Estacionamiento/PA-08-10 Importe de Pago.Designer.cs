namespace ParqueProcesoDesarollo_Estacionamiento
{
    partial class frmImportePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportePago));
            this.txtFolio = new MetroFramework.Controls.MetroLabel();
            this.txtFechaActual = new MetroFramework.Controls.MetroLabel();
            this.txtHoraEntrada = new MetroFramework.Controls.MetroLabel();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmarPago = new MetroFramework.Controls.MetroButton();
            this.txtHoraSalida = new MetroFramework.Controls.MetroLabel();
            this.txtMonedas10 = new MetroFramework.Controls.MetroTextBox();
            this.txtMonedas5 = new MetroFramework.Controls.MetroTextBox();
            this.txtBilletes50 = new MetroFramework.Controls.MetroTextBox();
            this.txtBilletes100 = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFolio
            // 
            this.txtFolio.AutoSize = true;
            this.txtFolio.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFolio.Location = new System.Drawing.Point(830, 413);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(129, 25);
            this.txtFolio.TabIndex = 20;
            this.txtFolio.Text = "Folio de boleto:";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.AutoSize = true;
            this.txtFechaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtFechaActual.Location = new System.Drawing.Point(133, 308);
            this.txtFechaActual.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(108, 25);
            this.txtFechaActual.TabIndex = 19;
            this.txtFechaActual.Text = "Fecha Actual";
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.AutoSize = true;
            this.txtHoraEntrada.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraEntrada.Location = new System.Drawing.Point(1577, 257);
            this.txtHoraEntrada.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(112, 25);
            this.txtHoraEntrada.TabIndex = 18;
            this.txtHoraEntrada.Text = "Hora Entrada";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1919, 971);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(456, 125);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1032, 467);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(496, 173);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "TOTAL";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirmarPago
            // 
            this.btnConfirmarPago.Location = new System.Drawing.Point(1434, 971);
            this.btnConfirmarPago.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.btnConfirmarPago.Name = "btnConfirmarPago";
            this.btnConfirmarPago.Size = new System.Drawing.Size(456, 125);
            this.btnConfirmarPago.TabIndex = 21;
            this.btnConfirmarPago.Text = "Confirmar Pago";
            this.btnConfirmarPago.UseSelectable = true;
            this.btnConfirmarPago.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // btnImprimirRecibo
            // 
            this.btnImprimirRecibo.Location = new System.Drawing.Point(947, 971);
            this.btnImprimirRecibo.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.btnImprimirRecibo.Name = "btnImprimirRecibo";
            this.btnImprimirRecibo.Size = new System.Drawing.Size(456, 125);
            this.btnImprimirRecibo.TabIndex = 22;
            this.btnImprimirRecibo.Text = "Imprimir Recibo";
            this.btnImprimirRecibo.UseSelectable = true;
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.AutoSize = true;
            this.txtHoraSalida.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtHoraSalida.Location = new System.Drawing.Point(1577, 328);
            this.txtHoraSalida.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(99, 25);
            this.txtHoraSalida.TabIndex = 23;
            this.txtHoraSalida.Text = "Hora Salida";
            // 
            // txtMonedas10
            // 
            // 
            // 
            // 
            this.txtMonedas10.CustomButton.Image = null;
            this.txtMonedas10.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtMonedas10.CustomButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtMonedas10.CustomButton.Name = "";
            this.txtMonedas10.CustomButton.Size = new System.Drawing.Size(95, 95);
            this.txtMonedas10.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMonedas10.CustomButton.TabIndex = 1;
            this.txtMonedas10.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMonedas10.CustomButton.UseSelectable = true;
            this.txtMonedas10.CustomButton.Visible = false;
            this.txtMonedas10.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMonedas10.Lines = new string[0];
            this.txtMonedas10.Location = new System.Drawing.Point(855, 774);
            this.txtMonedas10.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtMonedas10.MaxLength = 32767;
            this.txtMonedas10.Name = "txtMonedas10";
            this.txtMonedas10.PasswordChar = '\0';
            this.txtMonedas10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMonedas10.SelectedText = "";
            this.txtMonedas10.SelectionLength = 0;
            this.txtMonedas10.SelectionStart = 0;
            this.txtMonedas10.ShortcutsEnabled = true;
            this.txtMonedas10.Size = new System.Drawing.Size(203, 100);
            this.txtMonedas10.TabIndex = 25;
            this.txtMonedas10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonedas10.UseSelectable = true;
            this.txtMonedas10.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMonedas10.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // txtMonedas5
            // 
            // 
            // 
            // 
            this.txtMonedas5.CustomButton.Image = null;
            this.txtMonedas5.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtMonedas5.CustomButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtMonedas5.CustomButton.Name = "";
            this.txtMonedas5.CustomButton.Size = new System.Drawing.Size(95, 95);
            this.txtMonedas5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMonedas5.CustomButton.TabIndex = 1;
            this.txtMonedas5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMonedas5.CustomButton.UseSelectable = true;
            this.txtMonedas5.CustomButton.Visible = false;
            this.txtMonedas5.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMonedas5.Lines = new string[0];
            this.txtMonedas5.Location = new System.Drawing.Point(355, 774);
            this.txtMonedas5.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtMonedas5.MaxLength = 32767;
            this.txtMonedas5.Name = "txtMonedas5";
            this.txtMonedas5.PasswordChar = '\0';
            this.txtMonedas5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMonedas5.SelectedText = "";
            this.txtMonedas5.SelectionLength = 0;
            this.txtMonedas5.SelectionStart = 0;
            this.txtMonedas5.ShortcutsEnabled = true;
            this.txtMonedas5.Size = new System.Drawing.Size(203, 100);
            this.txtMonedas5.TabIndex = 35;
            this.txtMonedas5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonedas5.UseSelectable = true;
            this.txtMonedas5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMonedas5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // txtBilletes50
            // 
            // 
            // 
            // 
            this.txtBilletes50.CustomButton.Image = null;
            this.txtBilletes50.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtBilletes50.CustomButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtBilletes50.CustomButton.Name = "";
            this.txtBilletes50.CustomButton.Size = new System.Drawing.Size(95, 95);
            this.txtBilletes50.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBilletes50.CustomButton.TabIndex = 1;
            this.txtBilletes50.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBilletes50.CustomButton.UseSelectable = true;
            this.txtBilletes50.CustomButton.Visible = false;
            this.txtBilletes50.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtBilletes50.Lines = new string[0];
            this.txtBilletes50.Location = new System.Drawing.Point(1513, 774);
            this.txtBilletes50.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtBilletes50.MaxLength = 32767;
            this.txtBilletes50.Name = "txtBilletes50";
            this.txtBilletes50.PasswordChar = '\0';
            this.txtBilletes50.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBilletes50.SelectedText = "";
            this.txtBilletes50.SelectionLength = 0;
            this.txtBilletes50.SelectionStart = 0;
            this.txtBilletes50.ShortcutsEnabled = true;
            this.txtBilletes50.Size = new System.Drawing.Size(203, 100);
            this.txtBilletes50.TabIndex = 36;
            this.txtBilletes50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBilletes50.UseSelectable = true;
            this.txtBilletes50.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBilletes50.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // txtBilletes100
            // 
            // 
            // 
            // 
            this.txtBilletes100.CustomButton.Image = null;
            this.txtBilletes100.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtBilletes100.CustomButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtBilletes100.CustomButton.Name = "";
            this.txtBilletes100.CustomButton.Size = new System.Drawing.Size(95, 95);
            this.txtBilletes100.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBilletes100.CustomButton.TabIndex = 1;
            this.txtBilletes100.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBilletes100.CustomButton.UseSelectable = true;
            this.txtBilletes100.CustomButton.Visible = false;
            this.txtBilletes100.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtBilletes100.Lines = new string[0];
            this.txtBilletes100.Location = new System.Drawing.Point(2190, 774);
            this.txtBilletes100.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtBilletes100.MaxLength = 32767;
            this.txtBilletes100.Name = "txtBilletes100";
            this.txtBilletes100.PasswordChar = '\0';
            this.txtBilletes100.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBilletes100.SelectedText = "";
            this.txtBilletes100.SelectionLength = 0;
            this.txtBilletes100.SelectionStart = 0;
            this.txtBilletes100.ShortcutsEnabled = true;
            this.txtBilletes100.Size = new System.Drawing.Size(203, 100);
            this.txtBilletes100.TabIndex = 37;
            this.txtBilletes100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBilletes100.UseSelectable = true;
            this.txtBilletes100.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBilletes100.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1858, 754);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(162, 745);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(173, 207);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Billete_de_50_pesos;
            this.pictureBox4.Location = new System.Drawing.Point(1181, 754);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(312, 143);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Moneda_de_10_pesos;
            this.pictureBox2.Location = new System.Drawing.Point(680, 745);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 187);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox5.Location = new System.Drawing.Point(13, 65);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(2428, 177);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 50;
            this.pictureBox5.TabStop = false;
            // 
            // frmImportePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2454, 1165);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtBilletes100);
            this.Controls.Add(this.txtBilletes50);
            this.Controls.Add(this.txtMonedas5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtMonedas10);
            this.Controls.Add(this.txtHoraSalida);
            this.Controls.Add(this.btnConfirmarPago);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.txtHoraEntrada);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTotal);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "frmImportePago";
            this.Padding = new System.Windows.Forms.Padding(63, 171, 63, 57);
            this.Resizable = false;
            this.Text = "PA-08-10 Importe de Pago";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportePago_FormClosed);
            this.Load += new System.EventHandler(this.frmImportePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel txtFolio;
        private MetroFramework.Controls.MetroLabel txtFechaActual;
        private MetroFramework.Controls.MetroLabel txtHoraEntrada;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private System.Windows.Forms.Label lblTotal;
        private MetroFramework.Controls.MetroButton btnConfirmarPago;
        private MetroFramework.Controls.MetroLabel txtHoraSalida;
        private MetroFramework.Controls.MetroTextBox txtMonedas10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroTextBox txtMonedas5;
        private MetroFramework.Controls.MetroTextBox txtBilletes50;
        private MetroFramework.Controls.MetroTextBox txtBilletes100;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}