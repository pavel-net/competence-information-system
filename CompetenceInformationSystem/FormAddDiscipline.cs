using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompetenceInformationSystem
{
    public partial class FormAddDiscipline : Form
    {
        FormDisciplineAndCompetence parentForm;
        long id_specialization;

        public FormAddDiscipline(FormDisciplineAndCompetence parentForm, string nameSpecialty,
            string nameSpecialization, long id_specialization)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.id_specialization = id_specialization;
            textBox1.Text = nameSpecialty;
            textBox2.Text = nameSpecialization;
        }

        private void FormAddDiscipline_Load(object sender, EventArgs e)
        {
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxDiscipline.Text))
            {
                MessageBox.Show("Введите название дисциплины");
                return;
            }
            else if (checkedListBox1.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Выберите семестры, в которых производится отчётность по дисциплине.");
                return;
            }
            if (!Save())
            {
                MessageBox.Show("Произошла ошибка. Проверьте соединение с БД.");
            }
            Close();
        }

        private bool Save()
        {
            string semester = "";           
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                semester += (index + 1).ToString() + ";";
            }
            int rowid = SQLiteManager.InsertValue("WorkProgramm", new string[] { "NameDiscipline", "ID_specialization", "Semester" },
                new object[] { textBoxDiscipline.Text, id_specialization, semester });
            if (rowid == -1)
                return false;
            parentForm.AddDisciplineInDataGrid(textBoxDiscipline.Text, rowid, id_specialization, semester);
            return true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
