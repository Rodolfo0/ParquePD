using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using MetroFramework;
using MetroFramework.Controls;
using System.Linq;

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
        private static frmPagarBoletoPerdido imprimirBoleto;
        private static int maquinaElegida = 0;
        private Timer horaActual;
        private int total = 100;
        private static int monedasIngresadas5 = 0;
        private static int monedasIngresadas10 = 0;
        private static int billetesIngresados50 = 0;
        private static int billetesIngresados100 = 0;

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
            txtMonedas5.Text = "0";
            txtMonedas10.Text = "0";
            txtBilletes50.Text = "0";
            txtBilletes100.Text = "0";

            DateTime horaEntrada = new DateTime();
            txtFechaActual.Text = DateTime.Now.Date.ToString("d");
            double diferencia = 0.0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO ParkingTickets (StatusId,DateOfEntry,TimeOfEntry,TimeOfPayment,PrintingMachineId) " +
                            "VALUES (11,@fecha,@horaPago,@horaPago,@maquinaImpresion)", connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters.Add("@fecha", SqlDbType.Date);
                command.Parameters["@fecha"].Value = Convert.ToDateTime(txtFechaActual.Text);

                command.Parameters.Add("@horaPago", SqlDbType.Time);
                command.Parameters["@horaPago"].Value = Convert.ToDateTime(txtHoraActual.Text).TimeOfDay;

                command.Parameters.Add("@maquinaImpresion", SqlDbType.Int);
                command.Parameters["@maquinaImpresion"].Value = Convert.ToInt16(maquinaElegida);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    horaEntrada = Convert.ToDateTime(reader["TimeOfEntry"]);
                    txtHoraActual.Text = "Hora de Entrada: " + horaEntrada.ToString("hh:mm:ss tt");
                }

                if (DateTime.Now.Date == Convert.ToDateTime(reader["DateOfEntry"]).Date)
                {
                    if (DateTime.Now.TimeOfDay.Hours == Convert.ToDateTime(reader["TimeOfEntry"]).TimeOfDay.Hours)
                    {
                        diferencia = Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60;
                    }
                    else
                    {
                        diferencia = (Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60)
                            + (Math.Abs(Convert.ToDateTime(reader["TimeOfEntry"]).TimeOfDay.Hours - DateTime.Now.TimeOfDay.Hours));
                    }
                }
                else
                {
                    diferencia = Convert.ToDouble(Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60
                    + Convert.ToDouble(Math.Abs((24 - horaEntrada.TimeOfDay.Hours) + DateTime.Now.TimeOfDay.Hours)));
                }

                if (diferencia >= 0 && diferencia <= .25)
                {
                    lblTotal.Text = "$0";
                    MetroMessageBox.Show(this, "Imprimiendo nuevo boleto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Se tiene que actualizar la base de datos aquí
                    frmPagarBoleto.ObtenerInstancia(maquinaElegida);
                }
                else if (diferencia > .25 && diferencia <= 3)
                {
                    total = 20;
                    lblTotal.Text = "$20";
                }
                else
                {
                    total = 20 + (((int)diferencia - 3) * 10);
                    lblTotal.Text = "$" + total.ToString();
                }

                if (command.ExecuteNonQuery() != 0)
                {
                    //Se recupera la información de ese boleto
                    //y se guarda en un archivo que representa el boleto de estacionamiento
                    command = new SqlCommand("SELECT Id, DateOfEntry, TimeOfEntry, PrintingMachineId" +
                        " FROM ParkingTickets WHERE Id=(SELECT MAX(Id) " +
                        "FROM ParkingTickets)", connection);

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
                }
                reader.Close();
                connection.Close();
            }
        }

        //Método invocado cuando se dá click en el botón btnImprimirBoleto
        //Autor: Luis Emiliano Navarro González
        //Fecha: 28-abril-2022
        //Versión: 1.0
        //Modificación: 04-mayo-2022
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

        //Método invocado cuando se dá click en la etiqueta lblRegresar
        //Autor: Luis Emiliano Navarro González
        //Fecha: 21-abril-2022
        //Versión: 1.0
        //Modificación: 21-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void lblRegresar_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "¿Está seguro de que quiere regresar?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                this.Close();
            }
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
            int cambio = 0;
            int dineroIngresado = Convert.ToInt16(txtMonedas5.Text) * 5 + Convert.ToInt16(txtMonedas10.Text) * 10 + Convert.ToInt16(txtBilletes50.Text) * 50 + Convert.ToInt16(txtBilletes100.Text) * 100;

            foreach (MetroTextBox textBox in this.Controls.OfType<MetroTextBox>())
            {
                if (textBox.Text == "")
                    textBox.Text = "0";
            }

            monedasIngresadas5 += Convert.ToInt32(txtMonedas5.Text);
            monedasIngresadas10 += Convert.ToInt32(txtMonedas10.Text);
            billetesIngresados50 += Convert.ToInt32(txtBilletes50.Text);
            billetesIngresados100 += Convert.ToInt32(txtBilletes100.Text);

            if (dineroIngresado == total)
            {
                if (MetroMessageBox.Show(this, "El pago se ha realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }

            else if (dineroIngresado < total)
            {
                total -= dineroIngresado;
                lblTotal.Text = "$" + total.ToString();
            }

            else
            {
                cambio = dineroIngresado - total;

                if (MetroMessageBox.Show(this, "Su cambio es de $" + cambio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}