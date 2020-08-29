using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;

namespace CompetenceInformationSystem
{
    /// <summary>
    /// Класс, формирующий элемент Page страницы excel с данными о слушателях и оценках
    /// </summary>
    public class PageGroupManager
    {
        TabPage page;
        DataGridView dataGrid;
        RichTextBox textState;
        Button buttonDiscipline;
        Button buttonStudent;
        Button buttonSave;
        Label label;
        CheckBox checkBox;
        RatingGroup ratingGroup;
        SuperTabControl parentControl;
        string currentCellValue = "";
        // показывает, можно ли загружать данные в дата грид и остальные элементы
        bool IsRatingNotNull = false;
        // если работаем с весенним семестром
        bool IsSpringTime;
        // есди данные готовы к загрузке в БД
        bool IsStudentCorrect = true;
        bool IsDisciplineCorrect = true;
        // если есть слушатели, для которых оценки за текущий семестер уже загружены
        bool IsExistDataUpdate = false;
        long id_specialization;
        long id_group;
        int semester;

        public PageGroupManager(TabPage page)
        {
            this.page = page;
            InitializeComponent();
        }

        public PageGroupManager(TabPage page, RatingGroup ratingGroup, bool IsSpringTime, SuperTabControl parentControl)
        {
            this.parentControl = parentControl;
            this.page = page;
            this.ratingGroup = ratingGroup;
            this.IsSpringTime = IsSpringTime;
            this.id_specialization = ratingGroup.id_specialization;
            this.id_group = ratingGroup.id_group;
            InitializeComponent();
            if (IsRatingNotNull)
            {
                if (IsSpringTime)
                    semester = Program.GetNumKurs(ratingGroup.NameGroup) * 2;
                else
                    semester = Program.GetNumKurs(ratingGroup.NameGroup) * 2 - 1;
                LoadData();
            }
        }

        private void InitializeComponent()
        {
            if (!ratingGroup.IsGroupExistInDatabase || !ratingGroup.IsDataLoaded)
            {   // группа не существует в БД, поэтому отображаем на экране сообщение об этом
                Label labelInfo = new Label();              
                labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
                labelInfo.Location = new Point(page.Parent.Location.X, page.Parent.Location.Y - 20);
                labelInfo.Size = new Size(1000, 30);
                if (!ratingGroup.IsGroupExistInDatabase)
                    labelInfo.Text = "Группа \'" + page.Text + "\' не существует в базе данных. Загрузка данных невозможна.";
                else
                    labelInfo.Text = "В ходе загрузки данных группы " + page.Text + " произошла ошибка. Проверьте корректность данных.";
                page.Controls.Add(labelInfo);
                return;
            }
            IsRatingNotNull = true;
            CreateDataGrid();
            CreateButtonSaveAndLabel();
            CreateCheckBox();
            CreateTextState();
            CreateButtonDiscipline();
            CreateButtonStudent();
        }

        /// <summary>
        /// Загружает данные в компоненты страницы (дата грид, окно информации и чек бокс)
        /// </summary>
        private void LoadData()
        {
            InitialDataGrid();
            CheckCorrectAllData();           
        }

