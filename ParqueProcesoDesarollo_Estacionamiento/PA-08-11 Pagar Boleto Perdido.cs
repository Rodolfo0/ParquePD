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
        private int total = 0;
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
            txtHoraActual.Text = "Hora de salida: " + DateTime.Now.ToString("hh:mm:ss tt");
            double diferencia = 0.0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT DateOfEntry, TimeOfEntry FROM ParkingTickets WHERE Id=@id", connection);

                command.Parameters.Add("@id", SqlDbType.Int);

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
                    MetroMessageBox.Show(this, "Vuelva Pronto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                reader.Close();
                connection.Close();
            }
        }

        private int ObtenerId(string pLinea)
        {
            if (pLinea.Contains("00000000"))
                return Convert.ToInt16(pLinea.Substring(7));
            else if (pLinea.Contains("0000000"))
                return Convert.ToInt16(pLinea.Substring(6));
            else if (pLinea.Contains("000000"))
                return Convert.ToInt16(pLinea.Substring(5));
            else if (pLinea.Contains("00000"))
                return Convert.ToInt16(pLinea.Substring(4));
            else if (pLinea.Contains("0000"))
                return Convert.ToInt16(pLinea.Substring(3));
            else if (pLinea.Contains("000"))
                return Convert.ToInt16(pLinea.Substring(2));
            else if (pLinea.Contains("00"))
                return Convert.ToInt16(pLinea.Substring(1));
            else if (pLinea.Contains("0"))
                return Convert.ToInt16(pLinea.Substring(0));
            else
                return 0;
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
            if (MetroMessageBox.Show(this, "¿Está seguro de que quiere cancelar el pago del boleto", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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


            frmPagarBoletoPerdido.ObtenerInstancia(maquinaElegida).Show();
            this.Hide();
        }
    }
}
