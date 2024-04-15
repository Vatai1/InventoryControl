using Kursovaya.Forms.Lists;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.Forms.Computers
{
    public partial class workers : @base
    {

        Records record = new Records();
        Database database = new Database();
        RowType[] RowTypes =
        {
            RowType.Int,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.String,
            RowType.Date
        };



        public workers()
        {
            InitializeComponent();
        }

        private void reportComputers_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("pers_number", "Табельный номер");
            dataGridView1.Columns.Add("surName", "Фамилия");
            dataGridView1.Columns.Add("firstName", "Имя");
            dataGridView1.Columns.Add("pantrimyc", "Отечество");
            dataGridView1.Columns.Add("position_name", "Должность");
            dataGridView1.Columns.Add("deportment_name", "Отдел");
            dataGridView1.Columns.Add("phone", "Телефон");
            dataGridView1.Columns.Add("address", "Адрес");
            dataGridView1.Columns.Add("email", "Почта");
            dataGridView1.Columns.Add("birthday", "Дата рождения");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void workers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            record.RefreshRecordsWithJoin(dataGridView1, "worker", RowTypes, new[]
            {
               "worker.pers_number",
               "worker.firstName",
               "worker.surName",
               "worker.pantrimyc",
               "deportment.name",
               "positionList.name",
               "worker.phone",
               "worker.address",
               "worker.email",
               "worker.birthday"
            }, "INNER JOIN positionList ON worker.id_position = positionList.id_position\r\nINNER JOIN deportment ON worker.id_dept= deportment.id_dept;");

            record.setUniqueValusToComboBox(comboBox1, "positionList", "name");
            record.setUniqueValusToComboBox(comboBox2, "deportment", "name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            String pers_num = pers_number.Text;
            String positionField = comboBox1.SelectedItem.ToString();
            String depField = comboBox2.SelectedItem.ToString();


            if (!database.checkExistRecord("worker", "pers_number", pers_num))
            {

                String queryString = $"INSERT INTO worker ( pers_number, id_position,id_dept,firstName,surName,pantrimyc,phone,address,email,birthday) SELECT {pers_num},   (SELECT id_position FROM positionList WHERE name = '{positionField}'),  (SELECT id_dept FROM deportment WHERE name = '{depField}'), '{firstName.Text}' , '{surName.Text}', '{pantrimyc.Text}',  '{phone.Text}',   '{address.Text}',  '{email.Text}',  '{birthday.Text})';";
                database.sendQueryWithoutResponse(queryString);
            }
            else MessageBox.Show("Ошибка. Запись с таким уникальный ключом уже существует", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            record.RefreshRecordsWithJoin(dataGridView1, "worker", RowTypes, new[]
            {
               "worker.pers_number",
               "worker.firstName",
               "worker.surName",
               "worker.pantrimyc",
               "deportment.name",
               "positionList.name",
               "worker.phone",
               "worker.address",
               "worker.email",
               "worker.birthday"
            }, "INNER JOIN positionList ON worker.id_position = positionList.id_position\r\nINNER JOIN deportment ON worker.id_dept= deportment.id_dept;");

        }
    }
    }

