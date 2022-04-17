using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
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

        }
    }
}
