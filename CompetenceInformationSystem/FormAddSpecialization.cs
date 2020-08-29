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
    public partial class FormAddSpecialization : Form
    {
        FormSpecialty parentForm;
        string kodParentSpec;
        public FormAddSpecialization(FormSpecialty parentForm, string kodParentSpec)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.kodParentSpec = kodParentSpec;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите название специальности");
                return;
            }
            if (!SaveSpecialization())
            {
                MessageBox.Show("Проблема с подключением к базе. Повторите попытку позже.", "Ошибка");
                return;
            }
            this.Close();
        }

        private bool SaveSpecialization()
        {
            int rowid = SQLiteManager.InsertValue("Specialization", new string[] { "Number", "Name", "specialty_fk" },
                new string[] { numericUpDown1.Value.ToString(), textBox2.Text, kodParentSpec });
            if (rowid == -1)
                return false;
            DataGridView d = (DataGridView)parentForm.Controls["dataGridViewSpecialization"];
            BindingSource bind = (BindingSource)d.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row["Number"] = numericUpDown1.Value.ToString();
            row["Name"] = textBox2.Text;
            row["ID"] = rowid;
            row["specialty_fk"] = kodParentSpec;
            table.Rows.Add(row);
            row.AcceptChanges();
            d.Refresh();
            return true;
        }
    }
}
