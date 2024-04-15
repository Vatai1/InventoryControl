using Devart.Data.MySql;
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
    public partial class room : @base
    {
        Records record = new Records();
        Database database = new Database();
        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String
        };


        public room()
        {
            InitializeComponent();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_dept", "Код подразделения");
            dataGridView1.Columns.Add("name", "Название отдела");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }
        private void room_Load(object sender, EventArgs e)
        {
            CreateColumns();
            record.RefreshRecordsWithJoin(dataGridView1, "room", RowTypes, new[]
            {
                "room.room_number",
                "deportment.name"
            }, "deportment ON room.id_dept= deportment.id_dept;");

            record.setUniqueValusToComboBox(comboBox1, "deportment", "name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            String RoomNumber = room_number.Text;
            String DepartmentField = comboBox1.SelectedItem.ToString();

            if (!database.checkExistRecord("room", "id_dept", RoomNumber))
            {
                String queryString = $"INSERT INTO room (room_number, id_dept) SELECT {RoomNumber}, id_dept FROM deportment WHERE name = '{DepartmentField}';";
                database.sendQueryWithoutResponse(queryString);
            }
            else MessageBox.Show("Ошибка. Запись с таким уникальный ключом уже существует", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            record.RefreshRecordsWithJoin(dataGridView1, "room", RowTypes, new[]
{
                "room.room_number",
                "deportment.name"
            }, "INNER JOIN deportment ON room.id_dept= deportment.id_dept;");
        }

        private void button_refresh_Click_1(object sender, EventArgs e)
        {
            record.RefreshRecordsWithJoin(dataGridView1, "room", RowTypes, new[]
 {
                "room.room_number",
                "deportment.name"
            }, "INNER JOIN deportment ON room.id_dept= deportment.id_dept;");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по кабинетам", dataGridView1);
        }
    }
}
