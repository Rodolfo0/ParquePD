﻿using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ParqueProcesoDesarollo_Estacionamiento
{
    //Clase de la forma frmImportePago
    //Autor: Alejandro Barroeta Martínez
    //Fecha: -abril-2022
    //Versión: 1.0
    //Modificación: -abril-2022
    public partial class frmImportePago : MetroForm
    {
        private static frmImportePago importePago;
        private static string idBoletoAPagar;
        private static int maquinaEscogida = 0;
        private int total = 0;
        private static int monedasIngresadas5 = 0;
        private static int monedasIngresadas10 = 0;
        private static int billetesIngresados50 = 0;
        private static int billetesIngresados100 = 0;

        private frmImportePago()
        {
            InitializeComponent();
        }

        public static frmImportePago ObtenerInstancia(string pBoleto, int pMaquina)
        {
            idBoletoAPagar = pBoleto;
            maquinaEscogida = pMaquina;

            if (importePago == null)
            {
                importePago = new frmImportePago();
                return importePago;
            }
            else
                return importePago;

        }

        private void frmImportePago_Load(object sender, EventArgs e)
        {
            txtMonedas5.Text = "0";
            txtMonedas10.Text = "0";
            txtBilletes50.Text = "0";
            txtBilletes100.Text = "0";

            DateTime horaEntrada = new DateTime();
            txtFolio.Text = "Folio del boleto: " + idBoletoAPagar;
            txtFechaActual.Text = DateTime.Now.Date.ToString("d");
            txtHoraSalida.Text = "Hora de salida: " + DateTime.Now.ToString("hh:mm:ss tt");
            double diferencia = 0.0;

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT DateOfEntry, TimeOfEntry FROM ParkingTickets WHERE Id=@id", connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = ObtenerId(idBoletoAPagar);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    horaEntrada = Convert.ToDateTime(reader["TimeOfEntry"]);
                    txtHoraEntrada.Text = "Hora de Entrada: " + horaEntrada.ToString("hh:mm:ss tt");
                }

                if (DateTime.Now.Date == Convert.ToDateTime(reader["DateOfEntry"]).Date)
                {
                    if (DateTime.Now.TimeOfDay.Hours == Convert.ToDateTime(reader["TimeOfEntry"]).TimeOfDay.Hours)
                    {
                        diferencia = Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60;
                    }
                    else
                    {
                        diferencia = (Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60)
                            + (Math.Abs(Convert.ToDateTime(reader["TimeOfEntry"]).TimeOfDay.Hours - DateTime.Now.TimeOfDay.Hours));
                    }
                }
                else
                {
                    diferencia = Convert.ToDouble(Math.Abs(horaEntrada.TimeOfDay.Minutes - DateTime.Now.TimeOfDay.Minutes) / 60
                    + Convert.ToDouble(Math.Abs((24 - horaEntrada.TimeOfDay.Hours) + DateTime.Now.TimeOfDay.Hours)));
                }

                if (diferencia >= 0 && diferencia <= .25)
                {
                    lblTotal.Text = "$0";
                    MetroMessageBox.Show(this, "Vuelva Pronto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Se tiene que actualizar la base de datos aquí
                    frmPagarBoleto.ObtenerInstancia(maquinaEscogida);
                }
                else if (diferencia > .25 && diferencia <= 3)
                {
                    total = 20;
                    lblTotal.Text = "$20";
                }
                else
                {
                    total = 20 + (((int)diferencia - 3) * 10);
                    lblTotal.Text = "$" + total.ToString();
                }

                reader.Close();
                connection.Close();
            }
        }

        private int ObtenerId(string pLinea)
        {
            if (pLinea.Contains("00000000"))
                return Convert.ToInt16(pLinea.Substring(7));
            else if (pLinea.Contains("0000000"))
                return Convert.ToInt16(pLinea.Substring(6));
            else if (pLinea.Contains("000000"))
                return Convert.ToInt16(pLinea.Substring(5));
            else if (pLinea.Contains("00000"))
                return Convert.ToInt16(pLinea.Substring(4));
            else if (pLinea.Contains("0000"))
                return Convert.ToInt16(pLinea.Substring(3));
            else if (pLinea.Contains("000"))
                return Convert.ToInt16(pLinea.Substring(2));
            else if (pLinea.Contains("00"))
                return Convert.ToInt16(pLinea.Substring(1));
            else if (pLinea.Contains("0"))
                return Convert.ToInt16(pLinea.Substring(0));
            else
                return 0;
        }

        private void frmImportePago_FormClosed(object sender, FormClosedEventArgs e)
        {
            importePago = null;
            frmPagarBoleto.ObtenerInstancia(maquinaEscogida).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "¿Está seguro de que quiere cancelar el pago del boleto", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            int cambio = 0;
            int dineroIngresado = Convert.ToInt16(txtMonedas5.Text) * 5 + Convert.ToInt16(txtMonedas10.Text) * 10 + Convert.ToInt16(txtBilletes50.Text) * 50 + Convert.ToInt16(txtBilletes100.Text) * 100;

            foreach (MetroTextBox textBox in this.Controls.OfType<MetroTextBox>())
            {
                if (textBox.Text == "")
                    textBox.Text = "0";
            }

            monedasIngresadas5 += Convert.ToInt32(txtMonedas5.Text);
            monedasIngresadas10 += Convert.ToInt32(txtMonedas10.Text);
            billetesIngresados50 += Convert.ToInt32(txtBilletes50.Text);
            billetesIngresados100 += Convert.ToInt32(txtBilletes100.Text);

            if (dineroIngresado == total)
            {
                RegistrarEnBaseDeDatos();

                if(MetroMessageBox.Show(this, "El pago se ha realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK)
                {
                    this.Close();
                }

            }
            else if (dineroIngresado < total)
            {
                total -= dineroIngresado;
                lblTotal.Text = "$"+total.ToString();
            }
            else
            {
                cambio = dineroIngresado - total;

                RegistrarEnBaseDeDatos();

                if (MetroMessageBox.Show(this, "Su cambio es de $"+cambio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void RegistrarEnBaseDeDatos()
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO ParkingTicketPaymentMachines VALUES (@maquinaId,@boletoId)", connection);
                command.Parameters.Add("@maquinaId", SqlDbType.Int);
                command.Parameters["@maquinaId"].Value = maquinaEscogida;

                command.Parameters.Add("@boletoId", SqlDbType.Int);
                command.Parameters["@boletoId"].Value = idBoletoAPagar;

                command.ExecuteNonQuery();

                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BD_PD;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE ParkingTickets SET StatusId=1, TimeOfPayment=@horaSalida", connection);
                command.Parameters.Add("@horaSalida", SqlDbType.Time);
                command.Parameters["@horaSalida"].Value = Convert.ToDateTime(DateTime.Now).TimeOfDay;

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
