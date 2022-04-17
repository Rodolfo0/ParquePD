namespace CU_08_Pago_Estacionamiento
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
            this.SuspendLayout();
            // 
            // cmbMaquinas
            // 
            this.cmbMaquinas.FormattingEnabled = true;
            this.cmbMaquinas.ItemHeight = 23;
            this.cmbMaquinas.Location = new System.Drawing.Point(63, 120);
            this.cmbMaquinas.Name = "cmbMaquinas";
            this.cmbMaquinas.Size = new System.Drawing.Size(178, 29);
            this.cmbMaquinas.TabIndex = 0;
            this.cmbMaquinas.UseSelectable = true;
            this.cmbMaquinas.SelectedIndexChanged += new System.EventHandler(this.cmbMaquinas_SelectedIndexChanged);
            // 
            // frmElegirMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 271);
            this.ControlBox = false;
            this.Controls.Add(this.cmbMaquinas);
            this.Name = "frmElegirMaquina";
            this.Text = "PA-08-06 Elegir Máquina";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmElegirMaquina_FormClosed);
            this.Load += new System.EventHandler(this.frmElegirMaquina_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbMaquinas;
    }
}