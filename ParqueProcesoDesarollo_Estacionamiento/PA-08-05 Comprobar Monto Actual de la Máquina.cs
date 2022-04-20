using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmComprobarMonto
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmComprobarMonto : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmComprobarMonto comprobarMonto;

        //Lista donde se guardan las id's de las máquinas que están habilitadas
        private List<int> numeroMaquinas = new List<int>();

        //Campo que nos indica si alguna máquina ha sido deshabilitada
        private int bandera = 0;

        //Constructor de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmComprobarMonto()
        {
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<returns> Instancia de la clase creada </returns>
        public static frmComprobarMonto ObtenerInstancia()
        {
            if (comprobarMonto == null)
            {
                comprobarMonto = new frmComprobarMonto();
                return comprobarMonto;
            }
            else
                return comprobarMonto;
        }

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmComprobarMonto_Load(object sender, EventArgs e)
        {
            //Se deshabilitan los textboxes de la forma para evitar que el usuario pueda modificar los valores que aparezcan
            txtMonedas5.Enabled = false;
            txtMonedas10.Enabled = false;
            txtBilletes50.Enabled = false;
            txtBilletes100.Enabled = false;

            //Se valida que una máquina no haya sido deshabilitada
            //En caso de que sí haya existido cambio, el combobox se actualiza únicamente con las
            //máquinas habilitadas
            if (bandera == 0)
            {
                cmbMaquinas.Items.Add("Seleccione una máquina");
                cmbMaquinas.SelectedIndex = 0;

                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Id FROM PaymentMachines WHERE StatusId=1", connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                        numeroMaquinas.Add(Convert.ToInt16(dataReader["Id"]));
                    }

                    connection.Close();
                    dataReader.Close();
                }
            }
            else
            {
                cmbMaquinas.Items.Clear();
                cmbMaquinas.Items.Add("Seleccione una máquina");
                cmbMaquinas.SelectedIndex = 0;

                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Id FROM PaymentMachines WHERE StatusId=1", connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["Id"]));
                        numeroMaquinas.Add(Convert.ToInt16(dataReader["Id"]));
                    }

                    connection.Close();
                    dataReader.Close();
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
            if (cmbMaquinas.SelectedIndex != 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM PaymentMachines WHERE Id=@idMaquinaCobro", connection);

                    command.Parameters.Add("@idMaquinaCobro", SqlDbType.Int);
                    command.Parameters["@idMaquinaCobro"].Value = numeroMaquinas[cmbMaquinas.SelectedIndex - 1];

                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    //La información de la máquina se muestra en las cajas de texto de la forma
                    txtMonedas5.Text = Convert.ToString(Convert.ToInt16(dataReader["StartCurrency5"]) + (dataReader["CurrencyEntered5"] != DBNull.Value ? Convert.ToInt16(dataReader["CurrencyEntered5"]) : 0));
                    txtMonedas10.Text = Convert.ToString(Convert.ToInt16(dataReader["StartCurrency10"]) + (dataReader["CurrencyEntered10"] != DBNull.Value ? Convert.ToInt16(dataReader["CurrencyEntered10"]) : 0));
                    txtBilletes50.Text = Convert.ToString(Convert.ToInt16(dataReader["StartBill50"]) + (dataReader["BillEntered50"] != DBNull.Value ? Convert.ToInt16(dataReader["BillEntered50"]) : 0));
                    txtBilletes100.Text = Convert.ToString(Convert.ToInt16(dataReader["StartBill100"]) + (dataReader["BillEntered100"] != DBNull.Value ? Convert.ToInt16(dataReader["BillEntered100"]) : 0));

                    dataReader.Close();
                    connection.Close();
                }
            }
            else
            {
                txtMonedas5.Clear();
                txtMonedas10.Clear();
                txtBilletes50.Clear();
                txtBilletes100.Clear();
            }
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

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmComprobarMonto_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            comprobarMonto = null;
            frmInicioSesion.ObtenerInstancia().Show();
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
            if (cmbMaquinas.SelectedIndex != 0)
            {
                if (MetroMessageBox.Show(this, "¿Está seguro que quiere deshabilitar esta máquina?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("UPDATE PaymentMachines " +
                    "SET StartCurrency5=0,StartCurrency10=0," +
                    "StartBill50=0,StartBill100=0," +
                    "CurrencyEntered5=0, CurrencyEntered10=0, BillEntered50=0, BillEntered100=0, StatusId=2 " +
                    "WHERE Id=@numMaquinaCobro"
                        , connection);

                        command.Parameters.Add("@numMaquinaCobro", SqlDbType.Int);
                        command.Parameters["@numMaquinaCobro"].Value = numeroMaquinas[cmbMaquinas.SelectedIndex - 1];

                        if (command.ExecuteNonQuery() != 0)
                            MetroMessageBox.Show(this, "Máquina Deshabilitada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MetroMessageBox.Show(this, "Máquina Deshabilitada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connection.Close();
                    }

                    //Si la máquina seleccionada se deshabilita, la forma se vuelve a cargar
                    //para actualizar las opciones en el combobox
                    bandera = 1;
                    frmComprobarMonto_Load(sender, e);
                }
            }
        }

        //Método invocado cuando se dá click en el botón btnImprimirReporte
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            if (cmbMaquinas.SelectedIndex != 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    //Se obtiene toda la información de la máquina seleccionada
                    SqlCommand command = new SqlCommand("SELECT * FROM PaymentMachines WHERE Id=@maquinaSeleccionada", connection);

                    command.Parameters.Add("@maquinaSeleccionada", SqlDbType.Int);
                    command.Parameters["@maquinaSeleccionada"].Value = numeroMaquinas[cmbMaquinas.SelectedIndex - 1];

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //Se crea un archivo de texto con la información de la máquina
                        //La cantidad de monedas que se ingresó y el monto hasta el momento
                        //Así como las ganancias de esta máquina
                        using (TextWriter reporteNuevo = new StreamWriter("Reporte_Máquina_" + reader["Id"].ToString() + ".txt"))
                        {
                            int monedas5Inicial = Convert.ToInt16(reader["StartCurrency5"]);
                            int monedas10Inicial = Convert.ToInt16(reader["StartCurrency10"]);
                            int billetes50Inicial = Convert.ToInt16(reader["StartBill50"]);
                            int billetes100Inicial = Convert.ToInt16(reader["StartBill100"]);

                            int monedas5Ingresado = Convert.ToInt16(reader["CurrencyEntered5"]);
                            int monedas10Ingresado = Convert.ToInt16(reader["CurrencyEntered10"]);
                            int billetes50Ingresado = Convert.ToInt16(reader["BillEntered50"]);
                            int billetes100Ingresado = Convert.ToInt16(reader["BillEntered100"]);

                            int montoInicial = monedas5Inicial*5 + monedas10Inicial*10 + billetes50Inicial*50 + billetes100Inicial*100;
                            int montoActual = montoInicial + monedas5Ingresado*5 + monedas10Ingresado*10 + billetes50Ingresado*50 + billetes100Ingresado*100;


                            reporteNuevo.WriteLine("Fecha de Impresión: " + DateTime.Now.ToString("d"));
                            reporteNuevo.WriteLine("Hora de Impresión: " + DateTime.Now.TimeOfDay.ToString());

                            reporteNuevo.WriteLine("MÁQUINA " + numeroMaquinas[cmbMaquinas.SelectedIndex - 1].ToString());
                            reporteNuevo.WriteLine(".....................");
                            reporteNuevo.WriteLine("MONTO INICIAL ");

                            reporteNuevo.WriteLine("Monedas $5: " + monedas5Inicial.ToString());
                            reporteNuevo.WriteLine("Monedas $10: " + monedas10Inicial.ToString());
                            reporteNuevo.WriteLine("Billetes $50: " + billetes50Inicial.ToString());
                            reporteNuevo.WriteLine("Billetes $100: " + billetes100Inicial.ToString());

                            reporteNuevo.WriteLine(".....................");
                            reporteNuevo.WriteLine("MONTO INGRESADO ");

                            reporteNuevo.WriteLine("Monedas $5: " + monedas5Ingresado.ToString());
                            reporteNuevo.WriteLine("Monedas $10: " + monedas10Ingresado.ToString());
                            reporteNuevo.WriteLine("Billetes $50: " + billetes50Ingresado.ToString());
                            reporteNuevo.WriteLine("Billetes $100: " + billetes100Ingresado.ToString());

                            reporteNuevo.WriteLine(".....................");

                            reporteNuevo.WriteLine("Monto Inicial: $" + montoInicial);
                            reporteNuevo.WriteLine("Monto Actual: $" + montoActual);
                            reporteNuevo.WriteLine("Ganancias: $" + (montoActual - montoInicial).ToString());


                            MetroMessageBox.Show(this, "Imprimiendo Reporte de Situación de Máquina de Cobro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reporteNuevo.Close();
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

    }
}
