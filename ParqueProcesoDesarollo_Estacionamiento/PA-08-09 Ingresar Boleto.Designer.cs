namespace ParqueProcesoDesarollo_Estacionamiento
{
    partial class frmIngresarBoleto
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
            this.txtIngresarBoleto = new MetroFramework.Controls.MetroTextBox();
            this.btnIngresarBoleto = new MetroFramework.Controls.MetroButton();
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // txtIngresarBoleto
            // 
            // 
            // 
            // 
            this.txtIngresarBoleto.CustomButton.Image = null;
            this.txtIngresarBoleto.CustomButton.Location = new System.Drawing.Point(169, 1);
            this.txtIngresarBoleto.CustomButton.Name = "";
            this.txtIngresarBoleto.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtIngresarBoleto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIngresarBoleto.CustomButton.TabIndex = 1;
            this.txtIngresarBoleto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIngresarBoleto.CustomButton.UseSelectable = true;
            this.txtIngresarBoleto.CustomButton.Visible = false;
            this.txtIngresarBoleto.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtIngresarBoleto.Lines = new string[0];
            this.txtIngresarBoleto.Location = new System.Drawing.Point(58, 127);
            this.txtIngresarBoleto.MaxLength = 32767;
            this.txtIngresarBoleto.Name = "txtIngresarBoleto";
            this.txtIngresarBoleto.PasswordChar = '\0';
            this.txtIngresarBoleto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIngresarBoleto.SelectedText = "";
            this.txtIngresarBoleto.SelectionLength = 0;
            this.txtIngresarBoleto.SelectionStart = 0;
            this.txtIngresarBoleto.ShortcutsEnabled = true;
            this.txtIngresarBoleto.Size = new System.Drawing.Size(203, 35);
            this.txtIngresarBoleto.TabIndex = 0;
            this.txtIngresarBoleto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIngresarBoleto.UseSelectable = true;
            this.txtIngresarBoleto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIngresarBoleto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnIngresarBoleto
            // 
            this.btnIngresarBoleto.Location = new System.Drawing.Point(84, 200);
            this.btnIngresarBoleto.Name = "btnIngresarBoleto";
            this.btnIngresarBoleto.Size = new System.Drawing.Size(144, 44);
            this.btnIngresarBoleto.TabIndex = 1;
            this.btnIngresarBoleto.Text = "Ingresar Boleto";
            this.btnIngresarBoleto.UseSelectable = true;
            this.btnIngresarBoleto.Click += new System.EventHandler(this.btnIngresarBoleto_Click);
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(217, 60);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 14;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // frmIngresarBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 310);
            this.ControlBox = false;
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.btnIngresarBoleto);
            this.Controls.Add(this.txtIngresarBoleto);
            this.Name = "frmIngresarBoleto";
            this.Resizable = false;
            this.Text = "PA-08-09 Ingresar Boleto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIngresarBoleto_FormClosed);
            this.Load += new System.EventHandler(this.frmIngresarBoleto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtIngresarBoleto;
        private MetroFramework.Controls.MetroButton btnIngresarBoleto;
        private MetroFramework.Controls.MetroLabel lblRegresar;
    }
}