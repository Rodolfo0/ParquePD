using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmImportePago : MetroForm
    {
        private static frmImportePago importePago;
        private static string idBoletoAPagar;
        private static int maquinaEscogida = 0;

        private frmImportePago()
        {
            InitializeComponent();
        }

        public static frmImportePago ObtenerInstancia(string pBoleto, int pMaquina)
        {
            idBoletoAPagar = pBoleto;
            maquinaEscogida = pMaquina;

            if (importePago == null)
            {
                importePago = new frmImportePago();
                return importePago;
            }
            else
                return importePago;

        }

        private void frmImportePago_Load(object sender, EventArgs e)
        {
            DateTime horaEntrada = new DateTime();
            txtFolio.Text = "Folio del boleto: " + idBoletoAPagar;
            txtFechaActual.Text = DateTime.Now.Date.ToString("d");
            txtHoraSalida.Text = "Hora de salida: "+DateTime.Now.ToString("hh:mm:ss tt");
            double diferencia = 0.0;
            int total = 0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT DateOfEntry, TimeOfEntry FROM ParkingTickets WHERE Id=@id", connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = ObtenerId(idBoletoAPagar);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    horaEntrada = Convert.ToDateTime(reader["TimeOfEntry"]);
                    txtHoraEntrada.Text = "Hora de Entrada: "+horaEntrada.ToString("hh:mm:ss tt");
                }

                diferencia = DateTime.Now.Date == Convert.ToDateTime(reader["DateOfEntry"]) ?
                    Convert.ToDouble(Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60 
                    + Convert.ToDouble(horaEntrada.TimeOfDay.Hours - DateTime.Now.TimeOfDay.Hours)) : 
                    Convert.ToDouble(Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60 
                    + Convert.ToDouble((24 - horaEntrada.TimeOfDay.Hours) + DateTime.Now.TimeOfDay.Hours));

                if (diferencia > 0 && diferencia <= .25)
                {
                    lblTotal.Text = "$0";
                    MetroMessageBox.Show(this, "Vuelva Pronto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Se tiene que actualizar la base de datos aquí
                    frmPagarBoleto.ObtenerInstancia(maquinaEscogida);
                }
                else if (diferencia > .25 && diferencia <= 3)
                    lblTotal.Text = "$20";
                else
                {
                    total = 20 + (((int)diferencia - 3) * 10);
                    lblTotal.Text = "$"+total.ToString();
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

        private void frmImportePago_FormClosed(object sender, FormClosedEventArgs e)
        {
            importePago = null;
            frmPagarBoleto.ObtenerInstancia(maquinaEscogida).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MetroMessageBox.Show(this,"¿Está seguro de que quiere cancelar el pago del boleto","Advertencia",MessageBoxButtons.OKCancel,MessageBoxIcon.Error)==DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
