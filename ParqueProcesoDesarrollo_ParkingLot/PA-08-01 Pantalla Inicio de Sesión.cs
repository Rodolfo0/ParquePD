using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CU_08_Pago_Estacionamiento
{
    public partial class frmInicioSesion : MetroForm
    {
        private static frmInicioSesion inicioSesion;
        private frmInicioSesion()
        {
            InitializeComponent();
        }

        public static frmInicioSesion ObtenerInstancia()
        {
            if (inicioSesion == null)
            {
                inicioSesion = new frmInicioSesion();
                return inicioSesion;
            }
            else
                return inicioSesion;
        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM AspNetUsers WHERE Email = @User", connection);
                command.Parameters.Add("@User", SqlDbType.VarChar);
                command.Parameters["@User"].Value = txtUsuario.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    string user = Convert.ToString(dataReader["email"]);
                    // string password = Convert.ToString(dataReader["contrasenia"]);

                    if (txtUsuario.Text == user)
                    {
                        frmPantallaPrincipal.ObtenerInstancia().Show();
                        Hide();
                        dataReader.Close();
                        connection.Close();

                        txtUsuario.Clear();
                        txtContraseña.Clear();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Usuario o contraseña incorrecto", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Usuario o contraseña incorrecto", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmInicioSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
