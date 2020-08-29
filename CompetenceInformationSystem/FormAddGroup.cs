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
    public partial class FormAddGroup : Form
    {
        DataListManager managerSpecialty;
        DataListManager managerSpecialization;
        FormGroupAndStudent parentForm;

        public FormAddGroup(FormGroupAndStudent parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAddGroup_Load(object sender, EventArgs e)
        {
            managerSpecialty = new DataListManager("SPECIALTY", new string[] { "KOD", "NAME" });
            managerSpecialization = new DataListManager("SPECIALIZATION", new string[] { "ID", "NUMBER", "NAME" });
            InitialComboBoxSpecialty();
            InitialComboBoxNumGroup();
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

        private void InitialComboBoxNumGroup()
        {
            for (int i = 0; i < Program.GroupNames.Length; i++)
            {
                comboBoxNumGroup.Items.Add(Program.GroupNames[i]);
            }
        }

        private void comboBoxSpecialty_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSpecialty.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите специальность группы", "Уведомление");
                return;
            }
            if (comboBoxSpecialization.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите специализацию группы", "Уведомление");
                return;
            }
            if (comboBoxNumGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите номер группы", "Уведомление");
                return;
            }
            long id_specialization = Convert.ToInt64(managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID"));
            string numGroup = comboBoxNumGroup.Items[comboBoxNumGroup.SelectedIndex].ToString();
            int kurs = Program.GetNumKurs(numGroup);
            if (SQLiteManager.IsExistValue("StudyGroup", "NumGroup", numGroup))
            {
                MessageBox.Show("В базе данных уже есть группа под таким номером.", "Ошибка");
                return;
            }
            parentForm.AddNewGroup(id_specialization, numGroup, kurs);
            Close();
        }

    }
}
