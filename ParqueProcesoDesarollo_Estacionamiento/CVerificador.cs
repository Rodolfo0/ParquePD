using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase que permite la validación de los datos ingresados en las formas
    //Autor: Alejandro Barroeta Martínez
    //Fecha: 17-abril-2022
    //Versión: 1.0
    //Modificación: 17-abril-2022
    internal class CVerificador
    {
        private string[] keyWords;

        //Constructor de la clase CVerificador
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        public CVerificador()
        {
            //Se inicializa el arreglo con las palabras clave del lenguaje SQL
            keyWords = new string[] {"SELECT","FROM","WHERE",
                "DROP","IN","INSERT","UPDATE","DELETE",
                "CREATE","ALTER","VIEW","PROCEDURE","FUNCTION",
                "TRIGGER","EXEC","EXECUTE","PRINT","IF","EXISTS",
                "CONCAT","DATABASE","SET","DECLARE","AS","%","="};
        }

        //Método que evalúa si se han ingresado instrucciones SQL en alguna caja de texto
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pForm> Forma que será analizada </param>
        //<returns> Valor booleano que indica si existe alguna palabra clave en la caja de texto </returns>
        public bool AntiInyeccionSQL(MetroForm pForm)
        {
            foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
            {
                foreach (string k in keyWords)
                {
                    string textoMayusculas = tb.Text.ToUpper();

                    if (Regex.IsMatch(textoMayusculas, "\\b" + k + "\\b"))
                    {
                        tb.Clear();
                        MessageBox.Show("No se puede ingresar esta palabra", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        //Método que valida que las cajas de texto no se hayan quedado vacías
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pForm> Forma que será analizada </param>
        //<returns> Valor booleano que indica si existe alguna caja vacía en la forma </returns>
        private bool TextoVacio(MetroForm pForm)
        {
            //Se recorren todas las cajas de texto en la forma
            foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
            {
                //Si está vacía se devuelve true
                if (tb.Text == "")
                    return true;
            }
            return false;
        }

        //Método que valida que las cantidades de texto no se encuentren en un rango inválido
        //Autor: Alejandro Barroeta Martínez
        //Fecha: 17-abril-2022
        //Versión: 1.0
        //Modificación: 17-abril-2022
        //<param name="pForm> Forma que será analizada </param>
        //<returns> Valor booleano que indica si existe alguna cantidad inválida en la forma </returns>
        public bool CantidadesInvalidas(MetroForm pForm)
        {
            //Se valida que las cajas no estén vacías
            if (TextoVacio(pForm))
            {
                MetroMessageBox.Show(pForm, "Monto(s) inválido(s). Inténtelo Nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //Se recorren todas las cajas de texto en la forma
                foreach (MetroTextBox tb in pForm.Controls.OfType<MetroTextBox>())
                {
                    //Se valida si la cantidad es menor a 0
                    if (Convert.ToInt16(tb.Text) <= 0)
                    {
                        MetroMessageBox.Show(pForm, "Monto(s) inválido(s). Inténtelo Nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }

        }

    }
}
