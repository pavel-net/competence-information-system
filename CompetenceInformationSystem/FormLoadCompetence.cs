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
    public partial class FormLoadCompetence : Form
    {
        DataListManager managerSpecialty;
        FormStart parentForm;
        string current_kod_specialty;

        public FormLoadCompetence(FormStart parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void FormLoadCompetence_Load(object sender, EventArgs e)
        {
            managerSpecialty = new DataListManager("SPECIALTY", new string[] { "KOD", "NAME" });
            InitialComboBoxSpecialty();
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialty.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите специальность, для которой планируется загружать компетенции.", "Уведомление");
                return;
            }
            OpenFileDialog Open_file = new OpenFileDialog();
            Open_file.InitialDirectory = "C:\\";
            Open_file.Filter = "Word files |*.docx; *.doc";
            Open_file.RestoreDirectory = true;
            if (Open_file.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            superTabControl1.TabPages.Clear();
            LoadData(Open_file.FileName);
            if (superTabControl1.TabPages.Count > 0)
                buttonSave.Enabled = true;
            //this.WindowState = FormWindowState.Maximized; 
        }

        private void LoadData(string fileName)
        {
            ReaderWordCompetence reader = new ReaderWordCompetence(fileName);
            System.Collections.ArrayList list = reader.GetCompetenceArray();
            if (list == null)
            {
                MessageBox.Show("Не удалось считать файл.", "Ошибка");
                return;
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Не удалось найти ни одной компетенции в файле.", "Ошибка");
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                string[,] competenceArray = (string[,])list[i];
                if (competenceArray == null || competenceArray.GetLength(0) == 0)
                    continue;
                bool IsSpecializationNeed = true;
                string namePage;
                if (i == 0)
                {   // ПК
                    namePage = "ПК";
                    IsSpecializationNeed = false;
                }
                else
                    namePage = "ПСК-" + i.ToString();
                TabPage page = new TabPage(namePage);
                superTabControl1.TabPages.Add(page);
                PageCompetenceManager manager = new PageCompetenceManager(page, current_kod_specialty, competenceArray, IsSpecializationNeed);
                page.Tag = manager;
            }
        }

        private bool CheckSaveState()
        {
            for (int i = 0; i < superTabControl1.TabPages.Count; i++)
            {
                PageCompetenceManager manager = (PageCompetenceManager)superTabControl1.TabPages[i].Tag;
                if (!manager.IsSpecializationChoose)
                {
                    richTextBoxState.Text = "Загрузка невозможна. Не во всех вкладках выбрана целевая специализация для загрузки.";
                    return false;
                }
                if (!manager.IsDataCorrect)
                {
                    richTextBoxState.Text = "Загрузка невозможна. В " + (i+1).ToString() + " вкладке присутствуют ошибочные данные.";
                    return false;
                }
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (superTabControl1.TabPages.Count == 0)
                return;
            if (!CheckSaveState())
                return;
            for (int i = 0; i < superTabControl1.TabPages.Count; i++)
            {
                PageCompetenceManager manager = (PageCompetenceManager)superTabControl1.TabPages[i].Tag;
                manager.Save();
            }
            MessageBox.Show("Данные успешно сохранены.", "Уведомление.");
            superTabControl1.TabPages.Clear();
        }

        private void comboBoxSpecialty_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            if (comboBoxSpecialty.SelectedIndex == -1)
            {
                buttonFile.Enabled = false;
                return;
            }
            buttonFile.Enabled = true;
            int index = comboBoxSpecialty.SelectedIndex;
            current_kod_specialty = managerSpecialty.GetCellValue(index, "KOD");
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

        private void FormLoadCompetence_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Visible = true;
        }

       

    }
}
