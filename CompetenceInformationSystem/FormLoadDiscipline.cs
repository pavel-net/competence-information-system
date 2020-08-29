using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CompetenceInformationSystem
{
    public partial class FormLoadDiscipline : Form
    {
        DataListManager managerSpecialty;
        DataListManager managerSpecialization;
        FormStart parentForm;

        public FormLoadDiscipline(FormStart parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();           
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLoadDiscipline_Load(object sender, EventArgs e)
        {
            managerSpecialty = new DataListManager("SPECIALTY", new string[] {"KOD", "NAME"});
            managerSpecialization = new DataListManager("SPECIALIZATION", new string[] { "ID", "NUMBER", "NAME" });
            InitialComboBoxSpecialty();
        }

        private void FormLoadDiscipline_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_file = new OpenFileDialog();
            Open_file.InitialDirectory = "C:\\";
            Open_file.Filter = "Excel files |*.xlsx; *.xls";
            Open_file.RestoreDirectory = true;
            if (Open_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataGridViewWorkPlan.Rows.Clear();
                dataGridViewWorkPlan.DataSource = null;
                bool result = LoadDiscipline(Open_file.FileName);
                if (result)
                {
                    dataGridViewWorkPlan.Columns[0].HeaderText = "Название дисциплины";
                    dataGridViewWorkPlan.Columns[0].Width = 400;
                    dataGridViewWorkPlan.Columns[1].HeaderText = "Семестры отчётности";
                    dataGridViewWorkPlan.Columns[1].Width = 100;
                    dataGridViewWorkPlan.Columns[2].HeaderText = "Форма отчётности";
                    dataGridViewWorkPlan.Columns[2].Width = 100;
                    labelFILE.Text = Open_file.FileName;
                    UpdateState();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка в ходе загрузки", "Ошибка");
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkPlan.Rows.Count == 0)
                return;
            bool flag = ValidateStateWorkPlan();
            if (!flag)
            {
                MessageBox.Show("Данные не будут сохранены, пока вы не исправите все ошибки.", "Уведомление");
                return;
            }
            if (!SaveData())
            {
                MessageBox.Show("Данные не сохранены в базе. Проверьте соединение с БД.", "Уведомление");
                return;
            }
            MessageBox.Show("Данные успешно сохранены.", "Уведомление");
            Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string value = dataGridViewWorkPlan[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (String.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("Ячейка не может быть пустой!", "Ошибка редактирования");
                    dataGridViewWorkPlan.CancelEdit();
                    return;
                }
                if (e.ColumnIndex == 1)
                {   // семестры отчётности
                    bool flagError = false;
                    if (value[0] == ';')
                        flagError = true;
                    for (int i = 1; i < value.Length; i++)
                    {
                        if (value[i] == value[i - 1])
                        {
                            flagError = true;
                            break;
                        }
                    }
                    string[] semester = value.Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries);
                    if (semester == null || semester.Length == 0)
                        flagError = true;
                    else
                    {
                        foreach (string sem in semester)
                        {
                            int temp = Convert.ToInt32(sem);
                            if (temp < 1 || temp > 10)
                            {
                                flagError = true;
                                break;
                            }
                        }
                    }
                    if (flagError)
                    {
                        MessageBox.Show("Данная ячейка должна содержать перечисление(с разделителем \';\') семестров отчётности по дисциплине.\nНапример: 1;2;3",
                            "Ошибка редактирования");
                        dataGridViewWorkPlan.CancelEdit();
                    }
                }
                else if (e.ColumnIndex == 2)
                {   // форма отчётности
                    bool flagError = false;
                    if (value[0] == ';')
                        flagError = true;
                    foreach (char c in value)
                    {
                        if (c != ';' && c != 'з' && c != 'З' && c != 'э' && c != 'Э')
                        {
                            flagError = true;
                            break;
                        }
                    }
                    for (int i = 1; i < value.Length; i++)
                    {
                        if (value[i] == value[i - 1])
                        {
                            flagError = true;
                            break;
                        }
                    }
                    if (flagError)
                    {
                        MessageBox.Show("Данная ячейка должна содержать перечисление(с разделителем \';\') формы отчётности по семестрам дисциплины.\nНапример: Э;З;Э",
                            "Ошибка редактирования");
                        dataGridViewWorkPlan.CancelEdit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат", "Ошибка редактирования");
                dataGridViewWorkPlan.CancelEdit();
            }
        }

        private void comboBoxSpecialty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxSpecialty.SelectedIndex == -1)
            {
                buttonLoad.Enabled = false;
                comboBoxSpecialization.Items.Clear();
                return;
            }
            int index = comboBoxSpecialty.SelectedIndex;
            string kod_specialty = managerSpecialty.GetCellValue(index, "KOD");
            InitialComboBoxSpecialization(kod_specialty);
        }

        private void comboBoxSpecialization_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxSpecialization.SelectedIndex == -1)
            {
                buttonLoad.Enabled = false;
                return;
            }
            buttonLoad.Enabled = true;
        }

        void InitialComboBoxSpecialty()
        {
            string sqlQuery = "SELECT * FROM SPECIALTY ORDER BY NAME";
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(sqlQuery);
            if (!managerSpecialty.LoadData(command))
            {
                MessageBox.Show("Не удалось загрузить данные из БД. Проверьте подключение к БД.", "Ошибка");
                Close();
            }
            managerSpecialty.GetDataInComboBox(comboBoxSpecialty, "NAME");
        }

        void InitialComboBoxSpecialization(string kod)
        {
            if (comboBoxSpecialization.SelectedItem != null)
                comboBoxSpecialization.SelectedItem = null;
            comboBoxSpecialization.Items.Clear();
            string sqlQuery = "SELECT * FROM SPECIALIZATION WHERE SPECIALTY_fk = @kod ORDER BY NAME";
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@kod", kod);
            if (!managerSpecialization.LoadData(command))
            {
                MessageBox.Show("Не удалось загрузить данные из БД. Проверьте подключение к БД.", "Ошибка");
                Close();
            }
            managerSpecialization.GetDataInComboBox(comboBoxSpecialization, "NAME");
        }

        /// <summary>
        /// Загружает список дисциплин из файла. Добавляет данные в дата грид. Столбец 1 - название.
        /// Столбец 2 - семестры отчётности. Столбец 3 - форма отчётности по семестрам.
        /// </summary>
        /// <returns></returns>
        bool LoadDiscipline(string fileName)
        {
            ReaderDiscipline reader = new ReaderDiscipline(fileName);
            DataTable tableDiscipline = reader.Read();
            if (tableDiscipline.Rows.Count == 0)
                return false;
            dataGridViewWorkPlan.DataSource = tableDiscipline;
            return true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkPlan.SelectedCells.Count == 0 || dataGridViewWorkPlan.SelectedCells[0] == null)
                return;
            dataGridViewWorkPlan.Rows.RemoveAt(dataGridViewWorkPlan.SelectedCells[0].RowIndex);
        }

        private void UpdateState()
        {
            bool flag = false;
            for (int i = 0; i < dataGridViewWorkPlan.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewWorkPlan.Rows[i];
                bool IsRowExistInDB = SQLiteManager.IsExistValue("WorkProgramm", new string[] { "NameDiscipline", "ID_specialization" },
                    new string[] { row.Cells[0].Value.ToString(), managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID") });
                if (IsRowExistInDB)
                {
                    flag = true;
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            if (flag)
                MessageBox.Show("Среди загружаемых дисциплин найдены дисциплины, уже загруженые в базу. Они подсвечены жёлтым.", "Уведомление");
        }

        private bool ValidateStateWorkPlan()
        {
            for (int i = 0; i < dataGridViewWorkPlan.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewWorkPlan.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (String.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        MessageBox.Show("В строке " + (i+1) + "пустая ячейка!", "Ошибка");
                        return false;
                    }
                }
                bool IsRowExistInDB = SQLiteManager.IsExistValue("WorkProgramm", new string[] {"NameDiscipline", "ID_specialization" }, 
                    new string[] {row.Cells[0].Value.ToString(), managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID") });
                if (IsRowExistInDB)
                {
                    MessageBox.Show("Дисциплина " + row.Cells[0].Value.ToString() + " уже существует в базе!", "Ошибка");
                    return false;
                }
            }
            return true;
        }

        private bool SaveData()
        {
            try
            {
                string sqlInsert = "INSERT INTO WorkProgramm(NameDiscipline, ID_specialization, Semester, FormReport) VALUES (@name, @id_spec, @sem, @report)";
                SQLiteCommand command = new SQLiteCommand(sqlInsert);
                command.Parameters.Add("@name", DbType.String);
                command.Parameters.Add("@id_spec", DbType.Int64);
                command.Parameters["@id_spec"].Value = managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID");
                command.Parameters.Add("@sem", DbType.String);
                command.Parameters.Add("@report", DbType.String);
                SQLiteConnection connection = SQLiteManager.CreateConnection();
                command.Connection = connection;
                foreach (DataGridViewRow row in dataGridViewWorkPlan.Rows)
                {
                    command.Parameters[0].Value = row.Cells[0].Value;
                    command.Parameters[2].Value = row.Cells[1].Value;
                    command.Parameters[3].Value = row.Cells[2].Value;
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
                return false;
            }
        }

        //private void dataGridViewWorkPlan_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        if (dataGridViewWorkPlan.SelectedRows.Count == 0 || dataGridViewWorkPlan.SelectedRows[0] == null)
        //            return;
        //        for (int i = dataGridViewWorkPlan.SelectedRows.Count - 1; i >= 0; i--)
        //            dataGridViewWorkPlan.Rows.RemoveAt(dataGridViewWorkPlan.SelectedRows[i].Index);
        //        e.Handled = true;
        //    }
        //}
    }
}
