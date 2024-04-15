using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kursovaya.Forms.Computers
{
    public partial class statusList : @base
    {
        Records records = new Records();

        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String,
            RowType.String
        };


        public statusList()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes =
            {
            id_status,
            name,
            description
            };

            records.addRecord("statusList", textBoxes);
            records.RefreshRecords(dataGridView1, "statusList", RowTypes);
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 4);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
        }

        private void textBox_search_TextChanged_1(object sender, EventArgs e)
        {
            String[] searching_fields = { "id_status", "name","description" };
            records.Search(dataGridView1, "statusList", textBox_search, searching_fields, RowTypes);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            String[] searching_fields = { "id_status", "name" };
            records.Search(dataGridView1, "statusList", textBox_search, searching_fields, RowTypes);
        }

        private void button_delete_Click_1(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 4);
        }

        private void button_update_Click_1(object sender, EventArgs e)
        {
            TextBox[] textBoxes =
            {
            id_status,
            name,
            description
            };
            records.change(dataGridView1, textBoxes);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            records.Update(records, dataGridView1, "statusList", new[]
            { "id_status",
            "name",
            "description" },
            new[] { "id_status" }
            );
        }

        private void FiilTextBoxsOnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] textBoxes =
            {
            id_status,
            name,
            description
            };

            records.FiilTextBoxsOnCellClick(dataGridView1, textBoxes, e);
        }

        private void statusList_Load(object sender, EventArgs e)
        {
            CreateColumns();
            records.RefreshRecords(dataGridView1, "statusList", RowTypes);
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_status", "Код статуса");
            dataGridView1.Columns.Add("name", "Название");
            dataGridView1.Columns.Add("description", "Описание");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }
    }
}
