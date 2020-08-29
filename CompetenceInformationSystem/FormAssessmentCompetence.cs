using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;

namespace CompetenceInformationSystem
{
    public partial class FormAssessmentCompetence : Form
    {
        DataGridManager ManagerDataCompetence;
        long id_specialization;
        string kod_specialty;
        // массив, в котором хранятся ID слушателей с индексами, совпадающими с dataGridViewCompetence.Rows
        long[] studentID;
        string[] studentFIO;
        // массив, в котором хранятся ID компетенций с индексами, совпадающими с dataGridViewCompetence.Columns + 2,
        // так как первый столбец ФИО, второй столбец - среднее значение освоенности компетенций
        long[] competenceID;

        public FormAssessmentCompetence(long id_specialization, string nameSpecialization, string nameGroup, long[] studentID, string[] studentFIO)
        {
            this.id_specialization = id_specialization;
            this.studentID = studentID;
            this.studentFIO = studentFIO;
            GetSpecialtyKod();
            InitializeComponent();
            this.labelSpec.Text = nameSpecialization;
            this.Text = "Оценка компетенций для группы " + nameGroup;
            ManagerDataCompetence = new DataGridManager(dataGridViewCompetence, "Competence");
        }

        private void GetSpecialtyKod()
        {
            kod_specialty = SQLiteManager.GetValueFromDB("SPECIALIZATION", "SPECIALTY_FK", "ID", id_specialization); 
        }

        // загружает компетенции для специализации
        private void LoadCompetence()
        {
            string sqlQuery = "SELECT * FROM COMPETENCE WHERE ID_specialty = @id_specialty AND (ID_specialization IS NULL OR ID_specialization = @id_specialization) ORDER BY ID";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_specialty", kod_specialty);
            command.Parameters.AddWithValue("@id_specialization", id_specialization);
            ManagerDataCompetence.LoadData(command);
            dataGridViewCompetence.Columns["ID"].Visible = false;
            dataGridViewCompetence.Columns["id_specialization"].Visible = false;
            dataGridViewCompetence.Columns["id_specialty"].Visible = false;
            dataGridViewCompetence.Columns["Name"].HeaderText = "Содержание компетенции";
            dataGridViewCompetence.Columns["Name"].Width = 600;
            dataGridViewCompetence.Columns["Name"].DisplayIndex = 2;
            dataGridViewCompetence.Columns["KOD"].HeaderText = "Код";
            dataGridViewCompetence.Columns["KOD"].DisplayIndex = 1;
        }

        /// <summary>
        /// Инициализирует данные в DataGridAssessment
        /// </summary>
        /// <param name="studentFIO"></param>
        private void InitialDataGridAssessment(string[] studentFIO)
        {
            if (dataGridViewCompetence.Rows.Count == 0)
                return;
            InitialColumnInDataGridAssessment();
            if (studentFIO == null || studentFIO.Length == 0)
                return;
            dataGridViewAssessment.Rows.Add(studentFIO.Length);
            for (int i = 0; i < studentFIO.Length; i++)
                dataGridViewAssessment.Rows[i].Cells[0].Value = studentFIO[i];
            InitialRowsDataGridAssessment();
            UpdateValueAssessmentInDataGrid();
        }
        // добавляет столбцы в DataGridAssessment в соответствии с данными, загруженными в dataGridViewCompetence
        private void InitialColumnInDataGridAssessment()
        {
            competenceID = new long[dataGridViewCompetence.Rows.Count];
            dataGridViewAssessment.Columns.Add("FIO", "Ф.И.О.");
            dataGridViewAssessment.Columns.Add("MEAN", "Среднее");
            for (int i = 0; i < dataGridViewCompetence.Rows.Count; i++)
            {
                competenceID[i] = Convert.ToInt64(dataGridViewCompetence.Rows[i].Cells["ID"].Value);
                string name = dataGridViewCompetence.Rows[i].Cells["KOD"].Value.ToString();
                dataGridViewAssessment.Columns.Add(name, name);
            }
            dataGridViewAssessment.Columns[0].Width = 200;
            for (int i = 1; i < dataGridViewAssessment.Columns.Count; i++)
                dataGridViewAssessment.Columns[i].Width = 70;
        }

