using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CompetenceInformationSystem
{
    /// <summary>
    /// Класс для хранения данных об оценках за семестер для определённой группы
    /// </summary>
    public class RatingGroup
    {
        public DataTable table;
        public string NameGroup;
        public long id_group = -1;
        public long id_specialization = -1;
        public bool IsGroupExistInDatabase;
        public bool IsDataLoaded;

        public RatingGroup(DataTable table, bool IsGroupExistInDatabase, bool IsDataLoaded, string NameGroup)
        {
            this.table = table;
            this.IsDataLoaded = IsDataLoaded;
            this.IsGroupExistInDatabase = IsGroupExistInDatabase;
            this.NameGroup = NameGroup;
            if (IsDataLoaded)
                InitialID();
        }

        private void InitialID()
        {
            string temp = SQLiteManager.GetValueFromDB("StudyGroup", "ID", "NumGroup", NameGroup);
            if (!String.IsNullOrWhiteSpace(temp))
                this.id_group = Convert.ToInt64(temp);
            temp = SQLiteManager.GetValueFromDB("StudyGroup", "ID_specialization", "NumGroup", NameGroup);
            if (!String.IsNullOrWhiteSpace(temp))
                this.id_specialization = Convert.ToInt64(temp);
        }

        public string[] GetDisciplineArray()
        {
            string[] result = new string[table.Columns.Count - 1];
            for (int i = 1; i < table.Columns.Count; i++)
                result[i - 1] = table.Columns[i].ColumnName;
            return result;
        }
    }
}
