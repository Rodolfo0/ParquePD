using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using MetroFramework;

namespace CU_08_Pago_Estacionamiento
{
    public partial class frmImprimirBoletoEstacionamiento : MetroForm
    {
        private static frmImprimirBoletoEstacionamiento imprimirBoleto;
        private static int maquinaElegida = 0;
        private Timer horaActual;
        private static int numAutos;

        private frmImprimirBoletoEstacionamiento()
        {
            horaActual = new Timer();
            horaActual.Tick += new EventHandler(frmImprimirBoletoEstacionamiento_Load);
            InitializeComponent();
            horaActual.Enabled = true;
        }

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

        private void frmImprimirBoletoEstacionamiento_Load(object sender, EventArgs e)
        {
            txtNumeroMaquina.Text = "Entrada " + maquinaElegida.ToString();
            txtFechaActual.Text = DateTime.Now.ToString("d");
            txtHoraActual.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        private void btnImprimirBoleto_Click(object sender, EventArgs e)
        {
            if(DateTime.Now.Hour<9 || DateTime.Now.Hour==19)
                MetroMessageBox.Show(this, "El horario de estacionamiento es de 9:00 hrs a 19:00 hrs. Aún no se puede expedir boletos de estacionamiento","Información",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                if (numAutos == 300)
                    MetroMessageBox.Show(this, "No hay más espacios. Estacionamiento lleno", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    numAutos++;

                    using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("INSERT INTO BoletosEstacionamiento (idEstado,fechaEntrada,horaEntrada,horaPago,idMaquinaImpresora) " +
                            "VALUES (5,@fecha,@horaPago,@horaPago,@maquinaImpresion)", connection);

                        command.Parameters.Add("@fecha", SqlDbType.Date);
                        command.Parameters["@fecha"].Value = Convert.ToDateTime(txtFechaActual.Text);

                        command.Parameters.Add("@horaPago", SqlDbType.Time);
                        command.Parameters["@horaPago"].Value = Convert.ToDateTime(txtHoraActual.Text).TimeOfDay;

                        command.Parameters.Add("@maquinaImpresion", SqlDbType.Int);
                        command.Parameters["@maquinaImpresion"].Value = Convert.ToInt16(maquinaElegida);


                        if (command.ExecuteNonQuery() != 0)
                        {
                            command = new SqlCommand("SELECT idBoletoEstacionamiento, fechaEntrada, horaEntrada, idMaquinaImpresora" +
                                " FROM BoletosEstacionamiento WHERE idBoletoEstacionamiento=(SELECT MAX(idBoletoEstacionamiento) " +
                                "FROM BoletosEstacionamiento)", connection);

                            SqlDataReader reader = command.ExecuteReader();

                            if(reader.Read())
                            {
                                using (TextWriter boletoNuevo = new StreamWriter("Boleto_"+ reader["idBoletoEstacionamiento"].ToString() + ".txt"))
                                {
                                    string maquinaImpresora = "Entrada " + Convert.ToString(reader["idMaquinaImpresora"]);
                                    DateTime fecha = Convert.ToDateTime(reader["fechaEntrada"]);
                                    string hora = reader["horaEntrada"].ToString();

                                    boletoNuevo.WriteLine(maquinaImpresora);
                                    boletoNuevo.WriteLine(fecha.ToString("d"));
                                    boletoNuevo.WriteLine(hora);

                                    for (int i=0;i<6;i++)
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

        private void frmImprimirBoletoEstacionamiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            imprimirBoleto = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string MostrarFolio(SqlDataReader pReader)
        {
            if (Convert.ToInt16(pReader["idBoletoEstacionamiento"]) < 10)
                return "00000000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt16(pReader["idBoletoEstacionamiento"]) < 100)
                return "0000000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt16(pReader["idBoletoEstacionamiento"]) < 1000)
                return "000000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt16(pReader["idBoletoEstacionamiento"]) < 10000)
                return "00000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt32(pReader["idBoletoEstacionamiento"]) < 100000)
                return  "0000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt32(pReader["idBoletoEstacionamiento"]) < 1000000)
                return  "000" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt32(pReader["idBoletoEstacionamiento"]) < 10000000)
                return  "00" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else if (Convert.ToInt32(pReader["idBoletoEstacionamiento"]) < 100000000)
                return "0" + Convert.ToString(pReader["idBoletoEstacionamiento"]);
            else
                return Convert.ToString(pReader["idBoletoEstacionamiento"]);
        }
    }
}
