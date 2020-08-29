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
    public partial class FormLoapWorkPlan : Form
    {
        FormStart parentForm;
        DataListManager managerSpecialty;
        DataListManager managerSpecialization;

        public FormLoapWorkPlan(FormStart parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void FormLoapWorkPlan_Load(object sender, EventArgs e)
        {
            managerSpecialty = new DataListManager("SPECIALTY", new string[] { "KOD", "NAME" });
            managerSpecialization = new DataListManager("SPECIALIZATION", new string[] { "ID", "NUMBER", "NAME" });
            InitialComboBoxSpecialty();
            richTextBoxState.Text = "Выберите специальность и специализацию, для которой планируется загрузить рабочий план дисциплины.";
        }

        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpecialty.SelectedIndex == -1)
            {
                comboBoxSpecialization.Items.Clear();
                return;
            }
            int index = comboBoxSpecialty.SelectedIndex;
            string kod_specialty = managerSpecialty.GetCellValue(index, "KOD");
            InitialComboBoxSpecialization(kod_specialty);
        }

        private void comboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialization.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите специальность и специализацию из списка.", "Уведомление");
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(dialog.SelectedPath);
            System.IO.FileInfo[] files1 = dir.GetFiles("*.docx");
            System.IO.FileInfo[] files2 = dir.GetFiles("*.doc");
            if (files1.Length == 0 && files2.Length == 0)
                return;
            string[] filePath = new string[files1.Length + files2.Length];
            string[] fileNames = new string[files1.Length + files2.Length];
            int k = -1;
            for (int i = 0; i < files1.Length; i++)
            {
                ++k;
                filePath[i] = files1[i].FullName;
                fileNames[i] = files1[i].Name;
            }
            for (int i = 0; i < files2.Length; i++)
            {
                ++k;
                filePath[i] = files2[i].FullName;
                fileNames[i] = files2[i].Name;
            }
            LoadData(filePath, fileNames);
            buttonSave.Enabled = true;
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialization.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите специальность и специализацию из списка.", "Уведомление");
                return;
            }
            OpenFileDialog Open_file = new OpenFileDialog();
            Open_file.InitialDirectory = "C:\\";
            Open_file.Filter = "Word files |*.docx; *.doc";
            Open_file.RestoreDirectory = true;
            if (Open_file.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            LoadData(new string[] { Open_file.FileName }, new string[] { Open_file.SafeFileName });
            buttonSave.Enabled = true;
        }

        private void UpdateState()
        {
            if (superTabControl1.TabPages.Count == 0)
                return;
            richTextBoxState.Text = "";
            System.Collections.ArrayList listChooseDiscip = new System.Collections.ArrayList();
            System.Collections.ArrayList listCorrectData = new System.Collections.ArrayList();
            for (int i = 0; i < superTabControl1.TabPages.Count; i++)
            {
                PageWorkPlanManager manager = (PageWorkPlanManager)superTabControl1.TabPages[i].Tag;
                if (!manager.IsDisciplineChoosen)
                    listChooseDiscip.Add(manager.fileName);
                if (!manager.IsDataCorrect)
                    listCorrectData.Add(manager.fileName);
            }
            if (listChooseDiscip.Count == 0 && listCorrectData.Count == 0)
            {
                richTextBoxState.Text = "Данные готовы к сохранению";
                return;
            }
            if (listChooseDiscip.Count != 0)
            {
                string text = "Выберите название загружаемой дисциплины для следующих файлов:\n";
                for (int i = 0; i < listChooseDiscip.Count; i++)
                    text += listChooseDiscip[i].ToString() + "\n";
                richTextBoxState.AppendText(text);
            }
            if (listCorrectData.Count != 0)
            {
                string text = "В следующих файлах обнаружены незагруженные в базу компетенции, они помечены жёлтым. Удалите их из списка загрузки:\n";
                for (int i = 0; i < listCorrectData.Count; i++)
                    text += listCorrectData[i].ToString() + "\n";
                richTextBoxState.AppendText(text);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (superTabControl1.TabPages.Count == 0)
                return;
            for (int i = 0; i < superTabControl1.TabPages.Count; i++)
            {
                PageWorkPlanManager manager = (PageWorkPlanManager)superTabControl1.TabPages[i].Tag;
                if (!manager.IsDataCorrect || !manager.IsDisciplineChoosen)
                {
                    UpdateState();
                    MessageBox.Show("Данные не готовы к загрузке.", "Уведомление");
                    return;
                }
            }
            for (int i = 0; i < superTabControl1.TabPages.Count; i++)
            {
                PageWorkPlanManager manager = (PageWorkPlanManager)superTabControl1.TabPages[i].Tag;
                manager.Save();
            }
            MessageBox.Show("Данные успешно сохранены", "Уведомление");
            superTabControl1.TabPages.Clear();
        }

        private void FormLoapWorkPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Visible = true;
        }

        private void LoadData(string[] FileNames, string[] Names)
        {
            superTabControl1.TabPages.Clear();
            string kod_specialty = managerSpecialty.GetCellValue(comboBoxSpecialty.SelectedIndex, "KOD");
            long id_specialization = Convert.ToInt64(managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID"));
            for (int i = 0; i < FileNames.Length; i++)
            {
                ReaderWorkPlan reader = new ReaderWorkPlan(FileNames[i]);
                string nameDisp = "";
                string[] Competence = reader.ReadCompetenceKod(ref nameDisp);
                if (Competence == null || Competence.Length == 0)
                    continue;
                TabPage page = new TabPage(Names[i]);
                superTabControl1.TabPages.Add(page);
                PageWorkPlanManager manager = new PageWorkPlanManager(Names[i], nameDisp, page, kod_specialty, id_specialization, Competence);
                page.Tag = manager;
            }
            UpdateState();
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

        void InitialComboBoxSpecialization(string kod)
        {
            if (comboBoxSpecialization.SelectedItem != null)
                comboBoxSpecialization.SelectedItem = null;
            comboBoxSpecialization.Items.Clear();
            string sqlQuery = "SELECT * FROM SPECIALIZATION WHERE SPECIALTY_fk = @kod ORDER BY NAME";
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@kod", kod);
            if (!managerSpecialization.LoadData(command))
            {
                MessageBox.Show("Не удалось загрузить данные из БД. Проверьте подключение к БД.", "Ошибка");
                Close();
            }
            managerSpecialization.GetDataInComboBox(comboBoxSpecialization, "NAME");
        }
    }
}
