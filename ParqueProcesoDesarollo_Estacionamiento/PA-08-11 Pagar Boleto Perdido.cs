using System;
using MetroFramework;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmPagarBoletoPerdido
    //Autor: Luis Emiliano Navarro González
    //Fecha: 21-abril-2022
    //Versión: 1.0
    //Modificación: 21-abril-2022
    public partial class frmPagarBoletoPerdido : MetroForm
    {
        private static frmPagarBoletoPerdido pagarBoletoPerdido;
        private static int maquinaElegida = 0;
        private Timer horaActual;

        private frmPagarBoletoPerdido()
        {
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(frmPagarBoletoPerdido_Load);
            InitializeComponent();
            horaActual.Enabled = true;
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Luis Emiliano Navarro González
        //Fecha: 21-abril-2022
        //Versión: 1.0
        //Modificación: 21-abril-2022
        //<param name="pMaquina"> Máquina que será desplegada en pantalla </param>
        //<returns> Instancia de la clase creada </returns>
        public static frmPagarBoletoPerdido ObtenerInstancia(int pMaquina)
        {
            maquinaElegida = pMaquina;
            if (pagarBoletoPerdido == null)
            {
                pagarBoletoPerdido = new frmPagarBoletoPerdido();
                return pagarBoletoPerdido;
            }
            else
                return pagarBoletoPerdido;
        }

        //Método invocado cuando se carga la forma
        //Autor: Luis Emiliano Navarro González
        //Fecha: 21-abril-2022
        //Versión: 1.0
        //Modificación: 21-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPagarBoletoPerdido_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Salida " + maquinaElegida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        //Método invocado cuando se dá click en la etiqueta lblRegresar
        //Autor: Luis Emiliano Navarro González
        //Fecha: 21-abril-2022
        //Versión: 1.0
        //Modificación: 21-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void lblRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Método invocado cuando se cierra la forma
        //Autor: Luis Emiliano Navarro González
        //Fecha: 21-abril-2022
        //Versión: 1.0
        //Modificación: 21-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPagarBoletoPerdido_FormClosed(object sender, FormClosedEventArgs e)
        {
            pagarBoletoPerdido = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void btnPagarBoletoPerdido_Click(object sender, EventArgs e)
        {


            frmPagarBoletoPerdido.ObtenerInstancia(maquinaElegida).Show();
            this.Hide();
        }
    }
}
