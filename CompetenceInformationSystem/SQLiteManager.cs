using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace CompetenceInformationSystem
{
    class SQLiteManager
    {
        static string path = @"CompetenceDB.db";
        static string ConnectionString = "Data Source=" + path + ";Version=3;";

        static public SQLiteConnection CreateConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection);
            command.ExecuteNonQuery();
            return connection;
        }

        /// <summary>
        /// Осуществляет запись в базу нового значения и возвращает номер последнего rowid (если его нет
        /// возвращает 0). В случае ошибки возвращает -1.
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="columns"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        static public int InsertValue(string Table, string[] columns, object[] paramValues)
        {
            if (String.IsNullOrEmpty(Table) || columns == null || paramValues == null)
                return -1;
            string sqlInsert = "INSERT INTO " + Table + "(";
            for (int i = 0; i < columns.Length; i++)
                sqlInsert += columns[i] + ",";
            sqlInsert = sqlInsert.Remove(sqlInsert.Length - 1);
            sqlInsert += ") VALUES(";
            for (int i = 0; i < paramValues.Length; i++)
                sqlInsert += "@param" + i.ToString() + ",";
            sqlInsert = sqlInsert.Remove(sqlInsert.Length - 1);
            sqlInsert += ")";
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlInsert);
            for (int i = 0; i < paramValues.Length; i++)
                command.Parameters.AddWithValue("@param" + i.ToString(), paramValues[i]);
            command.Connection = connection;
            command.ExecuteNonQuery();
            int rowid = GetLastRowidValue(command);
            connection.Close();
            return rowid;
        }

        /// <summary>
        /// Проверяет, существует ли в базе в таблице Table столбец column со значением paramValue
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="column"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        static public bool IsExistValue(string Table, string column, string paramValue)
        {
            string sqlExist = "SELECT EXISTS(SELECT * FROM " + Table + " WHERE " + column + "= @param)";
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlExist);
            command.Parameters.AddWithValue("@param", paramValue);
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();         
            if (!reader.Read())
            {
                reader.Close();
                connection.Close();
                return false;
            }
            string temp = reader[0].ToString();
            reader.Close();
            connection.Close();
            if (temp == "1")
                return true;
            return false;
        }

        static public bool IsExistValue(string Table, string[] column, string[] paramValue)
        {
            string sqlExist = "SELECT EXISTS(SELECT * FROM " + Table + " WHERE ";
            for (int i = 0; i < column.Length; i++)
                sqlExist += column[i] + " = @param" + i.ToString() + " AND "; 
            sqlExist = sqlExist.Remove(sqlExist.Length - 4);
            sqlExist += ")";
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlExist);
            for (int i = 0; i < paramValue.Length; i++)
                command.Parameters.AddWithValue("@param" + i, paramValue[i]);
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                connection.Close();
                return false;
            }
            string temp = reader[0].ToString();
            reader.Close();
            connection.Close();
            if (temp == "1")
                return true;
            return false;
        }

        /// <summary>
        /// Осуществляет обновление данных для таблицы Table, обновляются столбцы columns, присваиваются значения
        /// paramValues при условии что столбцы whereColumn принимают значения whereValue
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="columns"></param>
        /// <param name="paramValues"></param>
        /// <param name="whereColumn"></param>
        /// <param name="whereValue"></param>
        /// <returns></returns>
        static public bool UpdateValue(string Table, string[] columns, string[] paramValues, string whereColumn, string whereValue)
        {
            if (String.IsNullOrEmpty(Table) || columns == null || paramValues == null)
                return false;
            string sqlInsert = "UPDATE " + Table + " SET ";
            for (int i = 0; i < columns.Length; i++)
            {
                sqlInsert += columns[i] + "=" + "@param" + i.ToString() + ",";
            }
            sqlInsert = sqlInsert.Remove(sqlInsert.Length - 1);
            sqlInsert += " WHERE " + whereColumn + "=" + whereValue;
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlInsert);
            for (int i = 0; i < paramValues.Length; i++)
                command.Parameters.AddWithValue("@param" + i.ToString(), paramValues[i]);
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        static public int GetLastRowidValue(SQLiteCommand command)
        {
            if (command.Connection == null)
                return 0;           
            string sqlSelect = "select last_insert_rowid()";
            command.CommandText = sqlSelect;
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return 0;
            }
            return Convert.ToInt32(reader[0]);
        }

        static public string GetValueFromDB(string Table, string columnReturn, string columnWhere, object valueWhere)
        {
            string sqlExist = "SELECT " + columnReturn + " FROM " + Table + " WHERE " + columnWhere + "= @param";
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlExist);
            command.Parameters.AddWithValue("@param", valueWhere);
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                connection.Close();
                return "";
            }
            string temp = reader[0].ToString();
            reader.Close();
            connection.Close();
            return temp;
        }

        static public string GetValueFromDB(string Table, string columnReturn, string[] columnWhere, object[] valueWhere)
        {
            string sqlExist = "SELECT " + columnReturn + " FROM " + Table + " WHERE ";           
            SQLiteConnection connection = CreateConnection();
            for (int i = 0; i < columnWhere.Length; i++)
                sqlExist += columnWhere[i] + "= @param" + i + " AND ";
            sqlExist = sqlExist.Remove(sqlExist.Length - 4);
            SQLiteCommand command = new SQLiteCommand(sqlExist);
            for (int i = 0; i < columnWhere.Length; i++)
                command.Parameters.AddWithValue("@param" + i, valueWhere[i]);
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                connection.Close();
                return "";
            }
            string temp = reader[0].ToString();
            reader.Close();
            connection.Close();
            return temp;
        }
    }
}
