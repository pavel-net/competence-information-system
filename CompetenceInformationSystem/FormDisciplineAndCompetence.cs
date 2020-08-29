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
    public partial class FormDisciplineAndCompetence : Form
    {
        TreeNode currentNode = null;
        DataGridManager ManagerDataDiscipline;
        DataGridManager ManagerDataCompetence;
        DataGridManager ManagerDataCompChosenDiscipline;
        DataGridManager ManagerDataDisciplineChosenCompetence;
        DataListManager managerSpecialization;  // используется для хранения данных выпадающего списка специализаций

        public FormDisciplineAndCompetence()
        {
            InitializeComponent();
            ManagerDataCompetence = new DataGridManager(dataGridViewComp, "Competence");
            ManagerDataDiscipline = new DataGridManager(dataGridViewDiscip, "WorkProgramm");
            ManagerDataCompChosenDiscipline = new DataGridManager(dataGridCompChosenDiscip, "COMPETENCE");
            ManagerDataDisciplineChosenCompetence = new DataGridManager(dataGridDisciplineChosenCompetence, "COMPETENCE");
            managerSpecialization = new DataListManager("SPECIALIZATION", new string[] { "ID", "NUMBER", "NAME" });
        }

        private void LoadTree()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlSelect = "SELECT * FROM SPECIALTY";
            SQLiteCommand command = new SQLiteCommand(sqlSelect);
            command.Connection = connection;
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TreeNode node = new TreeNode(reader["Name"].ToString());
                node.Tag = reader["KOD"];
                treeView1.Nodes.Add(node);
            }
            reader.Close();
            if (treeView1.Nodes.Count == 0)
            {
                connection.Close();
                return;
            }
            // теперь загрузим все специализации
            command.CommandText = "SELECT * FROM SPECIALIZATION WHERE specialty_fk = @id_spec ORDER BY Number";
            command.Parameters.Add(new SQLiteParameter("@id_spec"));
            foreach (TreeNode node in treeView1.Nodes)
            {
                command.Parameters[0].Value = node.Tag;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TreeNode node_child = new TreeNode(reader["Number"].ToString() + " " + reader["Name"].ToString());
                    node_child.Tag = reader["ID"];
                    node.Nodes.Add(node_child);
                }
                reader.Close();
            }
        }

        private void LoadDiscipline()
        {
            TreeNode nodeDataDisplay = (TreeNode)dataGridViewDiscip.Tag;
            if (currentNode == nodeDataDisplay)
                return;
            ManagerDataCompChosenDiscipline.Close();
            panel1.Enabled = false;
            label3.Text = "Компетенции, формируемые дисциплиной";
            dataGridViewDiscip.Tag = currentNode;
            if (currentNode.Level == 0)
            {
                label1.Text = "Выберите специализацию";
                panelDiscipline.Enabled = false;
                ManagerDataDiscipline.Close();
            }
            else
            {
                panelDiscipline.Enabled = true;
                LoadDiscipline((long)currentNode.Tag);
                label1.Text = "Дисциплины по специализации " + currentNode.Text;
            }
        }

        private void LoadDiscipline(long id_specialization)
        {
            string sqlQuery = "SELECT * FROM WorkProgramm WHERE id_specialization = @id_param";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_param", id_specialization);
            ManagerDataDiscipline.LoadData(command);
            dataGridViewDiscip.Columns["ID"].Visible = false;
            dataGridViewDiscip.Columns["id_specialization"].Visible = false;
            dataGridViewDiscip.Columns["FormReport"].Visible = false;
            dataGridViewDiscip.Columns["NameDiscipline"].HeaderText = "Название дисциплины";
            dataGridViewDiscip.Columns["NameDiscipline"].Width = 400;
            dataGridViewDiscip.Columns["NameDiscipline"].DisplayIndex = 0;
            dataGridViewDiscip.Columns["Semester"].HeaderText = "Семестры отчётности";
            dataGridViewDiscip.Columns["Semester"].DisplayIndex = 1;
        }

        private void LoadCompetenceChosenDiscipline(DataGridViewRow row)
        {
            ManagerDataCompChosenDiscipline.Close();                 
            long id_spec = Convert.ToInt64(row.Cells["id_specialization"].Value);
            long id_disp = Convert.ToInt64(row.Cells["ID"].Value);
            LoadCompetenceChosenDiscipline(id_spec, id_disp);
            SQLiteCommand commandUpdate = new SQLiteCommand(" ");
            SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM COMPETENCE_DISCIPLINE WHERE ID_competence = @id_comp AND ID_discipline = @id_disp");
            SQLiteParameter parameter1 = new SQLiteParameter("@id_comp", DbType.Int64, "ID");
            parameter1.SourceVersion = DataRowVersion.Original;
            SQLiteParameter parameter2 = new SQLiteParameter("@id_disp", id_disp);
            commandDelete.Parameters.Add(parameter1);
            commandDelete.Parameters.Add(parameter2);
            ManagerDataCompChosenDiscipline.InitialCommandDelete(commandDelete);
            ManagerDataCompChosenDiscipline.InitialCommandUpdate(commandUpdate);
        }

        private void LoadCompetenceChosenDiscipline(long id_specialization, long id_work_programm)
        {
            string sqlQuery = "SELECT ID, KOD, NAME FROM COMPETENCE, Competence_Discipline " +
                "WHERE ID = ID_competence AND ID_discipline = @id_disp";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_spec", id_specialization);
            command.Parameters.AddWithValue("@id_disp", id_work_programm);
            ManagerDataCompChosenDiscipline.LoadData(command);
            dataGridCompChosenDiscip.Columns["ID"].Visible = false;
            dataGridCompChosenDiscip.Columns["KOD"].HeaderText = "Код";
            dataGridCompChosenDiscip.Columns["NAME"].HeaderText = "Содержание компетенции";
            dataGridCompChosenDiscip.Columns["NAME"].Width = 400;
        }

        // загружает список дисциплин, которые формируют выбранную компетенцию
        private void LoadDisciplineChosenCompetence(long id_specialization)
        {
            ManagerDataDisciplineChosenCompetence.Close();
            long id_competence = Convert.ToInt64(dataGridDisciplineChosenCompetence.Tag);
            LoadDisciplineChosenCompetence(id_competence, id_specialization);
            SQLiteCommand commandUpdate = new SQLiteCommand("UPDATE Competence_Discipline SET Weight = @param WHERE ID_discipline = @id_disp AND ID_competence = @id_comp");
            SQLiteCommand commandDelete = new SQLiteCommand(" ");
            SQLiteParameter parameter1 = new SQLiteParameter("@param", DbType.Double, "Weight");
            SQLiteParameter parameter2 = new SQLiteParameter("@id_disp", DbType.Int64, "ID_discipline");
            parameter2.SourceVersion = DataRowVersion.Original;
            SQLiteParameter parameter3 = new SQLiteParameter("@id_comp", id_competence);
            commandUpdate.Parameters.Add(parameter1);
            commandUpdate.Parameters.Add(parameter2);
            commandUpdate.Parameters.Add(parameter3);
            ManagerDataDisciplineChosenCompetence.InitialCommandDelete(commandDelete);
            ManagerDataDisciplineChosenCompetence.InitialCommandUpdate(commandUpdate);
        }

        // загружает список дисциплин, которые формируют выбранную компетенцию для определённой специализации
        private void LoadDisciplineChosenCompetence(long id_competence, long id_specialization)
        {
            string sqlQuery = "SELECT ID, NameDiscipline, Weight, ID_competence, ID_discipline FROM WorkProgramm, Competence_Discipline " +
                    "WHERE ID = ID_discipline AND ID_competence = @id_comp AND ID_specialization = @id_spec";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_comp", id_competence);
            command.Parameters.AddWithValue("@id_spec", id_specialization);
            ManagerDataDisciplineChosenCompetence.LoadData(command);
            dataGridDisciplineChosenCompetence.Columns["ID"].Visible = false;
            dataGridDisciplineChosenCompetence.Columns["ID_competence"].Visible = false;
            dataGridDisciplineChosenCompetence.Columns["ID_discipline"].Visible = false;
            dataGridDisciplineChosenCompetence.Columns["Weight"].HeaderText = "Вес";
            dataGridDisciplineChosenCompetence.Columns["NameDiscipline"].HeaderText = "Название дисциплины";
            dataGridDisciplineChosenCompetence.Columns["NameDiscipline"].Width = 400;
            dataGridDisciplineChosenCompetence.Columns["NameDiscipline"].ReadOnly = true;
        }

        public void AddCompetenceChosenDiscipline(System.Collections.ArrayList ListDataGridRow)
        {
            if (ListDataGridRow == null || ListDataGridRow.Count == 0)
                return;
            BindingSource bind = (BindingSource)dataGridCompChosenDiscip.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            for (int i = 0; i < ListDataGridRow.Count; i++)
            {
                bool flag_add = true;
                DataGridViewRow rowAdd = (DataGridViewRow)ListDataGridRow[i];
                foreach (DataGridViewRow rowCurrent in dataGridCompChosenDiscip.Rows)
                {
                    if (Convert.ToInt64(rowCurrent.Cells["ID"].Value) == Convert.ToInt64(rowAdd.Cells["ID"].Value))
                    {
                        flag_add = false;
                        break;
                    }
                }
                if (flag_add)
                {
                    // добавляем компетенцию в дата грид
                    DataRow row = table.NewRow();
                    row["ID"] = rowAdd.Cells["ID"].Value;
                    row["KOD"] = rowAdd.Cells["KOD"].Value;
                    row["NAME"] = rowAdd.Cells["NAME"].Value;
                    table.Rows.Add(row);
                    row.AcceptChanges();
                    dataGridCompChosenDiscip.Refresh();
                    // теперь сохраним в базу новую связь дисциплина-компетенция
                    SQLiteManager.InsertValue("Competence_Discipline", new string[] { "ID_competence", "ID_discipline" },
                        new object[] { rowAdd.Cells["ID"].Value, dataGridCompChosenDiscip.Tag });
                }
            }
        }

        private void LoadCompetence()
        {
            // дата грид компетенций хранит в Теге узел, для которого отображается информация
            TreeNode nodeDataDisplay = (TreeNode)dataGridViewComp.Tag;
            if (currentNode == nodeDataDisplay)
                return;
            dataGridViewComp.Tag = currentNode;
            panelCompetence.Enabled = true;
            if (currentNode.Level == 0)
            {
                LoadCompetence(currentNode.Tag.ToString());
                label2.Text = "Компетенции по специальности " + currentNode.Text;
            }
            else
            {
                LoadCompetence(currentNode.Parent.Tag.ToString(), (long)currentNode.Tag);
                label2.Text = "Компетенции по специализации " + currentNode.Text;
            }
        }
        // загружает компетенции для специализации
        private void LoadCompetence(string id_specialty, long id_specialization)
        {
            string sqlQuery = "SELECT * FROM COMPETENCE WHERE ID_specialty = @id_specialty AND (ID_specialization IS NULL OR ID_specialization = @id_specialization)"; 
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_specialty", id_specialty);
            command.Parameters.AddWithValue("@id_specialization", id_specialization);
            ManagerDataCompetence.LoadData(command);
            SetOptionGridComp();
        }
        // загружает компетенции для специальности
        private void LoadCompetence(string id_specialty)
        {
            string sqlQuery = "SELECT * FROM COMPETENCE WHERE id_specialty = @id_param";
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_param", id_specialty);
            ManagerDataCompetence.LoadData(command);
            SetOptionGridComp();
        }

        private void SetOptionGridComp()
        {
            if (dataGridViewComp.Columns.Count == 0)
                return;
            dataGridViewComp.Columns["ID"].Visible = false;
            dataGridViewComp.Columns["id_specialization"].Visible = false;
            dataGridViewComp.Columns["id_specialty"].Visible = false;
            dataGridViewComp.Columns["Name"].HeaderText = "Содержание компетенции";
            dataGridViewComp.Columns["Name"].Width = 400;
            dataGridViewComp.Columns["Name"].DisplayIndex = 1;
            dataGridViewComp.Columns["KOD"].HeaderText = "Код";
            dataGridViewComp.Columns["KOD"].DisplayIndex = 0;
        }

        private void FormDisciplineAndCompetence_Load(object sender, EventArgs e)
        {
            LoadTree();
        }
        // ........ ОБРАБОТЧИК ВЫДЕЛЕНИЯ УЗЛА ДЕРЕВА .........
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            ManagerDataDisciplineChosenCompetence.Close();
            label4.Text = "Выберите специализацию";
            buttonSaveDiscipChosenComp.Enabled = false;
            currentNode = selectedNode;
            if (tabControl1.TabPages[tabControl1.SelectedIndex] == tabDiscipline)
                LoadDiscipline();
            else
                LoadCompetence();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages[tabControl1.SelectedIndex] == tabDiscipline)
                LoadDiscipline();
            else
                LoadCompetence();
        }

        private void DeleteRowInDataGrid(DataGridView dataGridView, string textMessage)
        {
            if (dataGridView.SelectedRows == null || dataGridView.SelectedRows.Count == 0)
                return;
            if (!IsDeleteRowCheck(textMessage))
                return;
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
        }

        private void buttonAddDis_Click(object sender, EventArgs e)
        {
            TreeNode nodeDisplay = (TreeNode)dataGridViewDiscip.Tag;
            FormAddDiscipline form = new FormAddDiscipline(this, nodeDisplay.Parent.Text, nodeDisplay.Text, (long)nodeDisplay.Tag);
            form.ShowDialog();
        }

        private void buttonDeleteComp_Click(object sender, EventArgs e)
        {
            DeleteRowInDataGrid(dataGridViewComp, "Вы уверены что хотите удалить данную компетенцию?");
        }

        private bool IsDeleteRowCheck(string text)
        {
            DialogResult result = MessageBox.Show(text, "Вы уверены", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void buttonDeleteDis_Click(object sender, EventArgs e)
        {
            DeleteRowInDataGrid(dataGridViewDiscip, "Вы уверены что хотите удалить данную дисциплину?");
        }

        private void dataGridViewDiscip_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewDiscip.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck("Вы уверены что хотите удалить данную дисциплину?"))
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private void buttonSaveDis_Click(object sender, EventArgs e)
        {
            ManagerDataDiscipline.SaveDataGrid();
        }

        public void AddDisciplineInDataGrid(string text, object rowid, long id_specialization, string semester)
        {
            BindingSource bind = (BindingSource)dataGridViewDiscip.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row["NameDiscipline"] = text;
            row["ID"] = rowid;
            row["id_specialization"] = id_specialization;
            row["Semester"] = semester;
            table.Rows.Add(row);
            row.AcceptChanges();
            dataGridViewDiscip.Refresh();
        }

        public void AddCompetenceInDataGrid(string Name, string kod, object rowid, string kod_specialty, long id_spec)
        {
            BindingSource bind = (BindingSource)dataGridViewComp.DataSource;
            DataTable table = (DataTable)bind.DataSource;
            DataRow row = table.NewRow();
            row["Name"] = Name;
            row["KOD"] = kod;
            row["ID"] = rowid;
            row["id_specialty"] = kod_specialty;
            row["id_specialization"] = id_spec;
            table.Rows.Add(row);
            row.AcceptChanges();
            dataGridViewComp.Refresh();
        }

        private void buttonAddComp_Click(object sender, EventArgs e)
        {
            TreeNode nodeDisplay = (TreeNode)dataGridViewComp.Tag;
            FormAddCompetence form;
            if (nodeDisplay.Level == 0)
            {   // добавляем профессиональную компетенцию
                string kodSpecialty = nodeDisplay.Tag.ToString();
                form = new FormAddCompetence(this, nodeDisplay.Text, kodSpecialty);                
            }
            //else if (nodeDisplay.Parent != null && nodeDisplay.Nodes.Count == 1)
            //{   
            //    string kodSpecialty = nodeDisplay.Parent.Tag.ToString();
            //    form = new FormAddCompetence(this, nodeDisplay.Parent.Text, kodSpecialty);
            //}
            else
            {   // добавляем компетенцию специализации
                string kodSpecialty = nodeDisplay.Parent.Tag.ToString();
                long id_specialization = Convert.ToInt64(nodeDisplay.Tag);
                form = new FormAddCompetence(this, nodeDisplay.Parent.Text, nodeDisplay.Text, kodSpecialty, id_specialization);
            }
            form.ShowDialog();
        }

        private void dataGridViewComp_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewComp.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck("Вы уверены что хотите удалить данную компетенцию?"))
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private void buttonSaveComp_Click(object sender, EventArgs e)
        {
            ManagerDataCompetence.SaveDataGrid();
        }

        private void dataGridViewDiscip_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string temp = dataGridViewDiscip[e.ColumnIndex, e.RowIndex].Value.ToString();
                bool flag_exit = false;
                if (String.IsNullOrWhiteSpace(temp))
                    flag_exit = true;
                if (e.ColumnIndex == dataGridViewDiscip.Columns["NameDiscipline"].Index && flag_exit)
                {   // название дисциплины
                    MessageBox.Show("Название дисциплины не может быть пустым!", "Ошибка редактирования");
                    dataGridViewDiscip.CancelEdit();
                    return;
                }
                else if (e.ColumnIndex == dataGridViewDiscip.Columns["Semester"].Index)
                {
                    string[] element = temp.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (element == null || element.Length == 0)
                        flag_exit = true;
                    else
                    {
                        foreach (string str in element)
                        {
                            int value = Convert.ToInt32(str.Trim());
                            if (value < 1 || value > 10)
                            {
                                flag_exit = true;
                                break;
                            }
                        }
                    }
                }
                if (flag_exit)
                {
                    MessageBox.Show("Ячейка семестров должна содержать перечисление семестров отчётности с разделителем \';\'.", "Ошибка редактирования");
                    dataGridViewDiscip.CancelEdit();
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Ячейка семестров должна содержать перечисление семестров отчётности с разделителем \';\'.", "Ошибка редактирования");
                dataGridViewDiscip.CancelEdit();
            }
        }

        private void dataGridViewDiscip_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridViewDiscip.SelectedRows == null || dataGridViewDiscip.SelectedRows.Count == 0)
            //    return;
            //DataGridViewRow row = dataGridViewDiscip.SelectedRows[0];
            //label3.Text = "Компетенции, формируемые дисциплиной " + row.Cells["NameDiscipline"].Value.ToString();
            //// сохраняем Айди дисциплины, для которой мы грузим компетенции
            //dataGridCompChosenDiscip.Tag = row.Cells["ID"].Value;  
            //LoadCompetenceChosenDiscipline(row);
            //panel1.Enabled = true;
        }

        private void buttonSaveCompChosenDisp_Click(object sender, EventArgs e)
        {
            ManagerDataCompChosenDiscipline.SaveDataGrid();
        }

        private void FormDisciplineAndCompetence_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManagerDataCompChosenDiscipline.Close();
            ManagerDataCompetence.Close();
            ManagerDataDiscipline.Close();
        }

        private void buttonAddCompetenceToDiscip_Click(object sender, EventArgs e)
        {
            TreeNode node = (TreeNode)dataGridViewDiscip.Tag;
            long id_specialization = Convert.ToInt64(node.Tag);
            string id_specialty = node.Parent.Tag.ToString();
            string nameSpecialty = node.Parent.Text;
            string nameSpecialization = node.Text;
            FormAddCompetenceToDiscipline form = new FormAddCompetenceToDiscipline(this, nameSpecialty, nameSpecialization, id_specialty, id_specialization);
            form.ShowDialog();
        }

        private void buttonDelCompetenceFromDiscip_Click(object sender, EventArgs e)
        {
            DeleteRowInDataGrid(dataGridCompChosenDiscip, "Вы уверены что хотите удалить данную компетенцию из списка компетенций дисциплины?");
        }

        private void dataGridCompChosenDiscip_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridCompChosenDiscip.Rows.Count == 0)
                return;
            if (IsDeleteRowCheck("Вы уверены что хотите удалить данную компетенцию из списка компетенций дисциплины?"))
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        private void dataGridViewComp_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewComp.SelectedRows == null || dataGridViewComp.SelectedRows.Count == 0)
                return;
            ManagerDataDisciplineChosenCompetence.Close();
            label4.Text = "Дисциплины, формирующие компетенцию";
            long id_comp = Convert.ToInt64(dataGridViewComp.SelectedRows[0].Cells["ID"].Value);
            // сохраняем в дата грид айди компетенции, для которой будут загружены данные
            dataGridDisciplineChosenCompetence.Tag = id_comp;
            // определим айди специализации, к которой эта компетенция принадлежит
            // Если узел, для которого отображаются компетенции, равен 0, тогда ничего отображать не будем!!!
            TreeNode node = (TreeNode)dataGridViewComp.Tag;
            if (node.Level == 0)
            {   // специализация не задана               
                string kodSpec;
                if (node.Level == 1)
                    kodSpec = node.Parent.Tag.ToString();
                else
                    kodSpec = node.Tag.ToString();
                label4.Text = "Выберите специализацию";
                buttonSaveDiscipChosenComp.Enabled = false;
                //InitialComboBoxSpecialization(kodSpec);
            }
            else
            {   // специализация задана и хранится в Таге узла
                buttonSaveDiscipChosenComp.Enabled = true;
                long id_specialization = Convert.ToInt64(node.Tag);
                // загружаем данные в дата грид
                LoadDisciplineChosenCompetence(id_specialization);
                label4.Text = "Дисциплины, формирующие компетенцию " + dataGridViewComp.SelectedRows[0].Cells["KOD"].Value.ToString();
            }
        }

        private void buttonSaveDiscipChosenComp_Click(object sender, EventArgs e)
        {
            if (dataGridDisciplineChosenCompetence.Rows.Count == 0)
                return;
            double sum = 0;
            double[] weightValue = new double[dataGridDisciplineChosenCompetence.Rows.Count];
            int i = -1;
            foreach (DataGridViewRow row in dataGridDisciplineChosenCompetence.Rows)
            {
                weightValue[++i] = Convert.ToDouble(row.Cells["Weight"].Value);
                sum += weightValue[i];
            }
            if (sum == 0)
            {   // если сумма 0, значит нужно задать равные веса
                for (int k = 0; k < weightValue.Length; k++)
                    weightValue[k] = 1.0 / weightValue.Length;
            }
            else if (Math.Abs(sum - 1) > 0.001)
            {   // если сумма не равна 1, значит нужно нормировать
                for (int k = 0; k < weightValue.Length; k++)
                    weightValue[k] = weightValue[k] / sum;
            }
            // сохраняем данные
            for (int k = 0; k < dataGridDisciplineChosenCompetence.Rows.Count; k++)
                dataGridDisciplineChosenCompetence.Rows[k].Cells["Weight"].Value = weightValue[k];
            ManagerDataDisciplineChosenCompetence.SaveDataGrid();
        }

        private void dataGridDisciplineChosenCompetence_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string temp = dataGridDisciplineChosenCompetence[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (String.IsNullOrWhiteSpace(temp))
                {
                    dataGridDisciplineChosenCompetence[e.ColumnIndex, e.RowIndex].Value = 0.0;
                    return;
                }
                double value = Convert.ToDouble(dataGridDisciplineChosenCompetence[e.ColumnIndex, e.RowIndex].Value);
                if (value < 0)
                    dataGridDisciplineChosenCompetence.CancelEdit();
            }
            catch 
            {
                MessageBox.Show("Допускается заполнять веса только положительными вещественными числами", "Ошибка редактирования");
                dataGridDisciplineChosenCompetence.CancelEdit();
            }
        }

        private void dataGridViewDiscip_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewDiscip.CurrentCell == null)
                return;
            DataGridViewRow row = dataGridViewDiscip.Rows[dataGridViewDiscip.CurrentCell.RowIndex];
            if (dataGridCompChosenDiscip.Tag != null && dataGridCompChosenDiscip.Tag.ToString() == row.Cells["ID"].Value.ToString())
                return;
            label3.Text = "Компетенции, формируемые дисциплиной " + row.Cells["NameDiscipline"].Value.ToString();
            // сохраняем Айди дисциплины, для которой мы грузим компетенции
            dataGridCompChosenDiscip.Tag = row.Cells["ID"].Value;
            LoadCompetenceChosenDiscipline(row);
            panel1.Enabled = true;
        }

        private void dataGridViewComp_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewComp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewComp[e.ColumnIndex, e.RowIndex].Value == null)
                dataGridViewComp.CancelEdit();
            else if (String.IsNullOrWhiteSpace(dataGridViewComp[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                dataGridViewComp.CancelEdit();
                MessageBox.Show("Ячеяка не может быть пустой!", "Ошибка редактирования");
            }
        }

        private void dataGridDisciplineChosenCompetence_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridDisciplineChosenCompetence.CancelEdit();
        }
        
    }
}
