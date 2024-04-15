using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Kursovaya.Forms.Lists;
using Kursovaya.Forms.Other;
using Kursovaya.Forms.Computers;
using Kursovaya.Forms.Logs;
using MySql.Data.MySqlClient;


namespace Kursovaya
{
    public partial class mainMenu : @base
    {




        public mainMenu()
        {
            InitializeComponent();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            models models = new models();
            models.Show();
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            deportments deportments = new deportments();
            deportments.Show();
            this.Hide();
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            workers workers = new workers();
            workers.Show();
            this.Hide();
        }

        private void position_Click(object sender, EventArgs e)
        {
            positions positions = new positions();
            positions.Show();
            this.Hide();
        }

        private void room_Click(object sender, EventArgs e)
        {
            room room = new room();
            room.Show();
            this.Hide();
        }

        private void computers_Click(object sender, EventArgs e)
        {
            computers computer = new computers();
            computer.Show();
            this.Hide();
        }

        private void status_Click(object sender, EventArgs e)
        {
            statusList statusList = new statusList();
            statusList.Show();
            this.Hide();
        }

        private void journalComputers_Click(object sender, EventArgs e)
        {
            statusLog statusLog = new statusLog();
            statusLog.Show();
            this.Hide();
        }

        private void journalReplace_Click(object sender, EventArgs e)
        {
            replaceLog replaceLog = new replaceLog();
            replaceLog.Show();
            this.Hide();
        }
    }
}
