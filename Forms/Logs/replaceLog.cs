using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kursovaya.Forms.Logs
{
    public partial class replaceLog : @base
    {
        Records records = new Records();


        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String,
            RowType.Date
        };

        public replaceLog()
        {
            InitializeComponent();
        }

        private void replaceLog_Load(object sender, EventArgs e)
        {
            CreateColumns();
            records.RefreshRecords(dataGridView1, "replaceLog", RowTypes);
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("room_number", "Номер кабинета");
            dataGridView1.Columns.Add("inv_number", "Инв. номер");
            dataGridView1.Columns.Add("date", "Дата");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            inv_number,
            room_number,
            date
            };
            records.addRecord("replaceLog", textBoxes);
            records.RefreshRecords(dataGridView1, "replaceLog", RowTypes);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 3);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            room_number,
            inv_number,
            date
            };

            records.change(dataGridView1, textBoxes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            records.Update(records, dataGridView1, "replaceLog", new[]
            { "room_number",
            "inv_number",
            "date",
             }, new[] { "room_number", "inv_number" }
);
            records.RefreshRecords(dataGridView1, "replaceLog", RowTypes);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            String[] searching_fields = { "inv_number", "room_number", "date" };
            records.Search(dataGridView1, "replaceLog", textBox_search, searching_fields, RowTypes);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            records.RefreshRecords(dataGridView1, "replaceLog", RowTypes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по перемещениях", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] textBoxes = {
            room_number,
            inv_number,
            date
            };

            records.FiilTextBoxsOnCellClick(dataGridView1, textBoxes, e);
        }
    }
}
