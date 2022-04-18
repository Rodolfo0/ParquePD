using MetroFramework.Forms;
using System;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmPantallaPrincipal
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmPantallaPrincipal : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmPantallaPrincipal pantallaPrincipal;

        //Constructor de la clase frmPantallaPrincipal
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<returns> Instancia de la clase creada </returns>
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

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPantallaPrincipal_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            pantallaPrincipal = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        //Método invocado cuando se dá click en el tile tlMaquinaAcceso
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void tlControlMaquinasCobro_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipalControl.ObtenerInstancia().Show();
            this.Hide();
        }

        //Método invocado cuando se dá click en el tile tlMaquinaAcceso
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void tlMaquinaCobro_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(0).Show();
            this.Hide();
        }

        //Método invocado cuando se dá click en el tile tlMaquinaSalida
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void tlMaquinaSalida_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(1).Show();
            this.Hide();
        }

        //Método invocado cuando se dá click en el tile tlMaquinaAcceso
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void tlMaquinaAcceso_Click_1(object sender, EventArgs e)
        {
            frmElegirMaquina.ObtenerInstancia(2).Show();
            this.Hide();
        }
    }
}
