using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Forms.Lists
{


    public partial class deportments : @base
    {

        Records records = new Records();


        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
        };


        public deportments()
        {
            InitializeComponent();
        }

        private void deportments_Load(object sender, EventArgs e)
        {

            CreateColumns();
            records.RefreshRecords(dataGridView1,"deportment", RowTypes);
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_dept", "Код подразделения");
            dataGridView1.Columns.Add("name", "Название отдела");
            dataGridView1.Columns.Add("surNameChief", "Фамилия начальника отдела");
            dataGridView1.Columns.Add("firstNameChief", "Имя начальника отдела");
            dataGridView1.Columns.Add("pantrimycChief", "Отчество начальника отдела");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void ГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            records.RefreshRecords(dataGridView1,"deportment", RowTypes);
        }


        private void addRecordButton_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            id_dept,
            name,
            firstNameChief,
            surNameChief,
            pantrimycChief,
            };
            records.addRecord("deportment", textBoxes);
            records.RefreshRecords(dataGridView1, "deportment", RowTypes);
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 5);
        }

        private void textBox_search_TextChanged_1(object sender, EventArgs e)
        {
            String[] searching_fields = { "id_dept", "name"};
            records.Search(dataGridView1, "deportment", textBox_search, searching_fields, RowTypes);
        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {
        }

        private void button_delete_Click_1(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 5);
        }

        private void button_update_Click_1(object sender, EventArgs e)
        {
            TextBox[] textBoxes =
            {
            id_dept,
            name,
            firstNameChief,
            surNameChief,
            pantrimycChief,
            };
            records.change(dataGridView1,textBoxes);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            records.Update(records,dataGridView1, "deportment",new [] 
            { "id_dept",
            "name",
            "firstNameChief",
            "surNameChief",
            "pantrimycChief", },new []{ "id_dept"}
            );
        }

        private void FiilTextBoxsOnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] textBoxes =
            {
            id_dept,
            name,
            firstNameChief,
            surNameChief,
            pantrimycChief,
            };

            records.FiilTextBoxsOnCellClick(dataGridView1, textBoxes, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по отделам",dataGridView1);
        }

        private void settings_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void sdsdsdsdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pantrimycChief_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void firstNameChief_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void surNameChief_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
