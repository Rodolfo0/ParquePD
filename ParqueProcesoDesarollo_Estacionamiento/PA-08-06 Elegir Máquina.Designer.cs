namespace ParqueProcesoDesarollo_Estacionamiento
{
    partial class frmElegirMaquina
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
            this.cmbMaquinas = new MetroFramework.Controls.MetroComboBox();
            this.lblRegresar = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMaquinas
            // 
            this.cmbMaquinas.FormattingEnabled = true;
            this.cmbMaquinas.ItemHeight = 23;
            this.cmbMaquinas.Location = new System.Drawing.Point(193, 356);
            this.cmbMaquinas.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.cmbMaquinas.Name = "cmbMaquinas";
            this.cmbMaquinas.Size = new System.Drawing.Size(555, 29);
            this.cmbMaquinas.TabIndex = 1;
            this.cmbMaquinas.UseSelectable = true;
            this.cmbMaquinas.SelectedIndexChanged += new System.EventHandler(this.cmbMaquinas_SelectedIndexChanged);
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(662, 196);
            this.lblRegresar.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 13;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(7, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(957, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // frmElegirMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 771);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.cmbMaquinas);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "frmElegirMaquina";
            this.Padding = new System.Windows.Forms.Padding(63, 171, 63, 57);
            this.Resizable = false;
            this.Text = "PA-08-06 Elegir Máquina";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmElegirMaquina_FormClosed);
            this.Load += new System.EventHandler(this.frmElegirMaquina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbMaquinas;
        private MetroFramework.Controls.MetroLabel lblRegresar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}