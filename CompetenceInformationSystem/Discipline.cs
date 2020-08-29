using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetenceInformationSystem
{
    class Discipline
    {
        public string Name;
        public string FormReport;
        public int rowNum;
        public int colNum;
        public Discipline(string Name, string FormReport, int rowNum, int colNum)
        {
            this.Name = Name;
            this.FormReport = FormReport;
            this.colNum = colNum;
            this.rowNum = rowNum;
        }

        
    }
}
