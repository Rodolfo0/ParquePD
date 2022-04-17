using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmPagarBoleto : MetroForm
    {
        private static frmPagarBoleto pagarBoleto;
        private static int maquinaElegida = 0;
        private Timer horaActual;

        private frmPagarBoleto()
        {
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(frmPagarBoleto_Load);
            InitializeComponent();
            horaActual.Enabled = true;
        }

        public static frmPagarBoleto ObtenerInstancia(int pMaquina)
        {
            maquinaElegida = pMaquina;
            if (pagarBoleto == null)
            {
                pagarBoleto = new frmPagarBoleto();
                return pagarBoleto;
            }
            else
                return pagarBoleto;
        }

        private void frmPagarBoleto_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Salida " + maquinaElegida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPagarBoleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            pagarBoleto = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

    }
}
