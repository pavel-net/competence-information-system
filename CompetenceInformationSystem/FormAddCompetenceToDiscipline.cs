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
    public partial class FormAddCompetenceToDiscipline : Form
    {
        string id_specialty;
        long id_specialization;
        DataGridManager manager;
        FormDisciplineAndCompetence parentForm;

        public FormAddCompetenceToDiscipline(FormDisciplineAndCompetence parentForm, string specialtyName, string specializationName, string id_specialty, long id_specialization)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            label1.Text = "Компетенции специальности " + specialtyName;
            label2.Text = "Специализации " + specializationName;
            this.id_specialization = id_specialization;
            this.id_specialty = id_specialty;
            manager = new DataGridManager(dataGridView1, "Competence");
        }

        private void FormAddCompetenceToDiscipline_Load(object sender, EventArgs e)
        {
            LoadListView();
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Список компетенций данной специализации пуст. Невозможно связать дисциплину с компетенциями.", "Уведомление");
                Close();
            }
        }

        private void LoadListView()
        {
            string sqlQuery = "SELECT ID, KOD, NAME FROM COMPETENCE " +
                "WHERE ID_specialty = @id_specialty AND (ID_specialization IS NULL OR ID_specialization = @id_specialization)";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_specialty", id_specialty);
            command.Parameters.AddWithValue("@id_specialization", id_specialization);
            manager.LoadData(command);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["KOD"].HeaderText = "Код";
            dataGridView1.Columns["KOD"].Width = 100;
            dataGridView1.Columns["Name"].HeaderText = "Содержание компетенции";
            dataGridView1.Columns["Name"].Width = 500;
        }

        private void FormAddCompetenceToDiscipline_FormClosing(object sender, FormClosingEventArgs e)
        {
            manager.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList List = new System.Collections.ArrayList();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool flag = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                if (flag)
                {
                    List.Add(dataGridView1.Rows[i]);
                }
            }
            parentForm.AddCompetenceChosenDiscipline(List);
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            bool result = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = !result;
        }
    }
}
