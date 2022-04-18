using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmDineroInicial
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmDineroInicial : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmDineroInicial dineroInicial;

        //Campo que permite almacenar el número de la máquina a la que se le desea agregar un monto inicial
        private int maquinaSeleccionada;

        //Instancia de la clase CVerificador
        private CVerificador verificador;

        //Constructor de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmDineroInicial()
        {
            //Se inicializan todas las variables
            maquinaSeleccionada = 0;
            verificador = new CVerificador();
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<returns> Instancia de la clase creada </returns>
        public static frmDineroInicial ObtenerInstancia()
        {
            if (dineroInicial == null)
            {
                dineroInicial = new frmDineroInicial();
                return dineroInicial;
            }
            else
                return dineroInicial;
        }

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmDineroInicial_Load(object sender, EventArgs e)
        {
            cmbMaquinas.Items.Add("Seleccione una máquina");
            cmbMaquinas.SelectedIndex = 0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Id FROM PaymentMachines", connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                }

                dataReader.Close();
                connection.Close();
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
            if (cmbMaquinas.SelectedIndex == 1)
                maquinaSeleccionada = 1;

            if (cmbMaquinas.SelectedIndex == 2)
                maquinaSeleccionada = 2;

            if (cmbMaquinas.SelectedIndex == 3)
                maquinaSeleccionada = 3;

            if (cmbMaquinas.SelectedIndex == 4)
                maquinaSeleccionada = 4;
        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmDineroInicial_FormClosed(object sender, FormClosedEventArgs e)
        {
            dineroInicial = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        //Método invocado cuando se dá click en el botón btnRegresar
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Método invocado cuando se dá click en el botón btnIngresarMonto
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnIngresarMonto_Click(object sender, EventArgs e)
        {
            if (cmbMaquinas.SelectedIndex == 0)
                MetroMessageBox.Show(this, "No se puede ingresar dinero a esta máquina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!verificador.CantidadesInvalidas(this))
                {
                    txtMonedas5.Clear();
                    txtMonedas10.Clear();
                    txtBilletes50.Clear();
                    txtBilletes100.Clear();
                }
                else if (Convert.ToInt16(txtMonedas5.Text) != 600
                       || Convert.ToInt16(txtMonedas10.Text) != 300
                       || Convert.ToInt16(txtBilletes50.Text) != 60
                       || Convert.ToInt16(txtBilletes100.Text) != 30)
                    MetroMessageBox.Show(this, "Monto(s) inválido(s). Inténtelo Nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    AgregarMontoInicial(maquinaSeleccionada, Convert.ToInt16(txtMonedas5.Text),
                                Convert.ToInt16(txtMonedas10.Text),
                                Convert.ToInt16(txtBilletes50.Text),
                                Convert.ToInt16(txtBilletes100.Text));
            }
        }

        //Método que inserta el monto inicial en la máquina seleccionada
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pNumeroMaquina"> Caja a la que se le ingresará dinero </param>
        //<param name="pMonedas5"> Monedas de $5 iniciales en la máquina</param>
        //<param name="pMonedas10"> Monedas de $10 iniciales en la máquina</param>
        //<param name="pBilletes50"> Billetes de $50 iniciales en la máquina</param>
        //<param name="pBilletes100"> Monedas de $100 iniciales en la máquina</param>
        private void AgregarMontoInicial(int pNumeroMaquina, int pMonedas5, int pMonedas10, int pBilletes50, int pBilletes100)
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("IF (SELECT statusId FROM PaymentMachines WHERE Id=@numMaquinaCobro)=2\n" +
                    "BEGIN\n" +
                    "UPDATE PaymentMachines " +
                    "SET StartCurrency5=@monedas5,StartCurrency10=@monedas10," +
                    "StartBill50=@billetes50,StartBill100=@billetes100, StatusId=1 " +
                    "WHERE Id=@numMaquinaCobro\n" +
                    "SELECT 1 AS 'Resultado'\n" +
                    "END\n" +
                    "ELSE\n" +
                    "SELECT 0 AS 'Resultado'"
                    , connection);

                //Se crean los parámetros que se necesitan en la consulta
                command.Parameters.Add("@numMaquinaCobro", SqlDbType.Int);
                command.Parameters["@numMaquinaCobro"].Value = pNumeroMaquina;

                command.Parameters.Add("@monedas5", SqlDbType.Int);
                command.Parameters["@monedas5"].Value = pMonedas5;

                command.Parameters.Add("@monedas10", SqlDbType.Int);
                command.Parameters["@monedas10"].Value = pMonedas10;

                command.Parameters.Add("@billetes50", SqlDbType.Int);
                command.Parameters["@billetes50"].Value = pBilletes50;

                command.Parameters.Add("@billetes100", SqlDbType.Int);
                command.Parameters["@billetes100"].Value = pBilletes100;

                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();

                //Se valida el resultado de la consulta ejecutada
                if (Convert.ToInt16(dataReader["Resultado"]) == 1)
                    MetroMessageBox.Show(this, "Monto Inicial Ingresado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "No se puede ingresar dinero a esta máquina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Se cierra la conexión con la base de datos
                connection.Close();
                dataReader.Close();
            }
        }
    }
}
