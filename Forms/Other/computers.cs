using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Forms.Other
{
    public partial class computers : @base
    {

        Records record = new Records();
        Database database = new Database();
        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.Int,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
        };


        public computers()
        {
            InitializeComponent();
        }

        private void computers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            record.RefreshRecordsWithJoin(dataGridView1, "computer", RowTypes, new[]
            {
               "computer.inv_number",
               "worker.pers_number",
               "room.room_number",
               "modelList.Model",
               "statusList.name",
               "computer.IP",
               "computer.SN",
               "computer.MAC",
            }, "INNER JOIN \r\n    modelList ON computer.id_model = modelList.id_model \r\nINNER JOIN \r\n    statusList ON computer.id_status = statusList.id_status  \r\nINNER JOIN \r\n    room ON computer.room_number = room.room_number\r\nINNER JOIN\r\n    worker ON computer.pers_number = worker.pers_number;;");

            record.setUniqueValusToComboBox(comboBox1, "room", "room_number");
            record.setUniqueValusToComboBox(comboBox2, "modelList", "model");
            record.setUniqueValusToComboBox(comboBox3, "statusList", "name");
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("inv_number", "Инв. номер");
            dataGridView1.Columns.Add("pers_number", "Таб. номер сотрудника");
            dataGridView1.Columns.Add("room_number", "Номер кабинета");
            dataGridView1.Columns.Add("model_name", "Модель");
            dataGridView1.Columns.Add("status_name", "Статус");
            dataGridView1.Columns.Add("IP", "IP");
            dataGridView1.Columns.Add("SN", "S\\N");
            dataGridView1.Columns.Add("MAC", "MAC");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по сотрудниках", dataGridView1);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
