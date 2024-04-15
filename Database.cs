using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static Mysqlx.Expect.Open.Types;

namespace Kursovaya
{

    class Database
    {
        static string ConnectionString = @"server=10.0.2.20;port=3306;user=root;password=P@ssw0rd;database=InventoryControl";
        MySqlConnection connection = new MySqlConnection(ConnectionString);

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        { 
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool checkExistRecord(String Table, String field, String content){

            String queryString = $"SELECT * FROM {Table} WHERE {field}={content}";
      
            MySqlDataReader reader = sendQueryWithResponse(queryString);

            return reader.HasRows;
        }

        public MySqlDataReader sendQueryWithResponse(String queryString)
        {
            Database database = new Database();
            database.openConnection();
            MySqlCommand command = new MySqlCommand(queryString, database.GetConnection());
            return command.ExecuteReader();
        }

        public void sendQueryWithoutResponse(String queryString)
        {
            Database database = new Database();
            database.openConnection();
            MySqlCommand command = new MySqlCommand(queryString, database.GetConnection());
            command.ExecuteNonQuery();
        }

        public void updateRecord(String table, String [] fields, String [] values, String PrimaryKeyField = null, String PrimaryKeyValue = null)
        {
            Database database = new Database();
            String updateQuery = $"UPDATE {table} SET";
            String condition;

            if (fields.Length == values.Length)
            {
                if ((PrimaryKeyField == null) && (PrimaryKeyValue == null))
                {
                    PrimaryKeyField = fields[0];
                    PrimaryKeyValue = values[0];
                    condition = $"{PrimaryKeyField}='{PrimaryKeyValue}'";
                }
                else
                {
                    condition = $"{PrimaryKeyField}='{PrimaryKeyValue}'";
                }
                
                //updateQuery = $"UPDATE {table} SET {fields[0]}={contents[0]} WHERE ";

                    for (int i = 1; i < fields.Length; i++)
                    {
                        if (i == fields.Length - 1)
                    {
                            updateQuery += $" {fields[i]}='{values[i]}' WHERE {condition};";
                        }
                        else
                        {
                            updateQuery += $" {fields[i]}='{values[i]}',";
                        }
                    }


                database.sendQueryWithoutResponse(updateQuery);
            }


        } 

        public MySqlDataReader getAllUniqueValues(String table, String field)
        {

            String queryString = $"SELECT DISTINCT {field} FROM {table}";

            MySqlDataReader reader = sendQueryWithResponse(queryString);

            return reader;

        }










    }
}
