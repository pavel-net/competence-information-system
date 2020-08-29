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
    public partial class FormDiscipline : Form
    {
        DataGridManager managerDiscipline;
        long id_specialization;
        string semester;
        int countEdit = 0;
        PageGroupManager parentManager;

        public FormDiscipline(PageGroupManager parentManager, int semester, long id_specialization, string nameGroup)
        {
            InitializeComponent();
            this.parentManager = parentManager;
            this.id_specialization = id_specialization;
            this.semester = semester.ToString();
            label1.Text = "Список дисциплин группы " + nameGroup + " на " + semester.ToString() + " семестер";
            managerDiscipline = new DataGridManager(dataGridView1, "WorkProgramm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managerDiscipline.SaveDataGrid();
            Close();
        }

        private void FormDiscipline_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (countEdit != 0)
            {
                parentManager.CheckCorrectDisciplineData();
                parentManager.UpdateState();
            }
            managerDiscipline.Close();
        }

        private void FormDiscipline_Load(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT ID, NameDiscipline, ID_specialization FROM WorkProgramm " +
                "WHERE ID_specialization = @id_spec AND SEMESTER LIKE @sem ";
            SQLiteCommand command = new SQLiteCommand(sqlSelect);
            command.Parameters.AddWithValue("@id_spec", id_specialization);
            command.Parameters.AddWithValue("@sem", "%" + semester + "%");
            managerDiscipline.LoadData(command);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ID_specialization"].Visible = false;
            dataGridView1.Columns["NameDiscipline"].HeaderText = "Название дисциплины";
            dataGridView1.Columns["NameDiscipline"].Width = 500;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                MessageBox.Show("Ячейка не может быть пустой", "Ошибка редактирования");
                dataGridView1.CancelEdit();
            }
            countEdit++;
        }
    }
}
