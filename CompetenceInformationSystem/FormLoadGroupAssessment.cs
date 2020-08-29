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
    public partial class FormLoadGroupAssessment : Form
    {
        FormStart parentForm;
        public FormLoadGroupAssessment(FormStart parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void FormLoadGroupAssessment_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Visible = true;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (comboBoxSem.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите семестер", "Уведомление");
                return;
            }           
            OpenFileDialog Open_file = new OpenFileDialog();
            Open_file.InitialDirectory = "C:\\";
            Open_file.Filter = "Excel files |*.xlsx; *.xls";
            Open_file.RestoreDirectory = true;
            if (Open_file.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            superTabControl1.TabPages.Clear();
            if (!LoadExcelAssessmentData(Open_file.FileName))
            {
                MessageBox.Show("В ходе загрузки данных произошла ошибка. Проверьте корректность входного файла.", "Ошибка");
                return;
            }                       
        }

        private bool LoadExcelAssessmentData(string fileName)
        {
            ReaderRating reader = new ReaderRating(fileName);
            RatingGroup[] TableRating = reader.ReadAllTable();
            reader.Close();
            bool flag = (comboBoxSem.SelectedIndex == 1) ? true : false;
            if (TableRating == null || TableRating.Length == 0)
                return false;
            for (int i = 0; i < TableRating.Length; i++)
            {
                TabPage page = new TabPage(TableRating[i].NameGroup);
                page.Text = TableRating[i].NameGroup;
                // добавляем в ТАГ страницы manager данных этой страницы                              
                //page.Tag = new PageGroupManager(page, TableRating[i], true);
                superTabControl1.TabPages.Add(page);
            }
            for (int i = 0; i < TableRating.Length; i++)
            {
                superTabControl1.TabPages[i].Tag = new PageGroupManager(superTabControl1.TabPages[i], TableRating[i], flag, superTabControl1);
            }
            return true;
        }

        private void superTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (superTabControl1.SelectedIndex == -1)
                return;
            //PageGroupManager manager = (PageGroupManager)superTabControl1.TabPages[superTabControl1.SelectedIndex].Tag;
            //manager.UpdateState();
        }

        private void FormLoadGroupAssessment_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized; 
        }

    }
}
