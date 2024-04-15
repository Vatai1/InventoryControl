using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Forms.Lists
{
    public partial class positions : @base
    {

        RowType[] RowTypes =
{
            RowType.Int,
            RowType.String,
            RowType.Int,
        };

        Records records = new Records();

        public positions()
        {
            InitializeComponent();
        }

        private void positions_Load(object sender, EventArgs e)
        {
            CreateColumns();
            records.RefreshRecords(dataGridView1, "positionList", RowTypes);
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_position", "Код должности");
            dataGridView1.Columns.Add("name", "Название");
            dataGridView1.Columns.Add("baseSalary", "Оклад");
            dataGridView1.Columns.Add("isNew", String.Empty);

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            id_position,
            name,
            baseSalary
            };
            records.addRecord("positionList", textBoxes, "positionList");
            records.RefreshRecords(dataGridView1, "positionList", RowTypes);
        }

        private void button_delete_Click_1(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 3);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            String[] searching_fields = { "id_position", "name", "baseSalary"};
            records.Search(dataGridView1, "positionList", textBox_search, searching_fields, RowTypes);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] textBoxes = {
            id_position,
            name,
            baseSalary
            };

            records.FiilTextBoxsOnCellClick(dataGridView1, textBoxes, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_update_Click_1(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            id_position,
            name,
            baseSalary
            };
            records.change(dataGridView1, textBoxes);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            records.Update(records, dataGridView1, "positionList", new[]
            { "id_position",
            "name",
            "baseSalary"
            }, new[] { "id_position" });
        }

        private void button_refresh_Click_1(object sender, EventArgs e)
        {
            records.RefreshRecords(dataGridView1, "positionList", RowTypes);
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
