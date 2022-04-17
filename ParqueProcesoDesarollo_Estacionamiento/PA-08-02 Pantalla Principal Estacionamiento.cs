using MetroFramework.Forms;
using System;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmPantallaPrincipal : MetroForm
    {
        private static frmPantallaPrincipal pantallaPrincipal;
        private frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        public static frmPantallaPrincipal ObtenerInstancia()
        {
            if (pantallaPrincipal == null)
            {
                pantallaPrincipal = new frmPantallaPrincipal();
                return pantallaPrincipal;
            }
            else
                return pantallaPrincipal;
        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void frmPantallaPrincipal_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            pantallaPrincipal = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void tlMaquinaAcceso_Click(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(0).Show();
            this.Hide();
        }

        private void tlControlMaquinasCobro_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipalControl.ObtenerInstancia().Show();
            this.Hide();
        }

        private void tlMaquinaCobro_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(1).Show();
            this.Hide();
        }

        private void tlMaquinaSalida_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(2).Show();
            this.Hide();
        }

        private void tlMaquinaAcceso_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(2).Show();
            this.Hide();
        }
    }
}
