using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CU_08_Pago_Estacionamiento
{
    internal class CVerificador
    {
        public void AntiInyeccionSQL(MetroForm pForm)
        {
            foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
            {

            }
        }

        public bool TextoVacio(MetroForm pForm)
        {
            foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
            {
                if (tb.Text == "")
                    return true;
            }
            return false;
        }

        public bool CantidadesInvalidas(MetroForm pForm)
        {
            if (TextoVacio(pForm))
            {
                MetroMessageBox.Show(pForm, "Monto(s) inválido(s). Inténtelo Nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
                {
                    if (Convert.ToInt16(tb.Text) <= 0)
                    {
                        MetroMessageBox.Show(pForm, "Monto(s) inválido(s). Inténtelo Nuevamente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }

        }

    }
}
