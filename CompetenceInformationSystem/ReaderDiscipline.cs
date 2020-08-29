using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace CompetenceInformationSystem
{
    class ReaderDiscipline : ReaderExcel
    {
        // позиция первой дисциплины
        int rowNumDiscip = 14;
        int colNumDiscip = 2;
        // позиция первого семестра
        int colNumSemester = 5;

        DataTable tableDiscipline;

        public ReaderDiscipline(string fileName)
            : base(fileName)
        {
            tableDiscipline = new DataTable("Discipline");
            tableDiscipline.Columns.Add("Name");
            tableDiscipline.Columns.Add("Semester");
            tableDiscipline.Columns.Add("Report");
        }

        public DataTable Read()
        {
            tableDiscipline.Clear();
            string name = "";
            string semester = "";
            string report = "";
            int i = rowNumDiscip;
            name = ReadCell(i, colNumDiscip);
            while (!String.IsNullOrWhiteSpace(name))
            {
                semester = "";
                report = "";
                name = name.Trim();
                string temp;
                for (int k = 0; k < 10; k++)
                {
                    temp = "";
                    temp = ReadCell(i, colNumSemester + k);
                    if (!String.IsNullOrWhiteSpace(temp))
                    {
                        if (temp[0] != 'з' && temp[0] != 'Э' && temp[0] != 'З' && temp[0] != 'э')
                            break;
                        report += temp + ";";
                        semester += (k + 1) + ";";
                    }
                }
                if (!String.IsNullOrWhiteSpace(semester))
                {
                    DataRow row = tableDiscipline.NewRow();
                    row["Name"] = name;
                    row["Semester"] = semester;
                    row["Report"] = report;
                    tableDiscipline.Rows.Add(row);
                }
                i++;
                name = ReadCell(i, colNumDiscip);
            }
            return tableDiscipline;
        }
    }
}
