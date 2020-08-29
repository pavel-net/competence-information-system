using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace CompetenceInformationSystem
{
    class ReaderWordCompetence : ReaderWord
    {
        public ReaderWordCompetence(string fileName)
            : base(fileName)
        {
        }

        private string ReadFile()
        {
            string text = GetTextFromWord();
            return text;
        }

        /// <summary>
        /// Считывает файл стандарта образования и возвращает Лист, элементами которого являются string[ , 2]
        /// массивы, в каждом из которых находятся группы компетенций с [0] кодом и [1] названием.
        /// Возвращает null, если не удалось считать файл.
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCompetenceArray()
        {
            try
            {
                string result = ReadFile();
                if (String.IsNullOrWhiteSpace(result))
                    return null;
                ArrayList list = new ArrayList();
                // Для ПК
                Regex PK = new Regex(@"\((ПК-\s*\d+)\)");
                AddCompetenceArrayInList(PK, result, list);
                // Для ПСК
                for (int count = 1; count < 10; count++)
                {
                    Regex PSK = new Regex(@"\((ПСК-\s*" + count.ToString() + @".\d+)\)");
                    AddCompetenceArrayInList(PSK, result, list);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        private void AddCompetenceArrayInList(Regex reg, string text, ArrayList list)
        {
            MatchCollection matches = reg.Matches(text);
            if (matches.Count == 0)
                return;
            int[] CompetetionIndx = new int[matches.Count]; 
            string[] Competetion = new string[matches.Count]; 
            int i = 0;
            foreach (Match mat in matches)
            {
                CompetetionIndx[i] = mat.Index;
                Competetion[i] = mat.Groups[1].Value;;
                i++;
            }
            string[] CompetetionText = new string[Competetion.Length];  //Массив сторок, в котором находятся суть компетенций
            //заполняем массив CompetetionText
            int index_tab = GetLeftTabulationIndex(text, CompetetionIndx[0]);
            CompetetionText[0] = text.Substring(index_tab, CompetetionIndx[0] - index_tab);
            for (int t = 1; t < CompetetionText.Length; t++)
            {
                int a1 = CompetetionIndx[t - 1] + matches[t - 1].Length;
                int a2 = CompetetionIndx[t];
                CompetetionText[t] = text.Substring(a1, a2 - a1 - 1).Replace('\r', ' ');
            }
            string[,] Kom = new string[CompetetionText.Length, 2];
            for (int w = 0; w < CompetetionText.Length; w++)
            {
                string comp = CompetetionText[w];
                comp = comp.Replace('\r', ' ');
                comp = comp.Replace(';', ' ');
                comp = comp.Trim();
                Kom[w, 1] = comp;
                Kom[w, 0] = Competetion[w];
            }
            list.Add(Kom);
        }

        private int GetLeftTabulationIndex(string buffStr, int startIndex)
        {
            int i = startIndex - 1;
            while (i > 0)
            {
                if (buffStr[i] == '\r')
                    return i;
                i--;
            }
            return i;
        }
    }
}
