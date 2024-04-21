using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ejercicio1;

namespace ejercicio1
{
    public partial class registro : Form
    {
        tabla obj = new tabla();
        public registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = database.ObtenerConexion();

            //DateTime fecha = Convert.ToDateTime(dateCumple.Value.Date.ToString("yyyy-MM-dd"));
            //string fecha = dateCumple.Value.ToString("yyyy-MM-dd");
            //var fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string nombre = name.Text;
            string ape = apellido.Text;
            string pasa = pasaporte.Text;
            string aero = lista.Text;
            string vuel = vuelo.Text;
            string ori = origen.Text;
            string dest = destino.Text;
            string fecha = fechaH.Value.ToString("yyyy-MM-dd");

            string result = "INSERT INTO registro (nombre,apellido,pasaporte,aerolinea,vuelo,pais_origen,pais_destino,fecha) values ('" + nombre + "','" + ape + "','" + pasa + "','" + aero + "','" + vuel + "','" + ori + "','" + dest + "','" + fecha + "')";
            MySqlCommand comand = new MySqlCommand(result, conectar);
            comand.ExecuteNonQuery();
            MessageBox.Show("Se guardaron exitosamente");
            name.Text = "";
            apellido.Text = "";
            pasaporte.Text = "";
            lista.Text = "";
            vuelo.Text = "";
            origen.Text = "";
            destino.Text = "";
            fechaH.Text = "";

        }

        private void close_Click(object sender, EventArgs e)
        {
            new usuario().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void registro_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.vistaTabla();
        }
    }
}
