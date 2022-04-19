using MetroFramework.Forms;
using System;
using System.Data.SqlClient;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmElegirMaquina
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmElegirMaquina : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmElegirMaquina elegirMaquina;

        //Campo que nos indica si la máquina que se elegirá será de cobro, de impresión o de salida
        private static int tipoMaquina;

        //Constructor de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmElegirMaquina()
        {
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pTipoMaquina"> Tipo de máquina que se decidió mostrar </params>
        //<returns> Instancia de la clase creada </returns>
        public static frmElegirMaquina ObtenerInstancia(int pTipoMaquina)
        {
            tipoMaquina = pTipoMaquina;
            if (elegirMaquina == null)
            {
                elegirMaquina = new frmElegirMaquina();
                return elegirMaquina;
            }
            else
                return elegirMaquina;
        }

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmElegirMaquina_Load(object sender, EventArgs e)
        {
            cmbMaquinas.Items.Add("Seleccione una máquina");
            cmbMaquinas.SelectedIndex = 0;

            //Se muestran las máquinas disponibles dependiendo del tipo elegido
            if (tipoMaquina == 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Id FROM PaymentMachines WHERE StatusId=1", connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                    }

                    dataReader.Close();
                    connection.Close();
                }
            }
            else if (tipoMaquina == 1)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Id FROM ReceivingMachines", connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                    }

                    dataReader.Close();
                    connection.Close();
                }
            }
            else if (tipoMaquina == 2)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Id FROM PrintingMachines", connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                    }

                    dataReader.Close();
                    connection.Close();
                }
            }
        }

        //Método invocado cuando el índice seleccionado en el combobox cambia
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void cmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se invoca a la forma correspondiente al tipo de máquina elegida para mostrar
            if (tipoMaquina == 0)
            {
                if (cmbMaquinas.SelectedIndex == 1)
                {
                    frmPagarBoleto.ObtenerInstancia(1).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 2)
                {
                    frmPagarBoleto.ObtenerInstancia(2).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 3)
                {
                    frmPagarBoleto.ObtenerInstancia(3).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 4)
                {
                    frmPagarBoleto.ObtenerInstancia(4).Show();
                    this.Close();
                }
            }
            else if (tipoMaquina == 1)
            {
                if (cmbMaquinas.SelectedIndex == 1)
                {
                    frmPagarBoleto.ObtenerInstancia(1).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 2)
                {
                    frmPagarBoleto.ObtenerInstancia(2).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 3)
                {
                    frmPagarBoleto.ObtenerInstancia(3).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 4)
                {
                    frmPagarBoleto.ObtenerInstancia(4).Show();
                    this.Close();
                }
            }
            else
            {
                if (cmbMaquinas.SelectedIndex == 1)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(1).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 2)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(2).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 3)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(3).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 4)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(4).Show();
                    this.Close();
                }
            }
        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmElegirMaquina_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            elegirMaquina = null;
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            frmInicioSesion.ObtenerInstancia().Show();
            this.Close();
        }
    }
}
