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
    //Clase de la forma frmPagarBoleto
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmPagarBoleto : MetroForm
    {
        private static frmPagarBoleto pagarBoleto;
        private static int maquinaElegida = 0;
        private Timer horaActual;

        //Constructor de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmPagarBoleto()
        {
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(frmPagarBoleto_Load);
            InitializeComponent();
            horaActual.Enabled = true;
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pMaquina"> Máquina que será desplegada en pantalla </param>
        //<returns> Instancia de la clase creada </returns>
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

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPagarBoleto_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Salida " + maquinaElegida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        //Método invocado cuando se dá click en la etiqueta lblRegresar
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void lblRegresar_Click(object sender, EventArgs e)
        {
            pagarBoleto = null;
            this.Close();
        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPagarBoleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicioSesion.ObtenerInstancia().Show();
        }

        //TODO:
        private void btnPagarBoleto_Click(object sender, EventArgs e)
        {

        }
    }
}
