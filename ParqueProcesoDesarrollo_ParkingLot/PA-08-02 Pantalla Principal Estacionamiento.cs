using MetroFramework.Forms;
using System;

namespace CU_08_Pago_Estacionamiento
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

        private void metroTile1_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipalControl.ObtenerInstancia().Show();
            this.Hide();
        }

        private void tlMaquinaAcceso_Click(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(0).Show();
            this.Hide();
        }

        private void tlMaquinaCobro_Click(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(1).Show();
            this.Hide();
        }

        private void tlMaquinaSalida_Click(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(2).Show();
            this.Hide();
        }
    }
}
