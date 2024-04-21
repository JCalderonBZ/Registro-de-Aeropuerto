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

namespace ejercicio1
{
    public partial class usuario : Form
    {
        public usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = database.ObtenerConexion();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();

            codigo.Connection = conectar;
            codigo.CommandText = ("Select * from client where username = '" + txtName.Text + "' and password='" + txtPassword.Text + "'");


            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show("Bienvenido");
                new registro().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("ERROR!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MySqlConnection conectar = database.ObtenerConexion();


            //DateTime fecha = Convert.ToDateTime(dateCumple.Value.Date.ToString("yyyy-MM-dd"));
            string fecha = dateCumple.Value.ToString("yyyy-MM-dd");
            //var fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string username = txtUser.Text;
            string pass = txtPass.Text;
            string cadena = "INSERT INTO client (username,password,fecha_Act) values ('" + username + "','" + pass + "','" + fecha + "')";
            MySqlCommand comand = new MySqlCommand(cadena, conectar);
            comand.ExecuteNonQuery();
            MessageBox.Show("Se guardaron exitosamente");
            txtUser.Text = "";
            txtPass.Text = "";
            dateCumple.Text = "";

        }
    }
}