        /// <summary>
        /// Добавляет источник данных, загруженный из excel
        /// </summary>
        private void InitialDataGrid()
        {
            DataTable tab = ratingGroup.table;
            for (int i = 0; i < tab.Columns.Count; i++)
                dataGrid.Columns.Add(tab.Columns[i].ColumnName, tab.Columns[i].ColumnName);
            for (int i = 0; i < tab.Rows.Count; i++)
                dataGrid.Rows.Add(tab.Rows[i].ItemArray);
            for (int i = 0; i < dataGrid.Columns.Count; i++)
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGrid.Columns[0].Width = 200;
            dataGrid.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        /// <summary>
        /// Проверяет корректность загружаемых данных. Все дисциплины и слушатели должны существовать в БД.
        /// Существование слушателей в БД не требуется, если стоит флаг на чек боксе.
        /// В тегах(TAG) соответствующих столбцов(для дисциплин) и строк(для слушателей) ставится id записи в базе.
        /// Если таких записей не существует - в тег ставится -1.
        /// </summary>
        private void CheckCorrectAllData()
        {
            CheckCorrectStudentData();
            CheckCorrectDisciplineData();
            UpdateState();
        }

        public void UpdateState()
        {
            UpdateStudentState();
            UpdateDisciplineState();
            if (IsDisciplineCorrect && IsStudentCorrect)
            {
                if (!IsExistDataUpdate)
                {   // если данных для обновления нет, то проверим, действительно ли это так
                    // после обновления состояния
                    CheckExistDataInDB();
                    UpdateStudentState();
                }
            }
            if (IsStudentCorrect && IsDisciplineCorrect && !IsExistDataUpdate)
            {   // можно грузить данные
                textState.Text = "Состояние:\nДанные готовы к загрузке в БД.";
            }
            else if (!IsDisciplineCorrect)
            {
                textState.Text = "Состояние: Загрузка невозможна.\nВыделенные оранжевым цветом дисциплины не найдены в БД.\nВозможные варианты действия: " +
                    "Удалите дисциплину из списка загрузки и она не будет загружена. Возможно дисциплина уже есть в базе, но под другим именем, тогда " +
                    "исправьте Название дисциплины в таблице загрузки или перейдите по кнопке \"Список дисциплин в БД\" и добавьте к имени дисциплины новый синоним через \';\'(например: ТВиМС;ТВ и МС).";
            }
            else if (!IsStudentCorrect)
            {
                textState.Text = "Состояние: Загрузка невозможна.\nВыделенные красным цветом слушатели не найдены в БД.\nВозможные варианты действия: " +
                    "Удалите слушателя из списка и он не будет загружен. Поставьте флаг \"Добавить как новых слушателей\" и все помеченные красным слушатели будут загружены как новые. Возможно слушатель уже есть в базе под другим именем, тогда " +
                    "исправьте ФИО в таблице загрузки или перейдите по кнопке \"Список слушателей в БД\" и добавьте к имени слушателя новый синоним через \';\'(например: Иванов И.И.;Иванов).";
            }
            else
            {
                textState.Text = "Состояние: Загрузка невозможна.\nДля выделенных жёлтым цветом слушателей уже найдена информация в БД об оценках за текущий семестер. " +
                    "Удалите слушателей из списка загрузки.";
            }
        }

        public void CheckCorrectStudentData()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT ID FROM STUDENT WHERE ID_group = @id_group AND FIO LIKE @fio";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@id_group", DbType.Int64));
            command.Parameters[0].Value = id_group;
            command.Parameters.Add(new SQLiteParameter("@fio", DbType.String));
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                command.Parameters[1].Value = "%" + dataGrid[0, i].Value.ToString() + "%";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    dataGrid.Rows[i].Tag = Convert.ToInt64(reader[0]);
                else
                    dataGrid.Rows[i].Tag = -1;
                reader.Close();
            }
            connection.Close();
        }

        private void CheckCorrectStudentData(int row_index)
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT ID FROM STUDENT WHERE ID_group = @id_group AND FIO LIKE @fio";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@id_group", DbType.Int64));
            command.Parameters[0].Value = id_group;
            command.Parameters.Add(new SQLiteParameter("@fio", DbType.String));
            SQLiteDataReader reader;
            command.Parameters[1].Value = "%" + dataGrid[0, row_index].Value.ToString() + "%";
            reader = command.ExecuteReader();
            if (reader.Read())
                dataGrid.Rows[row_index].Tag = Convert.ToInt64(reader[0]);
            else
                dataGrid.Rows[row_index].Tag = -1;
            reader.Close();
            connection.Close();
        }

        public void CheckCorrectDisciplineData()
        {
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT ID FROM WorkProgramm WHERE ID_specialization = @id_spec AND NameDiscipline LIKE @name";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@id_spec", DbType.Int64));
            command.Parameters[0].Value = id_specialization;
            command.Parameters.Add(new SQLiteParameter("@name", DbType.String));          
            for (int i = 1; i < dataGrid.Columns.Count; i++)
            {
                command.Parameters[1].Value = "%" + dataGrid.Columns[i].HeaderText + "%";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    dataGrid.Columns[i].Tag = Convert.ToInt64(reader[0]);
                else
                    dataGrid.Columns[i].Tag = -1;
                reader.Close();
            }
            connection.Close();
        }

        /// <summary>
        /// Перерисовывает цвет ячеек студентов и меняет состояние флага готовности загрузки
        /// </summary>
        private void UpdateStudentState()
        {
            IsStudentCorrect = true;
            IsExistDataUpdate = false; 
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                long temp = Convert.ToInt64(dataGrid.Rows[i].Tag);
                if (temp == -1) // студента не существует в БД
                {                   
                    // если метки добавления нового пользователя нет, то ставим флаг некорректности
                    if (checkBox.CheckState != CheckState.Checked)
                    {
                        dataGrid[0, i].Style.BackColor = Color.Red;
                        IsStudentCorrect = false;
                    }
                    else
                        dataGrid[0, i].Style.BackColor = Color.White;
                }
                else if (temp == 0) // данные о студенте в этом семестре уже существуют в БД
                {
                    dataGrid[0, i].Style.BackColor = Color.Yellow;
                    IsExistDataUpdate = true;   // присутствуют слушатели, которых нужно удалить из БД
                }
                else
                    dataGrid[0, i].Style.BackColor = Color.White;
            }           
        }

        private void UpdateDisciplineState()
        {
            IsDisciplineCorrect = true;
            for (int i = 1; i < dataGrid.Columns.Count; i++)
            {
                long temp = Convert.ToInt64(dataGrid.Columns[i].Tag);
                if (temp == -1)
                {
                    dataGrid.Columns[i].DefaultCellStyle.BackColor = Color.Orange;
                    IsDisciplineCorrect = false;
                }
                else
                    dataGrid.Columns[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Проверяет, есть ли для слушателей информация об их успеваемости за этот семестер.
        /// Если есть, то помечает соответствующих слушателей.
        /// </summary>
        private void CheckExistDataInDB()
        {
            IsExistDataUpdate = false;
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            string sqlExist = "SELECT EXISTS(SELECT * FROM Assessment_Discipline WHERE ID_student = @id_stud AND Semester = @sem)";
            SQLiteCommand command = new SQLiteCommand(sqlExist, connection);
            command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
            command.Parameters.Add(new SQLiteParameter("@sem", DbType.Int64));
            command.Parameters[1].Value = semester;
            SQLiteDataReader reader;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                long id_stud = Convert.ToInt64(dataGrid.Rows[i].Tag);
                if (id_stud == -1)
                    continue;
                command.Parameters[0].Value = id_stud;
                reader = command.ExecuteReader();
                if (reader.Read() && reader[0].ToString() == "1")
                {   // если в БД уже есть инфа о слушателе за семестер, то нельзя грузить эти данные
                    dataGrid.Rows[i].Tag = 0;
                    IsExistDataUpdate = true;
                }
                reader.Close();
            }
            connection.Close();
        }

        // .........................................................................
        #region Создание элементов управления
        private void CreateDataGrid()
        {
            dataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            //dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            dataGrid.Location = new Point(page.Parent.Location.X, page.Parent.Location.Y - 20);
            dataGrid.Size = new Size((int) (0.95 * page.Width), (int) (0.6 * page.Height));
            dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGrid.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            //dataGrid.CellValidating += new DataGridViewCellValidatingEventHandler(dataGrid_CellValidating);
            dataGrid.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
            dataGrid.AllowUserToAddRows = false;
            dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            page.Controls.Add(dataGrid);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
        }

        private void CreateTextState()
        {
            textState = new RichTextBox();
            textState.Location = new Point(dataGrid.Location.X, dataGrid.Location.Y + dataGrid.Height + 40);
            textState.Size = new Size((int)(0.6 * page.Width), page.Height - dataGrid.Location.Y - dataGrid.Height - 50);
            textState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            textState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            textState.ReadOnly = true;
            page.Controls.Add(textState);
        }

        private void CreateButtonDiscipline()
        {
            buttonDiscipline = new Button();
            buttonDiscipline.Text = "Список дисциплин в БД";
            buttonDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            buttonDiscipline.Location = new Point(textState.Location.X + textState.Width + 50, textState.Location.Y);
            buttonDiscipline.Size = new Size((int)(0.15 * page.Width), 120);
            buttonDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            buttonDiscipline.Click += new System.EventHandler(buttonDiscipline_Click);
            page.Controls.Add(buttonDiscipline);
        }

        private void CreateButtonStudent()
        {
            buttonStudent = new Button();
            buttonStudent.Text = "Список слушателей в БД";
            buttonStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            buttonStudent.Location = new Point(buttonDiscipline.Location.X + buttonDiscipline.Width + 10, textState.Location.Y);
            buttonStudent.Size = new Size((int)(0.15 * page.Width), 120);
            buttonStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            buttonStudent.Click += new System.EventHandler(buttonStudent_Click);
            page.Controls.Add(buttonStudent);
        }

        private void CreateButtonSaveAndLabel()
        {
            buttonSave = new Button();
            buttonSave.Text = "Сохранить";
            buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            buttonSave.Location = new Point(dataGrid.Location.X + dataGrid.Width - 200, dataGrid.Location.Y - 50);
            buttonSave.Size = new Size(200, 40);
            buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonSave.Click += new System.EventHandler(buttonSave_Click);
            page.Controls.Add(buttonSave);

            label = new Label();
            label.Text = ratingGroup.NameGroup;
            label.Size = new Size(700, 30);
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            label.Location = new Point(dataGrid.Location.X, dataGrid.Location.Y - 60);
            label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            page.Controls.Add(label);
        }

        private void CreateCheckBox()
        {
            checkBox = new CheckBox();
            checkBox.Text = "Добавить неопределённых слушателей как новых";
            checkBox.Size = new Size((int)(0.8 * page.Width), 30);
            checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            checkBox.Location = new Point(dataGrid.Location.X, dataGrid.Location.Y + dataGrid.Size.Height + 10);
            checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            checkBox.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            page.Controls.Add(checkBox);
        }
        #endregion
        // .........................................................................

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            FormStudent form = new FormStudent(this, ratingGroup.id_group, ratingGroup.NameGroup);
            form.ShowDialog();
        }

        private void buttonDiscipline_Click(object sender, EventArgs e)
        {
            FormDiscipline form = new FormDiscipline(this, semester, ratingGroup.id_specialization, ratingGroup.NameGroup);
            form.ShowDialog();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGrid[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    if (e.ColumnIndex == 0)
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = currentCellValue;
                    else
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                    return;
                }
                else if (e.ColumnIndex == 0 && String.IsNullOrWhiteSpace(dataGrid[0, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("ФИО не может быть пустым", "Ошибка редактирования");
                    dataGrid[0, e.RowIndex].Value = currentCellValue;
                }
                else if (e.ColumnIndex == 0)
                {
                    CheckCorrectStudentData(e.RowIndex);
                    UpdateState();
                }
                else
                {
                    string temp = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    int value = Convert.ToInt32(temp);
                    if (value < 2 || value > 5)
                    {
                        if (value == 0)
                            return;
                        MessageBox.Show("Оценка должна быть в пределах от 2 до 5 или 0 в случае отсутствия оценки", "Ошибка редактирования");
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = currentCellValue;
                    }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsDisciplineCorrect || !IsStudentCorrect || IsExistDataUpdate)
            {
                MessageBox.Show("Данные не готовы к загрузке.", "Уведомление");
                return;
            }
            // ГРУЗИМ ДАННЫЕ
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {   // проверка на наличие ОДИНАКОВЫХ студентов в таблице
                long id_1 = Convert.ToInt64(dataGrid.Rows[i].Tag);
                if (id_1 == -1)
                    continue;
                for (int j = 0; j < dataGrid.Rows.Count; j++)
                {
                    if (j == i)
                        continue;
                    long id_2 = Convert.ToInt64(dataGrid.Rows[j].Tag);
                    if (id_1 == id_2)
                    {
                        MessageBox.Show("В таблице обнаружены два одинаковых слушателя на соответствующих строчках " + 
                            (i+1) + ";" + (j+1) + ". Проверьте правильность входных данных.", "Ошибка идентификации");
                        return;
                    }
                }
            }
            if (SaveData())
                MessageBox.Show("Данные успешно загружены.", "Уведомление");
            parentControl.TabPages.Remove(page);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGrid.SelectedColumns.Count != 0)
                {
                    for (int i = dataGrid.SelectedColumns.Count - 1; i >= 0 ; i--)
                        dataGrid.Columns.Remove(dataGrid.SelectedColumns[i]);
                    UpdateState();
                }
                else if (dataGrid.CurrentCell != null && dataGrid.CurrentCell.ColumnIndex == 0)
                {
                    dataGrid.Rows.RemoveAt(dataGrid.CurrentCell.RowIndex);
                    UpdateState();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private int getValueAssessment(string cellString)
        {
            try
            {
                int value = Convert.ToInt32(cellString);
                if (value < 2 || value > 5)
                    return 0;
                return value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Функция сохранения всей информации в БД.
        /// </summary>
        private bool SaveData()
        {
            try
            {
                // Добавляем новых пользователей в БД и записываем их ID в Таг строки
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (Convert.ToInt64(dataGrid.Rows[i].Tag) == -1)
                    {
                        int rowid = SQLiteManager.InsertValue("Student", new string[] { "FIO", "ID_group" }, new object[] { dataGrid[0, i].Value.ToString().Trim(), id_group });
                        dataGrid.Rows[i].Tag = rowid;
                    }
                }
                // Проходим по каждому пользователю и добавляем в БД новую запись об оценке за семестер по каждой дисциплине
                SQLiteConnection connection = SQLiteManager.CreateConnection();
                string sqlInsert = "INSERT INTO Assessment_Discipline(Assessment, ID_student, ID_discipline, Semester) VALUES(@ass, @id_stud, @id_disp, @sem)";
                SQLiteCommand command = new SQLiteCommand(sqlInsert, connection);
                command.Parameters.Add(new SQLiteParameter("@ass", DbType.Int64));
                command.Parameters.Add(new SQLiteParameter("@id_stud", DbType.Int64));
                command.Parameters.Add(new SQLiteParameter("@id_disp", DbType.Int64));
                command.Parameters.AddWithValue("@sem", semester);
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    long id_student = Convert.ToInt64(dataGrid.Rows[i].Tag);
                    if (id_student == -1)
                        continue;
                    for (int j = 1; j < dataGrid.Columns.Count; j++)
                    {
                        long id_disp = Convert.ToInt64(dataGrid.Columns[j].Tag);
                        if (id_disp == -1)
                            continue;
                        int assessment;
                        if (dataGrid[j, i].Value == null)
                            assessment = 0;
                        else
                            assessment = getValueAssessment(dataGrid[j, i].Value.ToString());
                        command.Parameters[0].Value = assessment;
                        command.Parameters[1].Value = id_student;
                        command.Parameters[2].Value = id_disp;
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("В процессе сохранения произошла ошибка.\n" + e.Message, "Ошибка");
                return false;
            }
        }

    }
}
