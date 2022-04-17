using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CU_08_Pago_Estacionamiento
{
    public partial class frmDineroInicial : MetroForm
    {
        private static frmDineroInicial dineroInicial;
        private int maquinaSeleccionada;
        private CVerificador verificador; 
            
        private frmDineroInicial()
        {
            maquinaSeleccionada = 0;
            verificador = new CVerificador();
            InitializeComponent();
        }

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

        private void frmDineroInicial_Load(object sender, EventArgs e)
        {
            cmbMaquinas.Items.Add("Seleccione una máquina");
            cmbMaquinas.SelectedIndex = 0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT idMaquinaCobro FROM MaquinasCobro", connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["idMaquinaCobro"]));
                }

                dataReader.Close();
                connection.Close();
            }
        }

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

        private void frmDineroInicial_FormClosed(object sender, FormClosedEventArgs e)
        {
            dineroInicial = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

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
                else
                    AgregarMontoInicial(maquinaSeleccionada, Convert.ToInt16(txtMonedas5.Text),
                            Convert.ToInt16(txtMonedas10.Text),
                            Convert.ToInt16(txtBilletes50.Text),
                            Convert.ToInt16(txtBilletes100.Text));
            }
        }

        private void AgregarMontoInicial(int pNumeroCaja, int pMonedas5, int pMonedas10, int pBilletes50, int pBilletes100)
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("IF (SELECT idEstado FROM MaquinasCobro WHERE idMaquinaCobro=@numMaquinaCobro)=2\n" +
                    "BEGIN\n" +
                    "UPDATE MaquinasCobro " +
                    "SET inicioMonedas5=@monedas5,inicioMonedas10=@monedas10," +
                    "inicioBilletes50=@billetes50,inicioBilletes100=@billetes100, idEstado=1 " +
                    "WHERE idMaquinaCobro=@numMaquinaCobro\n" +
                    "SELECT 1 AS 'Resultado'\n" +
                    "END\n" +
                    "ELSE\n" +
                    "SELECT 0 AS 'Resultado'"
                    , connection);


                command.Parameters.Add("@numMaquinaCobro", SqlDbType.Int);
                command.Parameters["@numMaquinaCobro"].Value = pNumeroCaja;

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

                if (Convert.ToInt16(dataReader["Resultado"])==1)
                    MetroMessageBox.Show(this, "Monto Inicial Ingresado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "No se puede ingresar dinero a esta máquina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                connection.Close();
                dataReader.Close();
            }
        }
    }
}
