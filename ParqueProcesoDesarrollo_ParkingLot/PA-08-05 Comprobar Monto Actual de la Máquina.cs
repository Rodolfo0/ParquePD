using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CU_08_Pago_Estacionamiento
{
    public partial class frmComprobarMonto : MetroForm
    {
        private static frmComprobarMonto comprobarMonto;
        private List<int> numeroMaquinas = new List<int>();
        private int bandera = 0;

        private frmComprobarMonto()
        {
            InitializeComponent();
        }

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

        private void frmComprobarMonto_Load(object sender, EventArgs e)
        {
            txtMonedas5.Enabled = false;
            txtMonedas10.Enabled = false;
            txtBilletes50.Enabled = false;
            txtBilletes100.Enabled = false;

            if (bandera == 0)
            {
                cmbMaquinas.Items.Add("Seleccione una máquina");
                cmbMaquinas.SelectedIndex = 0;

                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT idMaquinaCobro FROM MaquinasCobro WHERE idEstado=1", connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["idMaquinaCobro"]));
                        numeroMaquinas.Add(Convert.ToInt16(dataReader["idMaquinaCobro"]));
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

                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-CAT4E9GN\\SQLEXPRESS;Initial Catalog=Estacionamiento;" +
                   "Integrated Security=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT idMaquinaCobro FROM MaquinasCobro WHERE idEstado=1", connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["idMaquinaCobro"]));
                        numeroMaquinas.Add(Convert.ToInt16(dataReader["idMaquinaCobro"]));
                    }

                    connection.Close();
                    dataReader.Close();
                }
            }

        }

        private void cmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaquinas.SelectedIndex != 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM MaquinasCobro WHERE idMaquinaCobro=@idMaquinaCobro", connection);

                    command.Parameters.Add("@idMaquinaCobro", SqlDbType.Int);
                    command.Parameters["@idMaquinaCobro"].Value = numeroMaquinas[cmbMaquinas.SelectedIndex - 1];

                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();

                    txtMonedas5.Text = Convert.ToString(Convert.ToInt16(dataReader["inicioMonedas5"]) + (dataReader["monedasIngresadas5"] != DBNull.Value ? Convert.ToInt16(dataReader["monedasIngresadas5"]) : 0));
                    txtMonedas10.Text = Convert.ToString(Convert.ToInt16(dataReader["inicioMonedas10"]) + (dataReader["monedasIngresadas10"] != DBNull.Value ? Convert.ToInt16(dataReader["monedasIngresadas10"]) : 0));
                    txtBilletes50.Text = Convert.ToString(Convert.ToInt16(dataReader["inicioBilletes50"]) + (dataReader["billetesIngresados50"] != DBNull.Value ? Convert.ToInt16(dataReader["billetesIngresados50"]) : 0));
                    txtBilletes100.Text = Convert.ToString(Convert.ToInt16(dataReader["inicioBilletes100"]) + (dataReader["billetesIngresados100"] != DBNull.Value ? Convert.ToInt16(dataReader["billetesIngresados100"]) : 0));

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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmComprobarMonto_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            comprobarMonto = null;
            frmInicioSesion.ObtenerInstancia().Show();
        }

        private void btnIngresarMonto_Click(object sender, EventArgs e)
        {
            if (cmbMaquinas.SelectedIndex != 0)
            {
                if (MetroMessageBox.Show(this, "¿Está seguro que quiere deshabilitar esta máquina", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("UPDATE MaquinasCobro " +
                    "SET inicioMonedas5=0,inicioMonedas10=0," +
                    "inicioBilletes50=0,inicioBilletes100=0," +
                    "monedasIngresadas5=0, monedasIngresadas10=0, billetesIngresados50=0, billetesIngresados100=0, idEstado=2 " +
                    "WHERE idMaquinaCobro=@numMaquinaCobro"
                        , connection);

                        command.Parameters.Add("@numMaquinaCobro", SqlDbType.Int);
                        command.Parameters["@numMaquinaCobro"].Value = numeroMaquinas[cmbMaquinas.SelectedIndex - 1];

                        if (command.ExecuteNonQuery() != 0)
                            MetroMessageBox.Show(this, "Máquina Deshabilitada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MetroMessageBox.Show(this, "Máquina Deshabilitada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connection.Close();
                    }

                    bandera = 1;
                    frmComprobarMonto_Load(sender, e);
                }
            }
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {

        }
    }
}
