using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace CompetenceInformationSystem
{
    class ReaderWord
    {
        protected string fileName;
        public ReaderWord(string fileName)
        {
            this.fileName = fileName;
        }

        protected string GetTextFromWord()
        {
            Object filename = fileName;
            Object confirmConversions = Type.Missing;
            Object readOnly = true;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;
            Word.Application Progr = new Microsoft.Office.Interop.Word.Application();
            Progr.Documents.Open(ref filename,
                ref confirmConversions,
                ref readOnly,
                ref addToRecentFiles,
                ref passwordDocument,
                ref passwordTemplate,
                ref revert,
                ref writePasswordDocument,
                ref writePasswordTemplate,
                ref format,
                ref encoding,
                ref visible,
                ref openConflictDocument,
                ref openAndRepair,
                ref documentDirection,
                ref noEncodingDialog);
            Word.Document Doc = new Microsoft.Office.Interop.Word.Document();
            Doc = Progr.Documents.Application.ActiveDocument;
            object start = 0;
            object stop = Doc.Characters.Count;
            Word.Range Rng = Doc.Range(ref start, ref stop);
            string Result = Rng.Text;
            object sch = Type.Missing;
            object aq = Type.Missing;
            object ab = Type.Missing;
            Progr.Quit(ref sch, ref aq, ref ab);
            return Result;
        }  
    }
}
