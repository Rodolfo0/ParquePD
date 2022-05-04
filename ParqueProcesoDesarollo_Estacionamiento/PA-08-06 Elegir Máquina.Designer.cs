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
            this.cmbMaquinas.Location = new System.Drawing.Point(71, 156);
            this.cmbMaquinas.Name = "cmbMaquinas";
            this.cmbMaquinas.Size = new System.Drawing.Size(178, 29);
            this.cmbMaquinas.TabIndex = 1;
            this.cmbMaquinas.UseSelectable = true;
            this.cmbMaquinas.SelectedIndexChanged += new System.EventHandler(this.cmbMaquinas_SelectedIndexChanged);
            // 
            // lblRegresar
            // 
            this.lblRegresar.AutoSize = true;
            this.lblRegresar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRegresar.Location = new System.Drawing.Point(217, 80);
            this.lblRegresar.Name = "lblRegresar";
            this.lblRegresar.Size = new System.Drawing.Size(75, 25);
            this.lblRegresar.TabIndex = 13;
            this.lblRegresar.Text = "< Volver";
            this.lblRegresar.Click += new System.EventHandler(this.lblRegresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParqueProcesoDesarollo_Estacionamiento.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(5, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // frmElegirMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 295);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRegresar);
            this.Controls.Add(this.cmbMaquinas);
            this.Name = "frmElegirMaquina";
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