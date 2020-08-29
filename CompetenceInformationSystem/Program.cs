using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CompetenceInformationSystem
{
    static class Program
    {
        /// <summary>
        /// Номера групп
        /// </summary>
        static public string[] GroupNames = new string[] { 
            "7111", "7121", "7131", "7141", "7151",
            "7112", "7122", "7132", "7142", "7152",
            "7113", "7123", "7133", "7143", "7153",
        };
        static public int GetNumKurs(string numGroup)
        {
            int index = -1;
            for (int i = 0; i < GroupNames.Length; i++)
            {
                if (String.Equals(GroupNames[i], numGroup, StringComparison.OrdinalIgnoreCase))
                {
                    index = i + 1;
                    break;
                }
            }
            if (index == -1)
                return -1;
            return Convert.ToInt32(numGroup[2].ToString());
        }

        static public string GetNextNumKurs(string numGroup)
        {
            int index = GetNumKurs(numGroup);
            if (index == -1)
                return "";
            if (index == 5)
            {   // добавляем в резерв
                return ("Выпуск_" + System.DateTime.Now.Year + "_" + numGroup);
            }
            string str1 = numGroup.Substring(0, 2);
            string str2 = numGroup.Substring(3, numGroup.Length - 3);
            return (str1 + (index + 1).ToString() + str2);
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStart());
        }
    }
}
