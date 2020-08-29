using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace CompetenceInformationSystem
{
    class ReaderWorkPlan : ReaderWord
    {
        public ReaderWorkPlan(string fileName)
            :base(fileName)
        {
        }

        private string ReadFile()
        {
            string text = GetTextFromWord();
            return text;
        }

        /// <summary>
        /// Выделяет из файла список кодов дисциплин и возвращает его, а также название дисциплины.
        /// </summary>
        /// <param name="nameDiscipline"></param>
        /// <returns></returns>
        public string[] ReadCompetenceKod(ref string nameDiscipline)
        {
            try
            {
                string text = ReadFile();
                if (String.IsNullOrWhiteSpace(text))
                    return null;
                ArrayList list = new ArrayList();
                // Для ПК
                Regex PK = new Regex(@"\((ПК-\s*\d+)\)");
                GetCompetence(PK, text, list);
                // Для ПСК
                for (int count = 1; count < 10; count++)
                {
                    Regex PSK = new Regex(@"\((ПСК-?\s*" + count.ToString() + @".\d+)\)");
                    GetCompetence(PSK, text, list);
                }
                nameDiscipline = GetNameDiscipline(text);
                string[] result = (string[])list.ToArray(typeof(string));
                return result;
            }
            catch
            {
                return null;
            }
        }

        //выделяет компетенции из РП
        private void GetCompetence(Regex reg, string result, ArrayList list)
        {
            MatchCollection matches = reg.Matches(result);
            if (matches.Count == 0)
                return;
            string[] Competetion = new string[matches.Count];  //массив строк, в которые записываются найденные
            int i = 0;
            foreach (Match mat in matches)
            {
                list.Add(mat.Groups[1].Value.Trim());
                i++;
            }
        }

        private string GetNameDiscipline(string text)
        {
            string Discip = "";
            Regex kav_left = new Regex(@"\u00AB");   //левая кавычка в юникоде 
            Match left = kav_left.Match(text);
            if (left == null || String.IsNullOrWhiteSpace(left.Value))
                return "";
            Regex kav_right = new Regex(@"\u00BB");
            Match right = kav_right.Match(text);
            if (right == null || String.IsNullOrWhiteSpace(right.Value))
                return "";
            Discip = text.Substring(left.Index + 1, right.Index - left.Index - 1);
            return Discip;
        }

    }
}
