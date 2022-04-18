using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmPantallaPrincipalControl
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmPantallaPrincipalControl : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmPantallaPrincipalControl control;

        //Constructor de la clase frmPantallaPrincipalControl
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        public frmPantallaPrincipalControl()
        {
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<returns> Instancia de la clase creada </returns>
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

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPantallaPrincipalControl_Load(object sender, EventArgs e)
        {

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
            control = null;
            Close();
        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmPantallaPrincipalControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicioSesion.ObtenerInstancia().Show();
        }

        //Método invocado cuando se dá click en el botón btnRegistrarMonto
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnRegistrarMonto_Click(object sender, EventArgs e)
        {
            frmDineroInicial.ObtenerInstancia().Show();
            Hide();
        }

        //Método invocado cuando se dá click en el botón btnComprobar
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnComprobarMonto_Click(object sender, EventArgs e)
        {
            frmComprobarMonto.ObtenerInstancia().Show();
            Hide();
        }
    }
}
