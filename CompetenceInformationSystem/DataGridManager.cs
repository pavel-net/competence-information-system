using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace CompetenceInformationSystem
{
    class DataGridManager
    {
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;
        DataSet dataSet = new DataSet();
        SQLiteCommandBuilder comandBuilder;
        DataGridView dataGridView;
        string NameTable;

        public DataGridManager(DataGridView dataGridView, string NameTable)
        {
            this.NameTable = NameTable;
            this.dataGridView = dataGridView;
        }

        public void Close()
        {
            ClearDataGrid();
        }

        public void ClearDataGrid()
        {
            if (connection == null)
                return;
            connection.Close();
            dataSet.Clear();
            adapter.Dispose();
            dataGridView.Refresh();
        }
        /// <summary>
        /// Открывает соединение и загружает данные в дата грид. ВАЖНО - команда должна быть без соединения.
        /// </summary>
        /// <param name="command"></param>
        public void LoadData(SQLiteCommand command)
        {
            ClearDataGrid();
            connection = SQLiteManager.CreateConnection();
            command.Connection = connection;
            adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dataSet, NameTable);
            comandBuilder = new SQLiteCommandBuilder(adapter);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dataSet.Tables[0];
            dataGridView.DataSource = bSource;
        }

        public void InitialCommandUpdate(SQLiteCommand command)
        {
            adapter.UpdateCommand = command;
        }

        public void InitialCommandInsert(SQLiteCommand command)
        {
            adapter.InsertCommand = command;
        }

        public void InitialCommandDelete(SQLiteCommand command)
        {
            adapter.DeleteCommand = command;
        }

        public bool SaveDataGrid()
        {
            try
            {
                if (connection == null)
                    return true;
                dataGridView.CurrentCell = null;
                comandBuilder.RefreshSchema();
                dataGridView.EndEdit();
                if (adapter.InsertCommand == null)
                    adapter.InsertCommand = new SQLiteCommand(" ");
                if (adapter.UpdateCommand == null)
                    adapter.UpdateCommand = comandBuilder.GetUpdateCommand();
                if (adapter.DeleteCommand == null)
                    adapter.DeleteCommand = comandBuilder.GetDeleteCommand();
                adapter.Update(dataSet.Tables[NameTable]);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в процессе сохранения данных.\n" + e.Message, "Ошибка");
                return false;
            }
        }
    }
}
