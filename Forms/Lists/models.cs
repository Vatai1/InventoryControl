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

namespace Kursovaya.Forms.Computers
{
    public partial class models : @base
    {
        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.Int,
        };



        Records records = new Records();

        public models()
        {
            InitializeComponent();
        }

        private void models_Load(object sender, EventArgs e)
        {
            CreateColumns();
            records.RefreshRecords(dataGridView1, "modelList", RowTypes);
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_model", "Код модели");
            dataGridView1.Columns.Add("Vendor", "Вендор");
            dataGridView1.Columns.Add("Model", "Модель");
            dataGridView1.Columns.Add("CPU", "CPU");
            dataGridView1.Columns.Add("GPU", "GPU");
            dataGridView1.Columns.Add("RAM", "RAM (GB)");
            dataGridView1.Columns.Add("isNew", String.Empty);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            Vendor,
            Model,
            CPU,
            GPU,
            RAM
            };
            records.addRecord("modelList", textBoxes, "id_model");
            records.RefreshRecords(dataGridView1, "modelList", RowTypes);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            records.deleteRow(dataGridView1, 6);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            String[] searching_fields = { "Vendor", "Model","GPU","CPU","RAM" };
            records.Search(dataGridView1, "modelList", textBox_search, searching_fields, RowTypes);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox []textBoxes = {
            id_model,
            Vendor,
            Model,
            CPU,
            GPU,
            RAM
            };

            records.FiilTextBoxsOnCellClick(dataGridView1, textBoxes, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {
            id_model,
            Vendor,
            Model,
            CPU,
            GPU,
            RAM
            };
            records.change(dataGridView1, textBoxes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            records.Update(records, dataGridView1, "modelList", new[]
            { "id_model",
            "Vendor",
            "Model",
            "CPU",
            "GPU",
            "RAM", }, new[] { "id_model" }
            );
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            records.RefreshRecords(dataGridView1, "modelList", RowTypes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчёт по моделям", dataGridView1);
        }
    }
}
