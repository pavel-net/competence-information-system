using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;

namespace CompetenceInformationSystem
{
    public partial class FormAddStudent : Form
    {
        long id_group;
        long id_specialization;
        int semester;
        FormGroupAndStudent parentForm;
        public FormAddStudent(long id_group, string nameGroup, long id_specialization, FormGroupAndStudent parentForm)
        {
            this.parentForm = parentForm;
            this.id_group = id_group;
            this.id_specialization = id_specialization;
            this.semester = Program.GetNumKurs(nameGroup) * 2;
            InitializeComponent();
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Сначала введите ФИО", "Уведомление");
                return;
            }
            int rowid = SQLiteManager.InsertValue("Student", new string[] { "FIO", "ID_group" }, new object[] { textBox1.Text.Trim(), id_group });
            SQLiteConnection connection = SQLiteManager.CreateConnection();
            SQLiteCommand command = new SQLiteCommand("SELECT ID, Semester FROM WorkProgramm WHERE ID_specialization = @id_spec", connection);
            command.Parameters.AddWithValue("@id_spec", id_specialization);
            List<long> IDdiscipline = new List<long>();
            ArrayList listSemesterDiscipline = new ArrayList();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string[] sem = reader[1].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (sem == null || sem.Length == 0)
                    continue;
                IDdiscipline.Add(Convert.ToInt64(reader[0]));
                int[] temp = new int[sem.Length];
                for (int i = 0; i < sem.Length; i++)
                    temp[i] = Convert.ToInt32(sem[i]);
                listSemesterDiscipline.Add(temp);
            }
            reader.Close();
            if (listSemesterDiscipline.Count != 0)
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO Assessment_Discipline(ID_student, ID_discipline, Semester) VALUES(@id_stud, @id_disp, @sem)";
                command.Parameters.AddWithValue("@id_stud", rowid);
                command.Parameters.Add(new SQLiteParameter("@id_disp", DbType.Int64));
                command.Parameters.Add(new SQLiteParameter("@sem", DbType.Int32));
                for (int i = 0; i < listSemesterDiscipline.Count; i++)
                {
                    int[] sem = (int[])listSemesterDiscipline[i];
                    command.Parameters[1].Value = IDdiscipline[i];
                    for (int j = 0; j < sem.Length; j++)
                    {
                        if (sem[j] <= semester)
                        {
                            command.Parameters[2].Value = sem[j];
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            parentForm.AddNewStudent(rowid, id_group, textBox1.Text.Trim());
            connection.Close();
            Close();
        }
    }
}
