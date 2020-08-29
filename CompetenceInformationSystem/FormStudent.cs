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
    public partial class FormStudent : Form
    {
        DataGridManager managerStudent;
        long id_group;
        int countEdit = 0;
        PageGroupManager parentManager;

        public FormStudent(PageGroupManager parentManager, long id_group, string numGroup)
        {
            InitializeComponent();
            this.parentManager = parentManager;
            this.id_group = id_group;
            label1.Text = "Список слушателей группы " + numGroup;
            managerStudent = new DataGridManager(dataGridView1, "Student");
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            managerStudent.SaveDataGrid();
            Close();
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

        private void FormStudent_Load(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM Student " +
                    "WHERE ID_group = @id_group";
            SQLiteCommand command = new SQLiteCommand(sqlSelect);
            command.Parameters.AddWithValue("@id_group", id_group);
            managerStudent.LoadData(command);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["id_group"].Visible = false;
            dataGridView1.Columns["FIO"].HeaderText = "Ф.И.О.";
            dataGridView1.Columns["FIO"].Width = 500;
        }

        private void FormStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (countEdit != 0)
            {
                parentManager.CheckCorrectStudentData();
                parentManager.UpdateState();
            }
            managerStudent.Close();
        }
    }
}
