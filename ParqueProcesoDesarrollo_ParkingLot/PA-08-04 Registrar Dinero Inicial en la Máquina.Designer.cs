namespace CU_08_Pago_Estacionamiento
{
    partial class frmDineroInicial
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
            this.btnIngresarMonto = new MetroFramework.Controls.MetroButton();
            this.btnRegresar = new MetroFramework.Controls.MetroButton();
            this.txtMonedas5 = new MetroFramework.Controls.MetroTextBox();
            this.txtMonedas10 = new MetroFramework.Controls.MetroTextBox();
            this.txtBilletes50 = new MetroFramework.Controls.MetroTextBox();
            this.txtBilletes100 = new MetroFramework.Controls.MetroTextBox();
            this.cmbMaquinas = new MetroFramework.Controls.MetroComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresarMonto
            // 
            this.btnIngresarMonto.Location = new System.Drawing.Point(599, 341);
            this.btnIngresarMonto.Name = "btnIngresarMonto";
            this.btnIngresarMonto.Size = new System.Drawing.Size(144, 44);
            this.btnIngresarMonto.TabIndex = 4;
            this.btnIngresarMonto.Text = "Ingresar Monto";
            this.btnIngresarMonto.UseSelectable = true;
            this.btnIngresarMonto.Click += new System.EventHandler(this.btnIngresarMonto_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(438, 341);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(144, 44);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Volver";
            this.btnRegresar.UseSelectable = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // txtMonedas5
            // 
            // 
            // 
            // 
            this.txtMonedas5.CustomButton.Image = null;
            this.txtMonedas5.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.txtMonedas5.CustomButton.Name = "";
            this.txtMonedas5.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtMonedas5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMonedas5.CustomButton.TabIndex = 1;
            this.txtMonedas5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMonedas5.CustomButton.UseSelectable = true;
            this.txtMonedas5.CustomButton.Visible = false;
            this.txtMonedas5.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtMonedas5.Lines = new string[0];
            this.txtMonedas5.Location = new System.Drawing.Point(196, 131);
            this.txtMonedas5.MaxLength = 32767;
            this.txtMonedas5.Name = "txtMonedas5";
            this.txtMonedas5.PasswordChar = '\0';
            this.txtMonedas5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMonedas5.SelectedText = "";
            this.txtMonedas5.SelectionLength = 0;
            this.txtMonedas5.SelectionStart = 0;
            this.txtMonedas5.ShortcutsEnabled = true;
            this.txtMonedas5.Size = new System.Drawing.Size(100, 35);
            this.txtMonedas5.TabIndex = 7;
            this.txtMonedas5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonedas5.UseSelectable = true;
            this.txtMonedas5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMonedas5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMonedas10
            // 
            // 
            // 
            // 
            this.txtMonedas10.CustomButton.Image = null;
            this.txtMonedas10.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.txtMonedas10.CustomButton.Name = "";
            this.txtMonedas10.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtMonedas10.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMonedas10.CustomButton.TabIndex = 1;
            this.txtMonedas10.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMonedas10.CustomButton.UseSelectable = true;
            this.txtMonedas10.CustomButton.Visible = false;
            this.txtMonedas10.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtMonedas10.Lines = new string[0];
            this.txtMonedas10.Location = new System.Drawing.Point(196, 261);
            this.txtMonedas10.MaxLength = 32767;
            this.txtMonedas10.Name = "txtMonedas10";
            this.txtMonedas10.PasswordChar = '\0';
            this.txtMonedas10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMonedas10.SelectedText = "";
            this.txtMonedas10.SelectionLength = 0;
            this.txtMonedas10.SelectionStart = 0;
            this.txtMonedas10.ShortcutsEnabled = true;
            this.txtMonedas10.Size = new System.Drawing.Size(100, 35);
            this.txtMonedas10.TabIndex = 8;
            this.txtMonedas10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonedas10.UseSelectable = true;
            this.txtMonedas10.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMonedas10.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBilletes50
            // 
            // 
            // 
            // 
            this.txtBilletes50.CustomButton.Image = null;
            this.txtBilletes50.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.txtBilletes50.CustomButton.Name = "";
            this.txtBilletes50.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtBilletes50.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBilletes50.CustomButton.TabIndex = 1;
            this.txtBilletes50.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBilletes50.CustomButton.UseSelectable = true;
            this.txtBilletes50.CustomButton.Visible = false;
            this.txtBilletes50.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtBilletes50.Lines = new string[0];
            this.txtBilletes50.Location = new System.Drawing.Point(589, 131);
            this.txtBilletes50.MaxLength = 32767;
            this.txtBilletes50.Name = "txtBilletes50";
            this.txtBilletes50.PasswordChar = '\0';
            this.txtBilletes50.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBilletes50.SelectedText = "";
            this.txtBilletes50.SelectionLength = 0;
            this.txtBilletes50.SelectionStart = 0;
            this.txtBilletes50.ShortcutsEnabled = true;
            this.txtBilletes50.Size = new System.Drawing.Size(100, 35);
            this.txtBilletes50.TabIndex = 9;
            this.txtBilletes50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBilletes50.UseSelectable = true;
            this.txtBilletes50.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBilletes50.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBilletes100
            // 
            // 
            // 
            // 
            this.txtBilletes100.CustomButton.Image = null;
            this.txtBilletes100.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.txtBilletes100.CustomButton.Name = "";
            this.txtBilletes100.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtBilletes100.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBilletes100.CustomButton.TabIndex = 1;
            this.txtBilletes100.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBilletes100.CustomButton.UseSelectable = true;
            this.txtBilletes100.CustomButton.Visible = false;
            this.txtBilletes100.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtBilletes100.Lines = new string[0];
            this.txtBilletes100.Location = new System.Drawing.Point(589, 261);
            this.txtBilletes100.MaxLength = 32767;
            this.txtBilletes100.Name = "txtBilletes100";
            this.txtBilletes100.PasswordChar = '\0';
            this.txtBilletes100.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBilletes100.SelectedText = "";
            this.txtBilletes100.SelectionLength = 0;
            this.txtBilletes100.SelectionStart = 0;
            this.txtBilletes100.ShortcutsEnabled = true;
            this.txtBilletes100.Size = new System.Drawing.Size(100, 35);
            this.txtBilletes100.TabIndex = 10;
            this.txtBilletes100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBilletes100.UseSelectable = true;
            this.txtBilletes100.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBilletes100.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbMaquinas
            // 
            this.cmbMaquinas.FormattingEnabled = true;
            this.cmbMaquinas.ItemHeight = 23;
            this.cmbMaquinas.Location = new System.Drawing.Point(561, 63);
            this.cmbMaquinas.Name = "cmbMaquinas";
            this.cmbMaquinas.Size = new System.Drawing.Size(182, 29);
            this.cmbMaquinas.TabIndex = 12;
            this.cmbMaquinas.UseSelectable = true;
            this.cmbMaquinas.SelectedIndexChanged += new System.EventHandler(this.cmbMaquinas_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CU_08_Pago_Estacionamiento.Properties.Resources.Billete_de_100_pesos;
            this.pictureBox3.Location = new System.Drawing.Point(396, 237);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(151, 83);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CU_08_Pago_Estacionamiento.Properties.Resources.Billete_de_50_pesos;
            this.pictureBox4.Location = new System.Drawing.Point(396, 108);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(151, 83);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CU_08_Pago_Estacionamiento.Properties.Resources.Moneda_de_10_pesos;
            this.pictureBox2.Location = new System.Drawing.Point(73, 237);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CU_08_Pago_Estacionamiento.Properties.Resources.Moneda_de_5_pesos;
            this.pictureBox1.Location = new System.Drawing.Point(73, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmDineroInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 408);
            this.Controls.Add(this.cmbMaquinas);
            this.Controls.Add(this.txtBilletes100);
            this.Controls.Add(this.txtBilletes50);
            this.Controls.Add(this.txtMonedas10);
            this.Controls.Add(this.txtMonedas5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnIngresarMonto);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDineroInicial";
            this.Text = "PA-08-04 Registrar Dinero Inicial en la Máquina";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDineroInicial_FormClosed);
            this.Load += new System.EventHandler(this.frmDineroInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton btnIngresarMonto;
        private MetroFramework.Controls.MetroButton btnRegresar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private MetroFramework.Controls.MetroTextBox txtMonedas5;
        private MetroFramework.Controls.MetroTextBox txtMonedas10;
        private MetroFramework.Controls.MetroTextBox txtBilletes50;
        private MetroFramework.Controls.MetroTextBox txtBilletes100;
        private MetroFramework.Controls.MetroComboBox cmbMaquinas;
    }
}