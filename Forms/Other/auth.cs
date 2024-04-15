using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Forms.Other
{
    public partial class auth : Form
    {
        Database database = new Database();

        public auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }

     

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            Database database = new Database();
            DataTable table = new DataTable();

            var loginUser = textBox1.Text;
            var password = textBox2.Text;

            string queryString = $"SELECT id_user, login, password_user FROM users WHERE login='{loginUser}' AND password_user='{password}'";


            MySqlCommand command = new MySqlCommand(queryString, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {

                MessageBox.Show("Вы успешно зашли", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainMenu mainMenu = new mainMenu();
                this.Hide();
                mainMenu.Show();
                //this.Show();

            }
            else
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
