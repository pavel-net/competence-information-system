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
    public partial class FormSpecialty : Form
    {
        DataGridManager ManagerDataSpecialty;
        DataGridManager ManagerDataSpecialization;
        //DataGridViewRow currentRowSelected = null;

        public FormSpecialty()
        {
            InitializeComponent();
            ManagerDataSpecialty = new DataGridManager(dataGridViewSpecialty, "Specialty");
            ManagerDataSpecialization = new DataGridManager(dataGridViewSpecialization, "Specialization");
        }

        private void FormSpecialty_Load(object sender, EventArgs e)
        {
            LoadSpecialty();
        }

        private void LoadSpecialty()
        {
            ManagerDataSpecialization.ClearDataGrid();
            string sqlQuery = "SELECT * FROM Specialty";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            ManagerDataSpecialty.LoadData(command);

            dataGridViewSpecialty.Columns["KOD"].HeaderText = "Код";
            dataGridViewSpecialty.Columns["KOD"].ReadOnly = true;
            dataGridViewSpecialty.Columns["KOD"].Width = 100;
            dataGridViewSpecialty.Columns["Name"].HeaderText = "Название";
            dataGridViewSpecialty.Columns["Name"].Width = 500;
        }

        private void LoadSpecialization(string id_fk)
        {
            string sqlQuery = "SELECT * FROM Specialization WHERE specialty_fk = @id_param";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_param", id_fk);
            ManagerDataSpecialization.LoadData(command);

            dataGridViewSpecialization.Columns["Number"].HeaderText = "Номер";
            dataGridViewSpecialization.Columns["Name"].HeaderText = "Название";
            dataGridViewSpecialization.Columns["Number"].Width = 100;
            dataGridViewSpecialization.Columns["Name"].Width = 500;
            dataGridViewSpecialization.Columns["ID"].Visible = false;
            dataGridViewSpecialization.Columns["specialty_fk"].Visible = false;
        }

        private void dataGridViewSpecialty_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSpecialty.SelectedRows.Count == 0)
                return;
            //currentRowSelected = dataGridViewSpecialty.SelectedRows[0];
            string id = dataGridViewSpecialty[0, dataGridViewSpecialty.SelectedRows[0].Index].Value.ToString();
            if (dataGridViewSpecialization.Tag != null && dataGridViewSpecialization.Tag.ToString() == id)
                return;
            dataGridViewSpecialization.Tag = id;
            label2.Text = "Список специализаций по специальности " + dataGridViewSpecialty[1, dataGridViewSpecialty.CurrentCell.RowIndex].Value.ToString();
            LoadSpecialization(id);
            //currentRowSelected = dataGridViewSpecialty.Rows[dataGridViewSpecialty.SelectedRows[0].Index];
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ManagerDataSpecialty.SaveDataGrid();
        }


        private void FormSpecialty_FormClosing(object sender, FormClosingEventArgs e)
        {          
            ManagerDataSpecialization.Close();
            ManagerDataSpecialty.Close();
        }


        private void buttonAddSpec1_Click(object sender, EventArgs e)
        {
            FormAddSpec f2 = new FormAddSpec(this);
            f2.ShowDialog();
        }

        private void buttonSaveSpec2_Click_1(object sender, EventArgs e)
        {
            ManagerDataSpecialization.SaveDataGrid();        
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpecialty.SelectedRows == null || dataGridViewSpecialty.SelectedRows.Count == 0)
                return;
            if (!IsDeleteRowCheck())
                return;
            ClearDataSpecialization();
            dataGridViewSpecialty.Rows.Remove(dataGridViewSpecialty.SelectedRows[0]);
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpecialization.Tag == null)
            {
                MessageBox.Show("Выберите специализацию из списка", "Ошибка");
                return;
            }
            FormAddSpecialization f3 = new FormAddSpecialization(this, dataGridViewSpecialization.Tag.ToString());
            f3.ShowDialog();
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpecialization.SelectedRows == null || dataGridViewSpecialization.SelectedRows.Count == 0)
                return;
            if (!IsDeleteRowCheck())
                return;
            dataGridViewSpecialization.Rows.Remove(dataGridViewSpecialization.SelectedRows[0]);
        }

        private bool IsDeleteRowCheck()
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить данную специализацию?", "Вы уверены", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void ClearDataSpecialization()
        {
            ManagerDataSpecialization.ClearDataGrid();
            label2.Text = "Список специализаций";
        }

        private void dataGridViewSpecialty_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewSpecialty.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck())
            {
                ClearDataSpecialization();
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private void dataGridViewSpecialty_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (String.IsNullOrWhiteSpace(grid[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                MessageBox.Show("Пустая ячейка недопустима!", "Ошибка редактирования");
                grid.CancelEdit();
            }
        }

        private void dataGridViewSpecialization_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewSpecialization.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck())
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewSpecialty_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dataGridViewSpecialty.CurrentCell == null)
            //    return;
            //string id = dataGridViewSpecialty[0, dataGridViewSpecialty.CurrentCell.RowIndex].Value.ToString();
            //if (dataGridViewSpecialization.Tag != null && dataGridViewSpecialization.Tag.ToString() == id)
            //    return;
            //dataGridViewSpecialization.Tag = id;
            //label2.Text = "Список специализаций по специальности " + dataGridViewSpecialty[1, dataGridViewSpecialty.CurrentCell.RowIndex].Value.ToString();
            //LoadSpecialization(id);
            //currentRowSelected = dataGridViewSpecialty.Rows[dataGridViewSpecialty.CurrentCell.RowIndex];
        }
    }
}
