using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmInicioSesion
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    public partial class frmInicioSesion : MetroForm
    {
        //Referencia que permitirá crear una única instancia de la clase
        private static frmInicioSesion inicioSesion;

        //Constructor de la clase frmInicioSesion
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        private frmInicioSesion()
        {
            InitializeComponent();
        }

        //Método que permite la creación de una única instancia de la clase
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<returns> Instancia de la clase creada </returns>
        public static frmInicioSesion ObtenerInstancia()
        {
            //Se valida si ya existe una instancia de la clase o no
            if (inicioSesion == null)
            {
                inicioSesion = new frmInicioSesion();
                return inicioSesion;
            }
            else
                return inicioSesion;
        }

        //Método invocado cuando se carga la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }

        //Método invocado cuando se cierra la forma
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void frmInicioSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Método invocado cuando se da click en el botón btnIngresar
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="sender"> Referencia del objeto que llama al evento </param>
        //<param name="e"> Pasa un objeto específico al evento que se está manejando </param>
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            //Se crea una nueva conexión con la base de datos
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                //Se crea la instrucción que se quiere ejecutar
                SqlCommand command = new SqlCommand("SELECT * FROM AspNetUsers WHERE Email = @User", connection);
                command.Parameters.Add("@User", SqlDbType.VarChar);
                command.Parameters["@User"].Value = txtUsuario.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                //Se valida si hay filas por recorrer
                if (dataReader.Read())
                {
                    string user = Convert.ToString(dataReader["email"]);
                    // string password = Convert.ToString(dataReader["contrasenia"]);

                    //Se valida si el usuario existe
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
    }
}
