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
    public partial class frmSalidaEstacionamiento : MetroForm
    {
        private static frmSalidaEstacionamiento salidaEstacionamiento;
        private static int maquinaEscogida;
        //Campo que permite mostrar la hora actual en la forma
        private Timer horaActual;

        public static frmSalidaEstacionamiento ObtenerInstancia(int pMaquina)
        {
            maquinaEscogida = pMaquina;

            if (salidaEstacionamiento == null)
            {
                salidaEstacionamiento = new frmSalidaEstacionamiento();
                return salidaEstacionamiento;
            }
            else
                return salidaEstacionamiento;
        }
        private frmSalidaEstacionamiento()
        {
            //Se inicializa el timer 
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(PA_08_12_Salida_del_Estacionamiento_Load);
            InitializeComponent();
            horaActual.Enabled = true;
        }

        private void PA_08_12_Salida_del_Estacionamiento_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Salida " + maquinaEscogida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalidaEstacionamiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicioSesion.ObtenerInstancia().Show();
        }
    }
}
