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
    public partial class FormGroupAndStudent : Form
    {
        DataGridManager managerDataGroup;
        DataGridManager managerDataStudent;
        string currentNumGroup = "";
        long id_group_current = -1;
        long id_specialization_current = -1;

        public FormGroupAndStudent()
        {
            InitializeComponent();
            managerDataGroup = new DataGridManager(dataGridViewGroup, "StudyGroup");
            managerDataStudent = new DataGridManager(dataGridViewStudent, "Student");
        }

        private void dataGridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            FormAddGroup form = new FormAddGroup(this);
            form.ShowDialog();
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            DeleteRowInDataGrid(dataGridViewGroup, "Вы уверены что хотите удалить выбранную группу?");
            managerDataStudent.Close();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteRowInDataGrid(dataGridViewStudent, "Вы уверены что хотите удалить слушателя?");
        }

        private void buttonАssessmentStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudent.SelectedCells.Count == 0 || dataGridViewStudent.SelectedCells[0] == null)
                return;
            DataGridViewRow row = dataGridViewStudent.Rows[dataGridViewStudent.SelectedCells[0].RowIndex];
            FormAssessmentUser form = new FormAssessmentUser(row.Cells["FIO"].Value.ToString(), Convert.ToInt64(row.Cells["ID"].Value), currentNumGroup);
            form.ShowDialog();
        }

        // ....... ОТКРЫВАЕТ ФОРМУ ОЦЕНКИ ОСВОЕННОСТИ КОМПЕТЕНЦИЙ ...........
        private void buttonАssessmentGroup_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudent.Rows.Count == 0)
                return;
            string[] fio = new string[dataGridViewStudent.Rows.Count];
            long[] id = new long[dataGridViewStudent.Rows.Count];
            for (int i = 0; i < dataGridViewStudent.Rows.Count; i++)
            {
                fio[i] = dataGridViewStudent.Rows[i].Cells["FIO"].Value.ToString();
                id[i] = Convert.ToInt64(dataGridViewStudent.Rows[i].Cells["ID"].Value);
            }
            FormAssessmentCompetence form = new FormAssessmentCompetence(id_specialization_current, labelSpec.Text, labelGroup.Text, id, fio);
            form.ShowDialog();
        }
        // ........................................................................

        private void dataGridViewStudent_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridViewStudent[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (String.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("ФИО не может быть пустым.", "Ошибка редактирования");
                dataGridViewStudent.CancelEdit();
            }
        }

        private void FormGroupAndStudent_Load(object sender, EventArgs e)
        {
            LoadGroup();
        }

        private void FormGroupAndStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerDataStudent.Close();
            managerDataGroup.Close();
        }

        private void LoadGroup()
        {
            string sqlQuery = "SELECT * FROM StudyGroup";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            managerDataGroup.LoadData(command);
            dataGridViewGroup.Columns["ID"].Visible = false;
            dataGridViewGroup.Columns["ID_specialization"].Visible = false;
            dataGridViewGroup.Columns["NumGroup"].HeaderText = "Номер группы";
            dataGridViewGroup.Columns["NumGroup"].Width = 200;
            dataGridViewGroup.Columns["Kurs"].HeaderText = "Курс";
        }

        private void LoadStudent(long id_group)
        {
            string sqlQuery = "SELECT * FROM Student WHERE ID_group = @id_group";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_group", id_group);
            managerDataStudent.LoadData(command);
            SQLiteCommand commandInsert = new SQLiteCommand("INSERT INTO Student(FIO, ID_group) VALUES(@FIO, @ID_group)");
            commandInsert.Parameters.Add(new SQLiteParameter("@FIO", DbType.String, "FIO"));
            commandInsert.Parameters.AddWithValue("@ID_group", id_group);
            managerDataStudent.InitialCommandInsert(commandInsert);
            dataGridViewStudent.Columns["ID"].Visible = false;
            dataGridViewStudent.Columns["ID_group"].Visible = false;
            dataGridViewStudent.Columns["FIO"].HeaderText = "Ф.И.О.";
            dataGridViewStudent.Columns["FIO"].Width = 500;
        }

        private void buttonSaveStudent_Click(object sender, EventArgs e)
        {
            managerDataStudent.SaveDataGrid();
        }

        private void dataGridViewStudent_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewStudent.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck("Вы уверены что хотите удалить слушателя?"))
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private bool IsDeleteRowCheck(string text)
        {
            DialogResult result = MessageBox.Show(text, "Вы уверены", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void DeleteRowInDataGrid(DataGridView dataGridView, string textMessage)
        {
            if (dataGridView.SelectedRows.Count == 0 || dataGridView.SelectedRows[0] == null)
                return;
            if (!IsDeleteRowCheck(textMessage))
                return;
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
        }

        private void buttonSaveGroup_Click(object sender, EventArgs e)
        {
            if(managerDataGroup.SaveDataGrid())
                MessageBox.Show("Данные успешно сохранены", "Уведомление");
        }

        private void dataGridViewGroup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }

        public void AddNewGroup(long id_specialization, string numGroup, long kurs)
        {
            int rowid = SQLiteManager.InsertValue("StudyGroup", new string[] { "ID_specialization", "NumGroup", "Kurs" },
                new object[] { id_specialization, numGroup, kurs });
            BindingSource bind = (BindingSource)dataGridViewGroup.DataSource;            
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row["ID"] = Convert.ToInt64(rowid);
            row["ID_specialization"] = id_specialization;
            row["NumGroup"] = numGroup;
            row["Kurs"] = kurs;
            table.Rows.Add(row);
            row.AcceptChanges();
            dataGridViewGroup.Refresh();
        }

        public void AddNewStudent(long ID, long id_group, string FIO)
        {
            BindingSource bind = (BindingSource)dataGridViewStudent.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row["ID"] = ID;
            row["ID_group"] = id_group;
            row["FIO"] = FIO;
            table.Rows.Add(row);
            row.AcceptChanges();
            dataGridViewStudent.Refresh();
        }

        private void dataGridViewGroup_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewGroup.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck("Вы уверены что хотите удалить выбранную группу?"))
            {
                e.Cancel = false;
                managerDataStudent.Close();
                return;
            }
            e.Cancel = true;
        }

        private void dataGridViewGroup_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridViewGroup.SelectedRows.Count == 0 || dataGridViewGroup.SelectedRows[0] == null)
                return;
            currentNumGroup = dataGridViewGroup.SelectedRows[0].Cells["NumGroup"].Value.ToString();
            id_group_current = Convert.ToInt64(dataGridViewGroup.SelectedRows[0].Cells["ID"].Value);
            dataGridViewStudent.Tag = id_group_current;
            labelGroup.Text = "Группа " + currentNumGroup;
            string specName = SQLiteManager.GetValueFromDB("SPECIALIZATION", "Name", "ID", Convert.ToInt64(dataGridViewGroup.SelectedRows[0].Cells["ID_specialization"].Value));
            id_specialization_current = Convert.ToInt64(dataGridViewGroup.SelectedRows[0].Cells["ID_specialization"].Value);
            labelSpec.Text = "Специализация: " + specName;
            LoadStudent(id_group_current);
        }

        private void buttonAddStudent_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewStudent.Tag == null)
                return;
            FormAddStudent form = new FormAddStudent(Convert.ToInt64(dataGridViewStudent.Tag), currentNumGroup, id_specialization_current, this);
            form.ShowDialog();
        }

        private void выделеннуюГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroup.SelectedRows.Count == 0 || dataGridViewGroup.SelectedRows[0] == null)
            {
                MessageBox.Show("Сначала выберите в таблице группу", "Уведомление");
                return;
            }
            string currentGroup = dataGridViewGroup.SelectedRows[0].Cells["NumGroup"].Value.ToString();
            DialogResult result = MessageBox.Show("Вы уверены, что хотите перевести группу " + currentGroup + " на следующий курс. После этого вы не сможете загрузить оценки слушателей на прошлый год.", "Предупреждение", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
                return;
            string nextGroupValue = Program.GetNextNumKurs(currentGroup);
            if (String.IsNullOrWhiteSpace(nextGroupValue))
            {
                MessageBox.Show("Произошла ошибка. Не удалось распознать номер группы.", "Уведомление");
                return;
            }
            foreach(DataGridViewRow row in dataGridViewGroup.Rows)
            {
                string group = row.Cells["NumGroup"].Value.ToString();
                if (String.Equals(group, nextGroupValue, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("В базе уже есть группа, которая учится на следующем курсе.", "Недопустимая операция");
                    return;
                }
            }
            dataGridViewGroup.SelectedRows[0].Cells["NumGroup"].Value = nextGroupValue;
            int a = Convert.ToInt32(dataGridViewGroup.SelectedRows[0].Cells["Kurs"].Value);
            a += 1;
            dataGridViewGroup.SelectedRows[0].Cells["Kurs"].Value = a;
            MessageBox.Show("Изменения вступят в силу после нажатия кнопки \"Сохранить\"", "Уведомление");
        }

        private void всеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGroup.Rows.Count; i++)
            {
                string numGroup = dataGridViewGroup.Rows[i].Cells["NumGroup"].Value.ToString();
                if (numGroup.Length > 6 && String.Equals(numGroup.Substring(0, 6), "Выпуск", StringComparison.OrdinalIgnoreCase))
                    continue;
                string nextGroup = Program.GetNextNumKurs(numGroup);
                if (String.IsNullOrWhiteSpace(nextGroup))
                {
                    MessageBox.Show("Произошла ошибка. Не удалось распознать номер группы " + numGroup, "Уведомление");
                    continue;
                }
                dataGridViewGroup.Rows[i].Cells["NumGroup"].Value = nextGroup;
            }
            MessageBox.Show("Изменения вступят в силу после нажатия кнопки \"Сохранить\"", "Уведомление");
        }

        private void всеГруппыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите перевести все группы на следующий курс. После этого вы не сможете загрузить оценки слушателей на прошлый год.", "Предупреждение", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
                return;
            for (int i = 0; i < dataGridViewGroup.Rows.Count; i++)
            {
                string numGroup = dataGridViewGroup.Rows[i].Cells["NumGroup"].Value.ToString();
                if (numGroup.Length > 6 && String.Equals(numGroup.Substring(0, 6), "Выпуск", StringComparison.OrdinalIgnoreCase))
                    continue;
                string nextGroup = Program.GetNextNumKurs(numGroup);
                if (String.IsNullOrWhiteSpace(nextGroup))
                {
                    MessageBox.Show("Произошла ошибка. Не удалось распознать номер группы " + numGroup, "Уведомление");
                    continue;
                }
                dataGridViewGroup.Rows[i].Cells["NumGroup"].Value = nextGroup;
                int a = Convert.ToInt32(dataGridViewGroup.Rows[i].Cells["Kurs"].Value);
                a += 1;
                dataGridViewGroup.Rows[i].Cells["Kurs"].Value = a;
            }
            MessageBox.Show("Изменения вступят в силу после нажатия кнопки \"Сохранить\"", "Уведомление");
        }

    }
}
