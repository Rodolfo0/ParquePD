using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmPantallaPrincipalControl : MetroForm
    {
        private static frmPantallaPrincipalControl control;
        public frmPantallaPrincipalControl()
        {
            InitializeComponent();
        }

        public static frmPantallaPrincipalControl ObtenerInstancia()
        {
            if (control == null)
            {
                control = new frmPantallaPrincipalControl();
                return control;
            }
            else
                return control;
        }

        private void frmPantallaPrincipalControl_Load(object sender, EventArgs e)
        {

        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            control = null;
            Close();
        }

        private void frmPantallaPrincipalControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void btnRegistrarMonto_Click(object sender, EventArgs e)
        {
            frmDineroInicial.ObtenerInstancia().Show();
            Hide();
        }

        private void btnComprobarMonto_Click(object sender, EventArgs e)
        {
            frmComprobarMonto.ObtenerInstancia().Show();
            Hide();
        }
    }
}
