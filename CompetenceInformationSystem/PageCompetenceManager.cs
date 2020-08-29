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
    class PageCompetenceManager
    {
        TabPage page;
        DataGridView dataGrid;
        RichTextBox textState;
        Label label;
        ComboBox comboBoxSpecialization;
        DataListManager managerSpecialization;
        string kod_specialty;
        public bool IsSpecNeed;
        string currentCellValue;
        // показывает готовность к сохранению
        public bool IsDataCorrect = true;
        public bool IsSpecializationChoose = false;

        public PageCompetenceManager(TabPage page, string kod_specialty, string[,] competenceArray, bool IsSpecNeed)
        {
            this.page = page;
            this.kod_specialty = kod_specialty;
            this.IsSpecNeed = IsSpecNeed;
            if (!IsSpecNeed)
                IsSpecializationChoose = true;
            InitialComponents();
            managerSpecialization = new DataListManager("SPECIALIZATION", new string[] { "ID", "NUMBER", "NAME" });
            InitialComboBoxSpecialization();
            LoadData(competenceArray);
        }

        private void InitialComponents()
        {
            CreateLabel();
            CreateDataGrid();
            CreateComboBoxSpecialization();
            CreateTextStateBox();
        }

        private void LoadData(string[,] competenceArray)
        {
            InitialDataGrid(competenceArray);
            CheckCorrectData();
            UpdateState();
        }

        private void InitialDataGrid(string[,] competenceArray)
        {
            if (competenceArray == null || competenceArray.GetLength(0) == 0)
                return;
            for (int i = 0; i < competenceArray.GetLength(0); i++)
            {
                // код и содержание компетенции
                dataGrid.Rows.Add(new object[] { competenceArray[i, 0], competenceArray[i, 1] });
            }
        }

        private void InitialComboBoxSpecialization()
        {
            comboBoxSpecialization.Items.Clear();
            string sqlQuery = "SELECT * FROM SPECIALIZATION WHERE SPECIALTY_fk = @kod ORDER BY NAME";
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(sqlQuery);
            command.Parameters.AddWithValue("@kod", kod_specialty);
            if (!managerSpecialization.LoadData(command))
                return;
            managerSpecialization.GetDataInComboBox(comboBoxSpecialization, "NAME");
        }

        private void CheckCorrectData()
        {           
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT EXISTS(SELECT ID FROM COMPETENCE WHERE ID_specialty = @id_spec AND KOD = @kod)";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@kod", DbType.String));
            command.Parameters.AddWithValue("@id_spec", kod_specialty);
            SQLiteDataReader reader;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                command.Parameters[0].Value = dataGrid.Rows[i].Cells[0].Value.ToString();
                reader = command.ExecuteReader();
                if (reader.Read() && reader[0].ToString() == "1")
                {   // если в БД уже есть такая компетенция
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    // строка не готова к загрузке в базу
                    dataGrid.Rows[i].Tag = false;
                }
                else
                    dataGrid.Rows[i].Tag = true;
                reader.Close();
            }
            connection.Close();
        }

        private bool CheckCorrectDataForEdit(string value_kod)
        {
            return SQLiteManager.IsExistValue("COMPETENCE", new string[] { "ID_specialty", "KOD" }, new string[] { kod_specialty, value_kod }); 
        }

        #region Создание элементов формы
        private void CreateDataGrid()
        {
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewTextBoxColumn KOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {KOD, Name});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(18, 128);
            this.dataGrid.Name = "dataGridView1";
            //this.dataGrid.Size = new System.Drawing.Size(761, 286);
            this.dataGrid.Size = new System.Drawing.Size((int)(0.9 * page.Size.Width), page.Size.Height - dataGrid.Location.Y - 5);
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGrid.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            dataGrid.KeyUp +=new KeyEventHandler(dataGridView1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            page.Controls.Add(dataGrid);
        }

        private void CreateTextStateBox()
        {
            textState = new RichTextBox();
            textState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            textState.Location = new System.Drawing.Point(comboBoxSpecialization.Location.X + comboBoxSpecialization.Width + 40, 10);
            textState.Name = "richTextBox1";
            //textState.Size = new System.Drawing.Size(332, 77);
            textState.Size = new System.Drawing.Size((int)(0.5 * page.Width), dataGrid.Location.Y - textState.Location.Y - 20);
            textState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            textState.ReadOnly = true;
            if (IsSpecNeed)
                textState.Text = "Выберите специализацию из выпадающего списка, к которой будут отнесены компетенции";
            else
                textState.Text = "Данные готовы к загрузке";
            page.Controls.Add(textState);
        }

        private void CreateComboBoxSpecialization()
        {
            comboBoxSpecialization = new ComboBox();
            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(18, 45);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            //this.comboBoxSpecialization.Size = new System.Drawing.Size(395, 25);
            this.comboBoxSpecialization.Size = new System.Drawing.Size((int) (0.4*page.Width), 25);
            this.comboBoxSpecialization.TabIndex = 4;
            this.comboBoxSpecialization.SelectedIndexChanged +=new EventHandler(comboBoxSpecialization_SelectedIndexChanged4);
            if(!IsSpecNeed)
                comboBoxSpecialization.Enabled = false;
            page.Controls.Add(comboBoxSpecialization);
        }

        private void CreateLabel()
        {
            label = new Label();
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label.Location = new System.Drawing.Point(14, 22);
            this.label.Name = "label3";
            this.label.Size = new System.Drawing.Size(140, 20);
            this.label.TabIndex = 3;
            this.label.Text = "Специализация";
            page.Controls.Add(label);
        }

        #endregion

        private void UpdateState()
        {
            IsDataCorrect = true;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dataGrid.Rows[i].Tag))
                {
                    IsDataCorrect = false;
                    break;
                }
            }
            if (!IsSpecializationChoose)
                textState.Text = "Выберите специализацию из выпадающего спика";
            else if (IsDataCorrect)
                textState.Text = "Данные готовы к загрузке";
            else
                textState.Text = "Загрузка невозможна. В таблице присутствуют компетенции, которые уже загружены в базу. Они подсвечены жёлтым, удалите их или переименуйте.";
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
                    if (CheckCorrectDataForEdit(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    {
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        dataGrid.Rows[e.RowIndex].Tag = false;                        
                    }
                    else
                    {
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dataGrid.Rows[e.RowIndex].Tag = true;
                    }
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

        private void comboBoxSpecialization_SelectedIndexChanged4(object sender, EventArgs e)
        {
            IsSpecializationChoose = true;
            UpdateState();
        }

        public void Save()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sql;
            if (IsSpecNeed) // если специализация должна быть указана
                sql = "INSERT INTO COMPETENCE(NAME, KOD, ID_SPECIALTY, ID_SPECIALIZATION) VALUES(@name, @kod, @id_spec, @id_specialization)";
            else
                sql = "INSERT INTO COMPETENCE(NAME, KOD, ID_SPECIALTY) VALUES(@name, @kod, @id_spec)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.Add(new SQLiteParameter("@name", DbType.String));
            command.Parameters.Add(new SQLiteParameter("@kod", DbType.String));
            command.Parameters.AddWithValue("@id_spec", kod_specialty);     
            if (IsSpecNeed)
                command.Parameters.AddWithValue("@id_specialization", Convert.ToInt64(managerSpecialization.GetCellValue(comboBoxSpecialization.SelectedIndex, "ID"))); 
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                command.Parameters[0].Value = dataGrid.Rows[i].Cells[1].Value.ToString();
                command.Parameters[1].Value = dataGrid.Rows[i].Cells[0].Value.ToString();
                command.ExecuteNonQuery();
            }
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

        //// возвращает ОТКРЫТОЕ соединение
        //static public SQLiteConnection CreateConnection()
        //{
        //    string path = @"CompetenceDB.db";   // пусть к файлу с базой
        //    string ConnectionString = "Data Source=" + path + ";Version=3;";
        //    SQLiteConnection connection = new SQLiteConnection(ConnectionString);
        //    connection.Open();
        //    SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection);
        //    command.ExecuteNonQuery();
        //    return connection;
        //}

        //// принимает на вход запрос типа "SELECT COUNT(*) FROM equipment" и возвращает результат
        //private string GetCountOBJ(string sqlQuery)
        //{
        //    SQLiteCommand cmd = new SQLiteCommand(sqlQuery);
        //    SQLiteConnection connection = CreateConnection();
        //    cmd.Connection = connection;
        //    string result = cmd.ExecuteScalar().ToString();
        //    connection.Close();
        //    return result;
        //    //ХОЧУ функцию, которая на вход получает запрос (например, "SELECT COUNT(*) FROM equipment") 
        //    //и возвращает мне результат-число (хоть стрингом, хить интом) 
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    string res_all = GetCountOBJ("SELECT COUNT(*) FROM equipment");
        //    CountObjAll.Text = Convert.ToString(res_all);
        //    //(ниже нужен тот самый string sqlSelect из private void Apply_Click) 
        //    string res_filter = GetCountOBJ("SELECT COUNT(*) FROM equipment WHERE ...");
        //    CountObjFilter.Text = Convert.ToString(res_filter);
        //}

    }
}
