using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Forms.Logs
{
    public partial class statusLog : @base
    {

        Records record = new Records();
        Database database = new Database();
        RowType[] RowTypes =
        {
            RowType.String,
            RowType.String,
            RowType.Date,
            RowType.String,
        };

        public statusLog()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("name", "Инв. номер");
            dataGridView1.Columns.Add("status", "Статус");
            dataGridView1.Columns.Add("date", "Дата");
            dataGridView1.Columns.Add("comment", "Комментарий");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            record.RefreshRecordsWithJoin(dataGridView1, "statusLog", RowTypes, new[]
            {
                "statusLog.inv_number",
                "statusList.name",
                "statusLog.date",
                "statusLog.comment"
            }, "statusList ON statusLog.id_status = statusList.id_status;");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по статусам", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            String inv_num = inv_number.Text;
            String StatusField = comboBox1.SelectedItem.ToString();
         

            if (!database.checkExistRecord("room", "id_dept", inv_num))
            {
                String queryString = $"INSERT INTO statusLog (inv_number, id_status,date) SELECT {inv_num}, id_status, {date.Text} FROM statusList WHERE name = '{StatusField}';";
                database.sendQueryWithoutResponse(queryString);
            }
            else MessageBox.Show("Ошибка. Запись с таким уникальный ключом уже существует", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            record.RefreshRecordsWithJoin(dataGridView1, "room", RowTypes, new[]
{
                "room.room_number",
                "deportment.name"
            }, "deportment ON room.id_dept= deportment.id_dept;");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusLog_Load(object sender, EventArgs e)
        {
            CreateColumns();
            record.RefreshRecordsWithJoin(dataGridView1, "statusLog", RowTypes, new[]
            {
                "statusLog.inv_number",
                "statusList.name",
                "statusLog.date",
                "statusLog.comment"
            }, "statusList ON statusLog.id_status = statusList.id_status;");

            record.setUniqueValusToComboBox(comboBox1, "statusList", "name");
        }

        private void room_number_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