        private void InitialRowsDataGridAssessment()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sql = "SELECT ID_competence, Assessment FROM Assessment_Competence WHERE ID_student = @id_stud";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
            for (int i = 0; i < dataGridViewAssessment.Rows.Count; i++)
            {
                command.Parameters[0].Value = studentID[i];
                dataGridViewAssessment.Rows[i].Tag = studentID[i];
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int index_column = GetIndexColumnForIdCompetence(Convert.ToInt64(reader[0]));
                    if (index_column == -1)
                        continue;
                    dataGridViewAssessment[index_column, i].Value = Convert.ToDouble(reader[1]);
                }
                reader.Close();
            }
            connection.Close();
        }
        /// <summary>
        /// Обновляет значения в ячейках таблицы оценок компетенций
        /// </summary>
        private void UpdateValueAssessmentInDataGrid()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlInsert = "INSERT INTO Assessment_Competence(ID_student, ID_competence) VALUES ";
            //SQLiteCommand command = new SQLiteCommand("INSERT INTO Assessment_Competence(ID_student, ID_competence) VALUES(@id_stud, @id_comp)", connection);
            //command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
            //command.Parameters.Add(new SQLiteParameter("@id_comp", DbType.Int64));
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            for (int i = 0; i < dataGridViewAssessment.Rows.Count; i++)
            {
                double mean_value = 0;
                double count_notNull_value = 0;
                //command.Parameters[0].Value = Convert.ToInt64(dataGridViewAssessment.Rows[i].Tag);
                command.Parameters.Clear();
                sqlInsert = "INSERT INTO Assessment_Competence(ID_student, ID_competence) VALUES ";
                command.Parameters.Add(new SQLiteParameter("@id_stud", Convert.ToInt64(dataGridViewAssessment.Rows[i].Tag)));
                int current_param = 0;
                for (int j = 2; j < dataGridViewAssessment.Columns.Count; j++)
                {
                    if (dataGridViewAssessment[j, i].Tag == null)
                        dataGridViewAssessment[j, i].Tag = false;
                    if (dataGridViewAssessment[j, i].Value == null)
                    {   // значит в базе нет записи слушатель_компетенция, создадим её
                        dataGridViewAssessment[j, i].Value = 0;
                        string param_name = "@param" + (++current_param).ToString();
                        command.Parameters.Add(new SQLiteParameter(param_name, competenceID[j - 2]));
                        sqlInsert += "(@id_stud, " + param_name + "),"; 
                        //command.Parameters[1].Value = competenceID[j - 2];
                        //command.ExecuteNonQuery();
                    }
                    else if (Convert.ToDouble(dataGridViewAssessment[j, i].Value) != 0)
                    {
                        mean_value += Convert.ToDouble(dataGridViewAssessment[j, i].Value);
                        count_notNull_value += 1.0d;
                    }
                }
                if (current_param != 0)
                {
                    sqlInsert = sqlInsert.Remove(sqlInsert.Length - 1);
                    command.CommandText = sqlInsert;
                    command.ExecuteNonQuery();
                }
                if (count_notNull_value == 0)
                    dataGridViewAssessment[1, i].Value = 0;
                else
                {
                    dataGridViewAssessment[1, i].Value = string.Format("{0:N2}", mean_value / count_notNull_value); 
                }
            }
            connection.Close();
        }

        // возвращает индекс столбца таблицы DataGridAssessment, который соответствует компетенции с ID = id_competence
        private int GetIndexColumnForIdCompetence(long id_competence)
        {
            for (int i = 0; i < competenceID.Length; i++)
            {
                if (competenceID[i] == id_competence)
                    return (i + 2);
            }
            return -1;
        }

        /// <summary>
        /// Осуществляет вычисление оценки освоенности выделенных компетенций 
        /// </summary>
        private void CalculateAssessmentSelectedCompetence(int[] index_id_competence)
        {
            for (int i = 0; i < index_id_competence.Length; i++)
                CalculateAssessmentCompetence(index_id_competence[i]);
            UpdateValueAssessmentInDataGrid();
            MessageBox.Show("Оценка произведена", "Уведомление");
        }

        /// <summary>
        /// Вычисляет оценку одной компетенции для всех студентов
        /// </summary>
        private void CalculateAssessmentCompetence(int index_competence)
        {
            int index_column = index_competence + 2;
            List<long> listID = new List<long>();
            List<double> listWeight = new List<double>();
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlSelectDiscipline = "SELECT ID_discipline, Weight FROM Competence_Discipline WHERE ID_competence = @id_comp";
            SQLiteCommand command = new SQLiteCommand(sqlSelectDiscipline, connection);
            command.Parameters.AddWithValue("@id_comp", competenceID[index_competence]);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listID.Add(Convert.ToInt64(reader[0]));
                listWeight.Add(Convert.ToDouble(reader[1]));
            }
            reader.Close();
            connection.Close();
            if (listID.Count == 0)
                return;
            // подсчитаем сумму весов, если она равна 0, то зададим значения весов по умолчанию
            CheckWeightCorrect(ref listWeight, ref listID, competenceID[index_competence]);
            if (listID.Count == 0)
                return;
            long[] id_discipline = listID.ToArray();
            double[] weight_discipline = listWeight.ToArray();
            // получили номера и веса значимых дисциплин в формировании компетенции, теперь для каждого слушателя вычислим взвешенную сумму
            connection.Open();
            command.CommandText = "SELECT Assessment, Semester FROM Assessment_Discipline WHERE ID_discipline = @id_disp AND ID_student = @id_stud";
            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@id_disp", DbType.Int64));
            command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
            // проходим по всем слушателям и высчитываем взвешенную сумму, записываем её в таблицу
            for (int i = 0; i < dataGridViewAssessment.Rows.Count; i++)
            {
                //command.Parameters[1].Value = studentID[i];
                command.Parameters[1].Value = Convert.ToInt64(dataGridViewAssessment.Rows[i].Tag);
                double[] asssessmentValue = new double[id_discipline.Length];
                for (int j = 0; j < id_discipline.Length; j++)
                {
                    command.Parameters[0].Value = id_discipline[j];
                    int semester = -1;
                    SQLiteDataReader reader2 = command.ExecuteReader();
                    while (reader2.Read())
                    {
                        int temp = Convert.ToInt32(reader2[1]);
                        if (temp > semester)
                        {
                            semester = temp;
                            asssessmentValue[j] = Convert.ToDouble(reader2[0]);
                        }
                    }
                    reader2.Close();
                    if (semester == -1)
                        asssessmentValue[j] = 0;
                }
                // считали оценки по всем дисциплинам, теперь вычислим взвешенную сумму и запишем её в дата грид
                double weigSum = CalculateWeightedSum(weight_discipline, asssessmentValue);
                dataGridViewAssessment[index_column, i].Value = string.Format("{0:N2}", weigSum);
                dataGridViewAssessment[index_column, i].Tag = true;
            }
            connection.Close();
        }

        private double CalculateWeightedSum(double[] weight_discipline, double[] asssessmentValue)
        {
            double result = 0;
            for (int i = 0; i < weight_discipline.Length; i++)
                result += weight_discipline[i] * asssessmentValue[i];
            return result;
        }

        // Принимаем на вход значения айди и весов дисциплин в формировании компетенции и нормирует их, если это необходимо.
        // Вовзрашает обратно лист значений и айди с ЗНАЧИМЫМИ дисциплинами.
        private void CheckWeightCorrect(ref List<double> listWeight, ref List<long> listID, long id_competence)
        {
            double sum = 0;
            for (int i = 0; i < listWeight.Count; i++)
                sum += listWeight[i];
            if (sum == 0)
            {   // если сумма 0, значит нужно задать равные веса
                for (int k = 0; k < listWeight.Count; k++)
                    listWeight[k] = 1.0 / listWeight.Count;
                // Сохраним эти значения в БД
                SQLiteConnection connection = SQLiteManager.CreateConnection();
                string sqlSelectDiscipline = "UPDATE Competence_Discipline SET Weight = @w WHERE ID_competence = @id_comp AND ID_discipline = @id_disp";
                SQLiteCommand command = new SQLiteCommand(sqlSelectDiscipline, connection);
                command.Parameters.AddWithValue("@w", listWeight[0]);
                command.Parameters.AddWithValue("@id_comp", id_competence);
                command.Parameters.Add(new SQLiteParameter("@id_disp", DbType.Int64));
                for (int i = 0; i < listID.Count; i++)
                {
                    command.Parameters[2].Value = listID[i];
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            else
            {   // иначе просто удалим из списков дисциплины с нулевым значением веса
                for (int i = listWeight.Count - 1; i >= 0; i--)
                {
                    if (listWeight[i] == 0)
                    {
                        listWeight.RemoveAt(i);
                        listID.RemoveAt(i);
                    }
                }
            }
        }

        private void FormAssessmentCompetence_Load(object sender, EventArgs e)
        {
            LoadCompetence();
            InitialDataGridAssessment(studentFIO);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewCompetence.Rows.Count; i++)
                dataGridViewCompetence.Rows[i].Cells[0].Value = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewCompetence.Rows.Count; i++)
                dataGridViewCompetence.Rows[i].Cells[0].Value = false;
        }

        private void buttonStartAssessment_Click(object sender, EventArgs e)
        {
            List<int> listChoosenCompIndex = new List<int>();
            for (int i = 0; i < dataGridViewCompetence.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridViewCompetence.Rows[i].Cells[0].Value))
                    listChoosenCompIndex.Add(i);
            }
            if (listChoosenCompIndex.Count == 0)
            {
                MessageBox.Show("Сначала выберите компетенции для оценивания.", "Уведомление");
                return;
            }
            int[] index = listChoosenCompIndex.ToArray();
            CalculateAssessmentSelectedCompetence(index);
        }

        private void dataGridViewAssessment_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewAssessment.CurrentCell == null)
                return;
            int row = dataGridViewAssessment.CurrentCell.RowIndex;
            int col = dataGridViewAssessment.CurrentCell.ColumnIndex;
            if (dataGridViewAssessment[0, row].Value == null)
                return;
            richTextBoxState.Text = "Слушатель " + dataGridViewAssessment[0, row].Value.ToString() + "\n";
            if (col == 0)
                return;
            if (col == 1)
            {
                richTextBoxState.AppendText("Средняя усвоенность всех компетенций " + dataGridViewAssessment[col, row].Value.ToString());
                return;
            }
            richTextBoxState.AppendText("Компетенция " + dataGridViewAssessment.Columns[col].HeaderText + " " + dataGridViewCompetence[2, col - 2].Value.ToString() + "\n");
            richTextBoxState.AppendText("Оценка " + dataGridViewAssessment[col, row].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAssessmentCompetence_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManagerDataCompetence.Close();
        }

        private void dataGridViewCompetence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            bool result = Convert.ToBoolean(dataGridViewCompetence.Rows[e.RowIndex].Cells[0].Value);
            dataGridViewCompetence.Rows[e.RowIndex].Cells[0].Value = !result;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            SQLiteCommand command = new SQLiteCommand("UPDATE Assessment_Competence SET Assessment = @ass WHERE ID_student = @id_stud AND ID_competence = @id_comp", connection);
            command.Parameters.Add(new SQLiteParameter("@ass", DbType.Double));
            command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
            command.Parameters.Add(new SQLiteParameter("@id_comp", DbType.Int64));
            for (int i = 2; i < dataGridViewAssessment.Columns.Count; i++)
            {
                command.Parameters[2].Value = competenceID[i - 2];
                for (int j = 0; j < dataGridViewAssessment.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridViewAssessment[i, j].Tag))
                    {   // стоит флаг изменений, значит сохраняем в базу и снимает флаг
                        dataGridViewAssessment[i, j].Tag = false;
                        command.Parameters[0].Value = dataGridViewAssessment[i, j].Value;
                        command.Parameters[1].Value = Convert.ToInt64(dataGridViewAssessment.Rows[j].Tag);
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Данные успешно сохранены.", "Уведомление");
        }
    }
}
