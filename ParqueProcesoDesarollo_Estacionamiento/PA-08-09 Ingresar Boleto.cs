using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmIngresarBoleto : MetroForm
    {
        private static frmIngresarBoleto ingresarBoleto;
        private static int maquinaEscogida = 0;

        private frmIngresarBoleto()
        {
            InitializeComponent();
        }

        public static frmIngresarBoleto ObtenerInstancia(int pMaquina)
        {
            maquinaEscogida = pMaquina;

            if (ingresarBoleto == null)
            {
                ingresarBoleto = new frmIngresarBoleto();
                return ingresarBoleto;
            }
            else
                return ingresarBoleto;

        }

        private void frmIngresarBoleto_Load(object sender, EventArgs e)
        {
            txtIngresarBoleto.Text = "";
        }

        private void btnIngresarBoleto_Click(object sender, EventArgs e)
        {
            string folio = "";

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Archivos txt (*.txt)|*.txt";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fileDialog.FileName.Contains("Boleto_"))
                    {
                        folio = LeerBoleto(fileDialog.FileName);

                        if (folio != "")
                        {
                            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                            {
                                connection.Open();

                                //Se crea el registro del boleto en la base de datos
                                SqlCommand command = new SqlCommand("IF(SELECT COUNT(Id) FROM ParkingTickets WHERE Id=@id)=0" +
                                    "BEGIN " +
                                    "SELECT 2 AS 'RESULTADO' " +
                                    "END " +
                                    "ELSE" +
                                    " BEGIN " +
                                    "IF (SELECT StatusId FROM ParkingTickets WHERE Id=@id)=1 " +
                                    "BEGIN " +
                                    "SELECT 0 AS 'RESULTADO' " +
                                    "END " +
                                    "ELSE " +
                                    "BEGIN SELECT 1 AS 'RESULTADO' " +
                                    "END " +
                                    "END", connection);

                                command.Parameters.Add("@id", SqlDbType.Int);
                                command.Parameters["@id"].Value = Convert.ToInt16(folio);

                                SqlDataReader reader = command.ExecuteReader();

                                reader.Read();
                                if (Convert.ToInt16(reader["RESULTADO"]) == 2)
                                {
                                    MetroMessageBox.Show(this, "Boleto no existente o no válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (Convert.ToInt16(reader["RESULTADO"]) == 0)
                                        MetroMessageBox.Show(this, "El boleto ingresado ya ha sido pagado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        txtIngresarBoleto.Text = folio;
                                        frmImportePago.ObtenerInstancia(folio, maquinaEscogida).Show();
                                        txtIngresarBoleto.Text = "";
                                        this.Hide();
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        private string LeerBoleto(string fileName)
        {
            int i;
            string linea;

            for (i = 1; i <= File.ReadAllLines(fileName).Count(); i++)
            {
                if (i == File.ReadAllLines(fileName).Count())
                {
                    linea = File.ReadAllLines(fileName)[i - 1];
                    return linea;
                }
            }
            return "";
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmIngresarBoleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPagarBoleto.ObtenerInstancia(maquinaEscogida).Show();
            ingresarBoleto = null;
        }
    }
}
