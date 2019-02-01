using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace FindAndRenameOrCopy
{
    public static class DBActions
    {
        private static OleDbConnection connection;
        private static OleDbCommand command;
        static DBActions()
        {
            string DBname = "Database.mdb";
            if (!System.IO.File.Exists(DBname))
            {
                throw new Exception($"File {DBname} not found.");
            }
            connection = new OleDbConnection
            {
                //ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DBname}"
                ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={DBname}"
            };
            command = new OleDbCommand
            {
                Connection = connection
            };
        }

        public static List<ITable> Get<T>() where T : ITable, new()
        {
            string tableName = GetTableName<T>();

            List<ITable> result = new List<ITable>();
            connection.Open();
            command.CommandText = $"SELECT * FROM [{tableName}]";
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ITable table = new T();
                string[] mass = new string[dataReader.FieldCount];
                for (int i = 0; i < dataReader.FieldCount; i++)
                    mass[i] = dataReader[i].ToString();

                table.SetProperties(mass);
                result.Add(table);
            }
            dataReader.Close();
            connection.Close();
            return result;
        }

        public static void Update<T>(List<ITable> Items) where T : ITable, new()
        {
            connection.Open();
            for (int i = 0; i < Items.Count; i++)
            {
                command.CommandText = $"UPDATE [{GetTableName<T>()}] SET [Признак_копирования] = {Items[i].CopyFeature} WHERE [ID] = {Items[i].ID}";
                command.ExecuteScalar();
            }            
            connection.Close();
        }        

        private static string GetTableName<T>() where T : ITable, new()
        {
            string tableName = "";
            if (typeof(T).IsAssignableFrom(typeof(FindAndRemove)))
            {
                tableName = "FindAndRename";
            }
            if (typeof(T).IsAssignableFrom(typeof(FindAndCopy)))
            {
                tableName = "FindAndCopy";
            }           
            return tableName;
        }
    }
}
