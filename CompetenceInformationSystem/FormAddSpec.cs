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
    public partial class FormAddSpec : Form
    {
        FormSpecialty parentForm;
        public FormAddSpec(FormSpecialty parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите код специальности");
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите название специальности");
                return;
            }
            if (!SaveSpec())
            {
                MessageBox.Show("Специальность с указанным кодом уже существует!", "Ошибка");
                return;
            }
            this.Close();
        }

        private bool SaveSpec()
        {
            if (SQLiteManager.IsExistValue("SPECIALTY", "KOD", textBox1.Text))
                return false;
            int rowid = SQLiteManager.InsertValue("SPECIALTY", new string[] { "KOD", "Name" }, new string[] { textBox1.Text, textBox2.Text });
            if (rowid == -1)
                return false;
            DataGridView d = (DataGridView)parentForm.Controls["dataGridViewSpecialty"];
            BindingSource bind = (BindingSource)d.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row[0] = textBox1.Text;
            row[1] = textBox2.Text;           
            table.Rows.Add(row);
            row.AcceptChanges();           
            d.Refresh();            
            return true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
