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
    public partial class FormAddCompetence : Form
    {
        FormDisciplineAndCompetence parentForm;
        string kodSpecialty;
        long id_specialization = -1;

        public FormAddCompetence(FormDisciplineAndCompetence parentForm, string nameSpecialty,
            string nameSpecialization, string kodSpecialty, long id_specialization)
        {
            InitializeComponent();
            textBox1.Text = nameSpecialty;
            textBox2.Text = nameSpecialization;
            this.kodSpecialty = kodSpecialty;
            this.id_specialization = id_specialization;
            this.parentForm = parentForm;
        }

        public FormAddCompetence(FormDisciplineAndCompetence parentForm, string nameSpecialty, string kodSpecialty)
        {
            InitializeComponent();
            textBox1.Text = nameSpecialty;
            this.parentForm = parentForm;
            this.kodSpecialty = kodSpecialty;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Содержание компетенции не может быть пустым!", "Ошибка");
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
            string[] columns;
            object[] paramValue;
            string name = textBoxName.Text.Trim();
            string kod = textBoxKod.Text.Trim();
            if (id_specialization == -1)
            {
                columns = new string[] { "Name", "KOD", "ID_SPECIALTY" };
                paramValue = new object[] { name, kod, kodSpecialty };
            }
            else
            {
                columns = new string[] { "Name", "KOD", "ID_SPECIALTY", "ID_SPECIALIZATION" };
                paramValue = new object[] { name, kod, kodSpecialty, id_specialization };
            }
            int rowid = SQLiteManager.InsertValue("COMPETENCE", columns, paramValue);
            if (rowid == -1)
                return false;
            parentForm.AddCompetenceInDataGrid(name, kod, rowid, kodSpecialty, id_specialization);
            return true;
        }

    }
}
