using MetroFramework.Forms;
using System;
using System.Data.SqlClient;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    public partial class frmElegirMaquina : MetroForm
    {
        private static frmElegirMaquina elegirMaquina;
        private static int tipoMaquina;
        private frmElegirMaquina()
        {
            InitializeComponent();
        }

        public static frmElegirMaquina ObtenerInstancia(int pTipoMaquina)
        {
            tipoMaquina = pTipoMaquina;
            if (elegirMaquina == null)
            {
                elegirMaquina = new frmElegirMaquina();
                return elegirMaquina;
            }
            else
                return elegirMaquina;
        }

        private void frmElegirMaquina_Load(object sender, EventArgs e)
        {
            cmbMaquinas.Items.Add("Seleccione una máquina");
            cmbMaquinas.SelectedIndex = 0;

            if (tipoMaquina == 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT idMaquinaImpresora FROM MaquinasImpresoras", connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["idMaquinaImpresora"]));
                    }

                    dataReader.Close();
                    connection.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT idMaquinaCobro FROM MaquinasCobro WHERE idEstado=1", connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cmbMaquinas.Items.Add("Máquina " + Convert.ToString(dataReader["idMaquinaCobro"]));
                    }

                    dataReader.Close();
                    connection.Close();
                }
            }
        }

        private void cmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoMaquina == 0)
            {
                if (cmbMaquinas.SelectedIndex == 1)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(1).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 2)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(2).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 3)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(3).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 4)
                {
                    frmImprimirBoletoEstacionamiento.ObtenerInstancia(4).Show();
                    this.Close();
                }
            }
            else
            {
                if (cmbMaquinas.SelectedIndex == 1)
                {
                    frmPagarBoleto.ObtenerInstancia(1).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 2)
                {
                    frmPagarBoleto.ObtenerInstancia(2).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 3)
                {
                    frmPagarBoleto.ObtenerInstancia(3).Show();
                    this.Close();
                }

                if (cmbMaquinas.SelectedIndex == 4)
                {
                    frmPagarBoleto.ObtenerInstancia(4).Show();
                    this.Close();
                }
            }
        }

        private void frmElegirMaquina_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            elegirMaquina = null;
        }
    }
}
