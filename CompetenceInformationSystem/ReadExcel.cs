using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace CompetenceInformationSystem
{
    class ReaderExcel
    {
        private Excel.Workbook MyBook = null;
        private Excel.Application MyApp = null;
        private Excel.Worksheet MySheet = null;
        private int currentSheet = 1;

        public ReaderExcel(string fileName)
        {
            InitialFile(fileName);
        }
        /// <summary>
        /// Инициализарует новый эксель файл и открывает первую страницу книги
        /// </summary>
        /// <param name="fileName"></param>
        private void InitialFile(string fileName)
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(fileName, Type.Missing, true);
            MySheet = (Excel.Worksheet)MyApp.Workbooks[1].Worksheets[1];
        }
        /// <summary>
        /// Перелистывает текущий реадер на работу со следующей страницей эксель документа
        /// </summary>
        /// <returns></returns>
        protected bool NextSheet()
        {
            if (currentSheet == MyApp.Workbooks[1].Worksheets.Count)
                return false;
            MySheet = (Excel.Worksheet)MyApp.Workbooks[1].Worksheets[++currentSheet];
            return true;
        }
        /// <summary>
        /// Возвращает количество страниц в текущем документе
        /// </summary>
        /// <returns></returns>
        protected int getCountSheets()
        {
            return MyApp.Workbooks[1].Worksheets.Count;
        }
        /// <summary>
        /// Возвращает имя текущей страницы (имя группы)
        /// </summary>
        /// <returns></returns>
        protected string getNameSheet()
        {
            return MySheet.Name;
        }

        public void Close()
        {
            MyApp.Quit();
        }

        public string ReadCell(string cell)
        {
            Excel.Range range = MySheet.get_Range(cell);
            dynamic myvalues = range.Cells.Text;
            return myvalues;
        }

        public string ReadCell(int rowNum, int colNum)
        {
            Excel.Range range = MySheet.UsedRange;
            dynamic myvalues = (range.Cells[rowNum, colNum] as Excel.Range).Text;
            return myvalues;
        }

        public string ReadRow(string row)
        {
            string result = "";
            Excel.Range range = MySheet.get_Range(row, Type.Missing);
            System.Array myvalues = (System.Array)range.Cells.Value;
            for (int i = 1; i <= myvalues.Length; i++)
            {
                result += myvalues.GetValue(1, i).ToString() + " ";
            }
            return result;
        }

    }
}
