using MetroFramework.Forms;
using System;
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
                            txtIngresarBoleto.Text = folio;
                            frmImportePago.ObtenerInstancia(folio,maquinaEscogida).Show();
                            this.Hide();
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
                    linea = File.ReadAllLines(fileName)[i-1];
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
            ingresarBoleto = null;
            frmPagarBoleto.ObtenerInstancia(maquinaEscogida).Show();
        }
    }
}
