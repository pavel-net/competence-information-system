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
    public partial class FormAssessmentUser : Form
    {
        // SELECT * FROM WorkProgramm WHERE SEMESTER LIKE '%8%'
        DataGridManager managerDataDiscipAssessment;
        long id_student;
        int kurs;

        public FormAssessmentUser(string FIO, long id_student, string numGroup)
        {
            InitializeComponent();
            labelStudent.Text = "Успеваемость слушателя " + FIO + " группы " + numGroup;
            this.id_student = id_student;
            this.kurs = Program.GetNumKurs(numGroup);
            managerDataDiscipAssessment = new DataGridManager(dataGridViewDiscip, "Assessment_Discipline");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (managerDataDiscipAssessment.SaveDataGrid())
                MessageBox.Show("Данные успешно сохранены", "Успех");
            Close();
        }

        private void comboBoxSemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxSemester.SelectedIndex == -1)
            {
                managerDataDiscipAssessment.Close();
                return;
            }
            LoadAssessmentDiscipline(comboBoxSemester.SelectedIndex + 1);
        }

        private void dataGridViewDiscip_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewDiscip[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    dataGridViewDiscip.CancelEdit();
                    return;
                }
                string temp = dataGridViewDiscip[e.ColumnIndex, e.RowIndex].Value.ToString();
                int value = Convert.ToInt32(temp);
                if (value < 2 || value > 5)
                {
                    MessageBox.Show("Оценка должна быть в пределах от 2 до 5 или 0 в случае отсутствия оценки", "Ошибка редактирования");
                    dataGridViewDiscip.CancelEdit();
                }
            }
            catch
            {
                dataGridViewDiscip.CancelEdit();
            }
        }

        private void FormAssessmentUser_Load(object sender, EventArgs e)
        {
            InitialComboBoxSemester();
        }

        private void FormAssessmentUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerDataDiscipAssessment.Close();
        }

        private void InitialComboBoxSemester()
        {
            for (int i = 1; i <= kurs * 2; i++)
                comboBoxSemester.Items.Add(i);
        }

        private void LoadAssessmentDiscipline(int semester)
        {
            string sqlQuery = "SELECT b.ID, b.NameDiscipline, a.ID_student, a.ID_discipline, a.Assessment, a.Semester " +
                "FROM Assessment_Discipline a, WorkProgramm b WHERE a.Semester = @sem AND a.ID_student = @id_stud AND a.ID_discipline = b.ID";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@sem", Convert.ToInt64(semester));
            command.Parameters.AddWithValue("@id_stud", id_student);
            managerDataDiscipAssessment.LoadData(command);
            SQLiteCommand commandUpdate = new SQLiteCommand("UPDATE Assessment_Discipline SET Assessment = @ass WHERE ID_student = @id_stud AND ID_discipline = @id_disp AND semester = @sem");
            commandUpdate.Parameters.AddWithValue("@id_stud", id_student);
            commandUpdate.Parameters.Add(new SQLiteParameter("@id_disp", DbType.Int64, "ID_discipline"));
            commandUpdate.Parameters["@id_disp"].SourceVersion = DataRowVersion.Original;
            commandUpdate.Parameters.Add(new SQLiteParameter("@ass", DbType.Int64, "Assessment"));
            commandUpdate.Parameters.AddWithValue("@sem", Convert.ToInt64(semester));
            SQLiteCommand commandDelete = new SQLiteCommand(" ");
            managerDataDiscipAssessment.InitialCommandUpdate(commandUpdate);
            managerDataDiscipAssessment.InitialCommandDelete(commandDelete);
            dataGridViewDiscip.Columns["ID"].Visible = false;
            dataGridViewDiscip.Columns["ID_student"].Visible = false;
            dataGridViewDiscip.Columns["ID_discipline"].Visible = false;
            dataGridViewDiscip.Columns["Semester"].Visible = false;
            dataGridViewDiscip.Columns["NameDiscipline"].HeaderText = "Название дисциплины";
            dataGridViewDiscip.Columns["NameDiscipline"].Width = 300;
            dataGridViewDiscip.Columns["NameDiscipline"].ReadOnly = true;
            dataGridViewDiscip.Columns["Assessment"].HeaderText = "Оценка";
            dataGridViewDiscip.Columns["Assessment"].Width = 100;
        }

        private void dataGridViewDiscip_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridViewDiscip.CancelEdit();
        }
    }
}
