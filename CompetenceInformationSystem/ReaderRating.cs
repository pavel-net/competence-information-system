using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace CompetenceInformationSystem
{
    class ReaderRating : ReaderExcel
    {
        // D2 = (2, 4) - координата первой дисциплины
        int rowNumDiscip = 2;
        int colNumDiscip = 4;
        // координата первого студента
        int rowNumStudent = 3;
        int colNumStudent = 3;
        ArrayList ListDiscipline = new ArrayList();

        public ReaderRating(string fileName) : base(fileName)
        {        
        }

        public Discipline[] GetDiscipline()
        {
            bool flag = ReadDiscipline();
            if (!flag)
                return null;
            Discipline[] DiscipArray = new Discipline[ListDiscipline.Count];
            for (int i = 0; i < ListDiscipline.Count; i++)
                DiscipArray[i] = (Discipline)ListDiscipline[i];
            return DiscipArray;
        }

        private bool ReadDiscipline()
        {
            ListDiscipline.Clear();
            string formReport = null;
            int count_null = 0;
            int i = colNumDiscip;
            string temp;
            while (count_null < 10)
            {
                temp = ReadCell(rowNumDiscip - 1, i);
                if (!String.IsNullOrEmpty(temp))
                {
                    formReport = temp;
                    formReport = formReport.Trim();
                    if (!String.Equals(formReport, "Зачеты", StringComparison.OrdinalIgnoreCase)
                        && !String.Equals(formReport, "Экзамены", StringComparison.OrdinalIgnoreCase))
                        break;
                }
                temp = ReadCell(rowNumDiscip, i);
                if (String.IsNullOrEmpty(temp))
                {
                    count_null++;
                    i++;
                    continue;
                }
                count_null = 0;
                Discipline discip = new Discipline(temp.Trim(), formReport, rowNumDiscip, i);
                ListDiscipline.Add(discip);
                i++;
            }
            if (ListDiscipline != null && ListDiscipline.Count != 0)
                return true;
            return false;
        }
        /// <summary>
        /// Для таблицы с заданными столбцами дисциплин (и 1-й столбец - студенты) считывает оценки слушателей и 
        /// возвращает заполненную таблицу
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool ReadStudentAndRating(ref DataTable table, Discipline[] DiscipArray)
        {
            if (table == null)
                return false;
            int countDiscip = DiscipArray.Length;
            int[] ArrayIndexColumnDiscipline = new int[countDiscip];
            for (int k = 0; k < countDiscip; k++)
                ArrayIndexColumnDiscipline[k] = DiscipArray[k].colNum;
            int i = rowNumStudent;
            string fio = ReadCell(i, colNumStudent);
            while (!String.IsNullOrEmpty(fio))
            {
                // добавляем новую строку
                DataRow row = table.NewRow();
                row[0] = fio;
                for (int j = 1; j <= countDiscip; j++)
                {
                    string temp = ReadCell(i, ArrayIndexColumnDiscipline[j - 1]);
                    if (String.IsNullOrWhiteSpace(temp))
                        row[j] = 0;
                    else
                        row[j] = Convert.ToInt32(temp);
                }
                i++;
                table.Rows.Add(row);
                fio = ReadCell(i, colNumStudent);
            }
            if (table.Rows.Count == 0)
                return false;
            return true;
        }
        /// <summary>
        /// Считывает матрицу (слушатели Х дисциплины) с оценками и возвращает это в виде таблицы,
        /// где первый столбец - слушатели, а остальные - дисциплины.
        /// </summary>
        /// <returns></returns>
        public DataTable ReadTable()
        {
            Discipline[] DiscipArray = GetDiscipline();
            if (DiscipArray == null)
                return null;
            DataTable table = new DataTable("Rating");
            table.Columns.Add("FIO");
            for (int i = 0; i < DiscipArray.Length; i++)
            {
                table.Columns.Add(DiscipArray[i].Name);
            }
            // ..... ЗАПОЛНЯЕМ ТАБЛИЦУ .....
            if (!ReadStudentAndRating(ref table, DiscipArray))
                return null;
            return table;
        }
        /// <summary>
        /// Считывает все страницы эксель файла с данными об оценках за семестер для учебных групп.
        /// Возвращает массив с информацией о каждой группе.
        /// </summary>
        /// <returns></returns>
        public RatingGroup[] ReadAllTable()
        {
            int countSheets = getCountSheets();
            if (countSheets < 1)
                return null;
            RatingGroup[] result = new RatingGroup[countSheets];
            for (int i = 0; i < countSheets; i++)
            {
                //String.Equals(getNameSheet().Trim(), "7133", StringComparison.OrdinalIgnoreCase)
                string nameGroup = getNameSheet().Trim();
                if (!SQLiteManager.IsExistValue("StudyGroup", "NumGroup", nameGroup))
                {   // указанная группа не существует в БД, поэтому ничего считывать не будем
                    result[i] = new RatingGroup(null, false, false, nameGroup);
                }
                else
                {
                    DataTable table = ReadTable();
                    if (table == null)
                        result[i] = new RatingGroup(null, true, false, nameGroup);
                    else
                        result[i] = new RatingGroup(table, true, true, nameGroup);                 
                }
                NextSheet();
            }
            return result;
        }
    }
}
