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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void списокСпециальностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpecialty form = new FormSpecialty();
            form.ShowDialog();
        }

        private void дисциплиныИКомпетенцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisciplineAndCompetence form = new FormDisciplineAndCompetence();
            form.ShowDialog();
        }

        private void загрузитьУчебныйПланToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoadDiscipline form = new FormLoadDiscipline(this);
            this.Visible = false;
            form.Show();
        }

        private void учебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGroupAndStudent form = new FormGroupAndStudent();
            form.ShowDialog();
        }

        private void загрузитьОценкиСлушателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoadGroupAssessment form = new FormLoadGroupAssessment(this);
            this.Visible = false;
            form.Show();           
        }

        private void загрузитьКомпетенцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoadCompetence form = new FormLoadCompetence(this);
            this.Visible = false;
            form.Show();
        }

        private void загрузитьРабочийПланToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoapWorkPlan form = new FormLoapWorkPlan(this);
            this.Visible = false;
            form.Show();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, "Help.chm");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка");
            }
        }

    }
}
