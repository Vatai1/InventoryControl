using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kursovaya
{

    enum RowState
    {
        Existed,
        Modified,
        ModifiedNew,
        Deleted
    }

    enum RowType
    {
        String,
        Int,
        Date
    }



    internal class Records
    {

        Database database = new Database();

        /// 
        /// 
        /// ReadSingleRow
        /// 
        /// 
        public void ReadSingleRow(DataGridView dgw, IDataRecord record, RowType []RowTypes)
        {
            
            List<String> rows = new List<String>();

            for (int i = 0; i < RowTypes.Length; i++)
            {
                if (RowTypes[i] == RowType.String)
                {
                    if (!record.IsDBNull(i))rows.Add(record.GetString(i));
                    else rows.Add(string.Empty);
                    continue; 

                }
                if (RowTypes[i] == RowType.Int)
                {
                    if (!record.IsDBNull(i)) rows.Add(record.GetInt32(i).ToString());
                    else rows.Add(string.Empty);
                    continue;
                }
                if (RowTypes[i] == RowType.Date)
                {
                    if(!record.IsDBNull(i)) rows.Add(record.GetDateTime(i).ToString());
                    else rows.Add(string.Empty);
                    continue;
                }
            }
            rows.Add(RowState.Existed.ToString());
            dgw.Rows.Add(rows.ToArray());
            

           //dgw.Rows.Add(RowState.ModifiedNew);

         }
        public void RefreshRecords(DataGridView dgw, String database_table, RowType []RowTypes)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM {database_table}";

//            MySqlDataReader reader = command.ExecuteReader();
              MySqlDataReader reader = database.sendQueryWithResponse(queryString);
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader, RowTypes);
            }

            reader.Close();
        }
        public void RefreshRecordsWithJoin(DataGridView dgw, String table, RowType[] RowTypes,String []fields, String condition)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT {string.Join(",", fields)} FROM {table} {condition}";

            //            MySqlDataReader reader = command.ExecuteReader();
            MySqlDataReader reader = database.sendQueryWithResponse(queryString);
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader, RowTypes);
            }

            reader.Close();
        }
        public void Search(DataGridView dgw, string database_table, TextBox textbox_search, String[] searching_filds, RowType []RowTypes)
        {
            dgw.Rows.Clear();


            var searchString = $"SELECT * FROM {database_table} WHERE concat ({string.Join(",",searching_filds)}) like '%" + textbox_search.Text + "%'";



            //MySqlDataReader read = command.ExecuteReader();
            MySqlDataReader read = database.sendQueryWithResponse(searchString);


            while (read.Read())
            {
                    ReadSingleRow(dgw, read, RowTypes);
            }
            read.Close();


        }
        public void deleteRow(DataGridView dgw, int rowStateIndex)
        {
            int index = dgw.CurrentCell.RowIndex;

            //dgw.Rows[index].Visible = false;

            if (dgw.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgw.Rows[index].Cells[rowStateIndex].Value = RowState.Deleted;
                return;
            }

            dgw.Rows[index].Cells[rowStateIndex].Value = RowState.Deleted;
        }
        public void FiilTextBoxsOnCellClick(DataGridView dgw, TextBox []text_boxes, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgw.Rows[selectedRow];
                int a = row.Cells.Count - 1;

                for (int i = 0; i < row.Cells.Count - 1; i++)
                {
                    text_boxes[i].Text = row.Cells[i].Value.ToString();
            
                }
            }
        }
        public void addRecord(String databaseTable, TextBox[] text_boxes, String PrimaryKey = null, bool hasPrimaryKey = true, String[] ForgeinKeys = null)
        {
            database.openConnection();

            String PrimaryKeyField = text_boxes[0].Name.ToString();
            List<String> fields = new List<String>();
            List<String> information = new List<String>();


            if (PrimaryKey == null && ForgeinKeys == null)
            {   
                PrimaryKey = text_boxes[0].Text.ToString();
            }

            if (ForgeinKeys != null)
            {
               
            }

                foreach (var i in text_boxes)
                {
                    fields.Add(i.Name.ToString());
                    information.Add(i.Text.ToString());
                }

                string beginPart = $"INSERT INTO {databaseTable} (";
                string endPart = $") values (";


                for (int i = 0; i < text_boxes.Length; i++)
                {

                    if (i == text_boxes.Length - 1)
                    {
                        beginPart += $"{fields[i]}";
                    }
                    else beginPart += $"{fields[i]},";

                    if (i == text_boxes.Length - 1)
                    {
                        endPart += $"'{information[i]}')";
                    }
                    else endPart += $"'{information[i]}',";
                }


                var addQuery = beginPart + endPart;

                database.sendQueryWithoutResponse(addQuery);
                
                //var command = new MySqlCommand(addQuery, database.GetConnection());
                //command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            database.closeConnection();
        }
        public void Update(Records records, DataGridView dgw, String table, String[] fields, String []deleteFields)
        {

            Database database = new Database();

            for (int index = 0; index < dgw.Rows.Count - 1; index++)
            {
                System.Enum.TryParse(dgw.Rows[index].Cells[dgw.Rows[index].Cells.Count - 1].Value.ToString(), out RowState rowState);
                
                if (rowState == RowState.Existed) 
                    continue;
                if (rowState == RowState.Modified)
                {
                    

                    List<String> values = new List<String>();

                    foreach (DataGridViewCell cell in dgw.Rows[index].Cells)
                    {
                        values.Add(cell.Value.ToString());
                    }
                    values.RemoveAt(values.Count - 1);
                    database.updateRecord(table, fields, values.ToArray());
                    continue;
                }
                if (rowState == RowState.Deleted)
                {
                    List <String> deleteKeys = new List<string>();
                    if (deleteFields.Length == 1)
                    {
                        deleteKeys.Add(dgw.Rows[index].Cells[0].Value.ToString());
                        records.deleteRecord(table, deleteFields, deleteKeys.ToArray());
                    }
                    else
                    {
                        records.deleteRecord(table, deleteFields, deleteKeys.ToArray());
                    }
                    }
            };
        }
        public void change(DataGridView dgw,TextBox []text_boxes)
        {
            var selectedRowIndex = dgw.CurrentCell.RowIndex;

            Dictionary<String, String> TextBoxValues = new Dictionary<String, String>();

            foreach(TextBox item in text_boxes)
            {
                TextBoxValues.Add(item.Name.ToString(), item.Text.ToString());
            }

            if (dgw.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dgw.Rows[selectedRowIndex].SetValues(TextBoxValues.Values.ToArray());
                dgw.Rows[selectedRowIndex].Cells[dgw.Rows[selectedRowIndex].Cells.Count - 1].Value = RowState.Modified;
            }

        }
        public void deleteRecord  (String Table, String[] fields, String[] keys)
        {
            Database database = new Database();
            database.openConnection();

            String deleteQuery = null;
            if (fields.Length == keys.Length)
            {
                if (fields.Length == 1)
                {
                    deleteQuery = $"DELETE FROM {Table} WHERE {fields[0]}={keys[0]}";
                }
                else
                {
                    deleteQuery = $"DELETE FROM {Table} WHERE ";

                    for (int i = 0; i < fields.Length; i++)
                    {

                        if (i == fields.Length - 1)
                        {
                            deleteQuery += $"{fields[i]}={keys[i]}";
                        }
                        else
                        {
                            deleteQuery += $"{fields[i]}={keys[i]} AND";
                        }
                    }
                }
            }
            else throw new Exception("Ошибка в запросе");


            //String deleteQuery = $"DELETE FROM {Table} WHERE {field}={content}";

            MySqlCommand command = new MySqlCommand(deleteQuery, database.GetConnection());
            command.ExecuteNonQuery();

        }
        public void setUniqueValusToComboBox(ComboBox comboBox, String table, String field)
        {
            MySqlDataReader reader = database.getAllUniqueValues(table, field);
            while (reader.Read())
            {

                comboBox.Items.Add(reader.GetValue(0));
            }
        }






















        /// 
        /// 
        /// CreateColumnsDeportment
        /// 
        /// 
        private void CreateColumnsDeportment(DataGridView dgw)
        {
            dgw.Columns.Add("id_dept", "Код подразделения");
            dgw.Columns.Add("name", "Название отдела");
            dgw.Columns.Add("surNameChief", "Фамилия начальника отдела");
            dgw.Columns.Add("firstNameChief", "Имя начальника отдела");
            dgw.Columns.Add("pantrimycChief", "Отчество начальника отдела");
            dgw.Columns.Add("isNew", String.Empty);

        }

       

    }
}
