using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using MetroFramework;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmImprimirBoletoEstacionamiento
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmImprimirBoletoEstacionamiento : MetroForm
    {
        //Referencia a la clase que nos permitirá crear una única instancia de ella
        private static frmImprimirBoletoEstacionamiento imprimirBoleto;

        //Campo que permite almacenar el número de la máquina que se eligió visualizar en pantalla
        private static int maquinaElegida = 0;

        //Campo que permite mostrar la hora actual en la forma
        private Timer horaActual;

        //Campo que representa el número de autos dentro del estacionamiento
        private static int numAutos;

        //Constructor de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmImprimirBoletoEstacionamiento()
        {
            //Se inicializa el timer 
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(frmImprimirBoletoEstacionamiento_Load);
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
        public static frmImprimirBoletoEstacionamiento ObtenerInstancia(int pMaquina)
        {
            maquinaElegida = pMaquina;
            if (imprimirBoleto == null)
            {
                imprimirBoleto = new frmImprimirBoletoEstacionamiento();
                return imprimirBoleto;
            }
            else
                return imprimirBoleto;
        }

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmImprimirBoletoEstacionamiento_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Entrada " + maquinaElegida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        //Método invocado cuando se dá click en el botón btnImprimirBoleto
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnImprimirBoleto_Click(object sender, EventArgs e)
        {
            //Se valida si es una hora válida para emitir boletos
            if (DateTime.Now.Hour < 9 || DateTime.Now.Hour >= 19)
                MetroMessageBox.Show(this, "El horario de estacionamiento es de 9:00 hrs a 19:00 hrs. Aún no se puede expedir boletos de estacionamiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //Se valida que el estacionamiento no esté lleno
                if (numAutos == 300)
                    MetroMessageBox.Show(this, "No hay más espacios. Estacionamiento lleno", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Se incremente el número de autos
                    numAutos++;

                    using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                    {
                        connection.Open();

                        //Se crea el registro del boleto en la base de datos
                        SqlCommand command = new SqlCommand("INSERT INTO ParkingTickets (StatusId,DateOfEntry,TimeOfEntry,TimeOfPayment,PrintingMachineId) " +
                            "VALUES (11,@fecha,@horaPago,@horaPago,@maquinaImpresion)", connection);

                        command.Parameters.Add("@fecha", SqlDbType.Date);
                        command.Parameters["@fecha"].Value = Convert.ToDateTime(txtFechaActual.Text);

                        command.Parameters.Add("@horaPago", SqlDbType.Time);
                        command.Parameters["@horaPago"].Value = Convert.ToDateTime(txtHoraActual.Text).TimeOfDay;

                        command.Parameters.Add("@maquinaImpresion", SqlDbType.Int);
                        command.Parameters["@maquinaImpresion"].Value = Convert.ToInt16(maquinaElegida);


                        if (command.ExecuteNonQuery() != 0)
                        {
                            //Se recupera la información de ese boleto
                            //y se guarda en un archivo que representa el boleto de estacionamiento
                            command = new SqlCommand("SELECT Id, DateOfEntry, TimeOfEntry, PrintingMachineId" +
                                " FROM ParkingTickets WHERE Id=(SELECT MAX(Id) " +
                                "FROM ParkingTickets)", connection);

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                using (TextWriter boletoNuevo = new StreamWriter("Boleto_" + reader["Id"].ToString() + ".txt"))
                                {
                                    string maquinaImpresora = "Entrada " + Convert.ToString(reader["PrintingMachineId"]);
                                    DateTime fecha = Convert.ToDateTime(reader["DateOfEntry"]);
                                    DateTime hora = Convert.ToDateTime(reader["TimeOfEntry"]);

                                    boletoNuevo.WriteLine(maquinaImpresora);
                                    boletoNuevo.WriteLine(fecha.ToString("d"));
                                    boletoNuevo.WriteLine(hora.ToString("hh:mm:ss tt"));

                                    for (int i = 0; i < 6; i++)
                                    {
                                        boletoNuevo.WriteLine("||||||||||||||||");
                                    }

                                    string folio = MostrarFolio(reader);

                                    boletoNuevo.WriteLine(folio);

                                    MetroMessageBox.Show(this, "Imprimiendo Boleto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    boletoNuevo.Close();
                                }
                            }
                            reader.Close();
                        }
                        connection.Close();
                    }
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
        private void frmImprimirBoletoEstacionamiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            imprimirBoleto = null;
            frmInicioSesion.ObtenerInstancia().Show();
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
            this.Close();
        }

        //Método invocado cuando se dá click en el botón btnImprimirBoleto
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pReader"> Clase que permite leer las filas de una tabla </param>
        //<returns>Formato del folio que se guardará en el archivo del boleto</returns>
        private string MostrarFolio(SqlDataReader pReader)
        {
            //Se valida la longitud del folio del boleto para imprimirlo de una forma determinada
            if (Convert.ToInt16(pReader["Id"]) < 10)
                return "00000000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt16(pReader["Id"]) < 100)
                return "0000000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt16(pReader["Id"]) < 1000)
                return "000000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt16(pReader["Id"]) < 10000)
                return "00000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt32(pReader["Id"]) < 100000)
                return "0000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt32(pReader["Id"]) < 1000000)
                return "000" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt32(pReader["Id"]) < 10000000)
                return "00" + Convert.ToString(pReader["Id"]);
            else if (Convert.ToInt32(pReader["Id"]) < 100000000)
                return "0" + Convert.ToString(pReader["Id"]);
            else
                return Convert.ToString(pReader["Id"]);
        }
    }
}
