using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace CompetenceInformationSystem
{
    class PageWorkPlanManager
    {
        TabPage page;
        DataGridView dataGrid;
        Label label3;
        ComboBox comboBoxDiscipline;
        DataListManager managerDiscipline;
        string currentCellValue;
        long id_specialization;
        string kod_specialty;
        string nameDiscipline;
        public string fileName;
        public bool IsDisciplineChoosen;
        public bool IsDataCorrect;

        public PageWorkPlanManager(string fileName, string nameDiscipline, TabPage page, string kod_specialty, long id_specialization, string[] competenceKodArray)
        {
            this.page = page;
            this.kod_specialty = kod_specialty;
            this.id_specialization = id_specialization;
            this.nameDiscipline = nameDiscipline;
            this.fileName = fileName;
            managerDiscipline = new DataListManager("WorkProgramm", new string[] { "ID", "NameDiscipline", "ID_specialization", "Semester", "FormReport"});
            InitialComponents(fileName);
            LoadData(competenceKodArray);
        }

        private void InitialComponents(string fileName)
        {
            CreateLabel(fileName);
            CreateComboBoxDiscipline();
            CreateDataGrid();
        }

        // ......................................................
        #region Создание элементов формы
        private void CreateComboBoxDiscipline()
        {
            this.comboBoxDiscipline = new ComboBox();
            this.comboBoxDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(13, 47);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size((int) (0.7 * page.Width), 25);
            this.comboBoxDiscipline.TabIndex = 6;
            this.comboBoxDiscipline.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            page.Controls.Add(comboBoxDiscipline);
        }

        private void CreateDataGrid()
        {
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewTextBoxColumn KOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Name.ReadOnly = true;
            KOD.HeaderText = "Код";
            KOD.Name = "KOD";
            Name.HeaderText = "Содержание компетенции";
            Name.Name = "Name";
            Name.Width = 600;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { KOD, Name });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(13, 90);
            this.dataGrid.Name = "dataGridView1";
            this.dataGrid.Size = new System.Drawing.Size((int)(0.95 * page.Width), (int)(0.8 * page.Height));
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGrid.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            dataGrid.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            page.Controls.Add(dataGrid);
        }

        private void CreateLabel(string fileName)
        {
            label3 = new Label();
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = fileName;
            page.Controls.Add(label3);
        }

        #endregion
        // ......................................................

        private void LoadData(string[] competenceKodArray)
        {
            InitialComboBoxDiscipline();
            InitialDataGrid(competenceKodArray);
            CheckCorrectNameDiscipline();
            CheckCorrectData();
            UpdateState();
        }

        private void UpdateState()
        {
            IsDataCorrect = true;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (Convert.ToInt64(dataGrid.Rows[i].Tag) == -1)
                {
                    IsDataCorrect = false;
                    break;
                }
            }
        }

        private void InitialDataGrid(string[] competenceKodArray)
        {
            if (competenceKodArray == null || competenceKodArray.Length == 0)
                return;
            for (int i = 0; i < competenceKodArray.Length; i++)
            {
                // код и содержание компетенции
                dataGrid.Rows.Add(new object[] { competenceKodArray[i], "" });
            }
        }

        private void InitialComboBoxDiscipline()
        {
            comboBoxDiscipline.Items.Clear();
            string sqlQuery = "SELECT * FROM WorkProgramm WHERE ID_specialization = @id_spec ORDER BY NameDiscipline";
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@id_spec", id_specialization);
            if (!managerDiscipline.LoadData(command))
                return;
            managerDiscipline.GetDataInComboBox(comboBoxDiscipline, "NameDiscipline");
        }

        private void CheckCorrectNameDiscipline()
        {
            if (String.IsNullOrWhiteSpace(nameDiscipline))
            {
                IsDisciplineChoosen = false;
                return;
            }
            // определяет индекс дисциплины в выпадающем списке, если она найдена в БД по названию из файла
            int index = managerDiscipline.GetIndex("NameDiscipline", nameDiscipline.Trim());
            if (index == -1)
            {
                IsDisciplineChoosen = false;
                return;
            }
            IsDisciplineChoosen = true;
            comboBoxDiscipline.SelectedIndex = index;
        }

        public void Save()
        {
            long id_discipline = Convert.ToInt64(managerDiscipline.GetCellValue(comboBoxDiscipline.SelectedIndex, "ID"));
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sql = "INSERT INTO Competence_Discipline(ID_competence, ID_discipline) VALUES(@id_comp, @id_disp)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.Add(new SQLiteParameter("@id_comp", DbType.Int64));
            command.Parameters.AddWithValue("@id_disp", id_discipline);            
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                command.Parameters[0].Value = Convert.ToInt64(dataGrid.Rows[i].Tag);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void CheckCorrectData()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT ID, NAME FROM COMPETENCE WHERE ID_specialty = @id_spec AND KOD = @kod";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@kod", DbType.String));
            command.Parameters.AddWithValue("@id_spec", kod_specialty);
            SQLiteDataReader reader;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                command.Parameters[0].Value = dataGrid.Rows[i].Cells[0].Value.ToString();
                reader = command.ExecuteReader();
                if (reader.Read())
                {   // если в БД есть такая компетенция                    
                    dataGrid.Rows[i].Tag = Convert.ToInt64(reader[0]);
                    dataGrid.Rows[i].Cells[1].Value = reader[1].ToString();
                }
                else
                {   // компетенция не найдена в БД
                    dataGrid.Rows[i].Tag = -1;
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }                   
                reader.Close();
            }
            connection.Close();
        }

        private void CheckCorrectDataForEdit(string value_kod, int index_row)
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT ID, NAME FROM COMPETENCE WHERE ID_specialty = @id_spec AND KOD = @kod";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.AddWithValue("@kod", value_kod);
            command.Parameters.AddWithValue("@id_spec", kod_specialty);
            SQLiteDataReader reader;
            reader = command.ExecuteReader();
            if (reader.Read())
            {   // если в БД есть такая компетенция                    
                dataGrid.Rows[index_row].Tag = Convert.ToInt64(reader[0]);
                dataGrid.Rows[index_row].Cells[1].Value = reader[1].ToString();
                dataGrid.Rows[index_row].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {   // компетенция не найдена в БД
                dataGrid.Rows[index_row].Tag = -1;
                dataGrid.Rows[index_row].DefaultCellStyle.BackColor = Color.Yellow;
            }
            reader.Close();            
            connection.Close();            
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGrid.CurrentCell != null)
                {
                    dataGrid.Rows.RemoveAt(dataGrid.CurrentCell.RowIndex);
                    UpdateState();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGrid[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = currentCellValue;
                }
                else if (String.IsNullOrWhiteSpace(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("Ячейка не может быть пустой.", "Ошибка редактирования");
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = currentCellValue;
                }
                else if (e.ColumnIndex == 0)
                {
                    CheckCorrectDataForEdit(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), e.RowIndex);
                    UpdateState();
                }
            }
            catch
            {
                MessageBox.Show("Данная операция запрещена", "Ошибка редактирования");
                dataGrid[e.ColumnIndex, e.RowIndex].Value = currentCellValue;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGrid[e.ColumnIndex, e.RowIndex].Value == null)
                currentCellValue = "";
            else
                currentCellValue = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDisciplineChoosen = true;
        }
    }
}
