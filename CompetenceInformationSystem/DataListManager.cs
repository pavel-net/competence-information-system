using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CompetenceInformationSystem
{
    /// <summary>
    /// Содержит слепок данных из БД для одной таблицы.
    /// </summary>
    class DataListManager
    {
        string NameTable;
        string[] columns;
        DataTable table;

        public DataListManager(string NameTable, string[] columns)
        {
            this.NameTable = NameTable;
            this.columns = columns;
            table = new DataTable(NameTable);
            for (int i = 0; i < columns.Length; i++)
                table.Columns.Add(columns[i]);
        }

        /// <summary>
        /// Загружает данные для команды. Команда должна быть без подключения.Данные, возвращаемые
        /// командой, должны содержать столбцы, определённые при создании объекта.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>true - если данные загружены успешно, иначе false</returns>
        public bool LoadData(SQLiteCommand command)
        {           
            try
            {
                table.Rows.Clear();
                SQLiteConnection connection = SQLiteManager.CreateConnection();
                command.Connection = connection;
                SQLiteDataReader reader = command.ExecuteReader();
                int countColumn = table.Columns.Count;
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < countColumn; i++)
                        row[columns[i]] = reader[columns[i]].ToString();
                    table.Rows.Add(row);
                }
                reader.Close();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetIndex(string columnName, string value)
        {
            int index = 0;
            foreach (DataRow row in table.Rows)
            {
                string temp = row[columnName].ToString();
                if (temp.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1)
                    return index;
                index++;
            }
            return -1;
        }

        public void GetDataInComboBox(System.Windows.Forms.ComboBox comboBox, string columnName)
        {
            comboBox.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                comboBox.Items.Add(row[columnName]);
            }
        }

        public string GetCellValue(int index_row, string columnName)
        {
            DataRow row = table.Rows[index_row];
            return row[columnName].ToString();
        }
    }
}
