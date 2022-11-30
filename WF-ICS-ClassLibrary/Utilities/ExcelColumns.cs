using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class ExcelColumns
    {
        public static List<string> getExcelColumns(bool includeBlank = false)
        {
            List<string> columns = new List<string>();
            if (includeBlank)
            {
                columns.Add("-");
            }
            for (int x = 0; x < 26; x++)
            {
                columns.Add(char.ConvertFromUtf32(65 + x));
            }
            for (int x = 0; x < 26; x++)
            {
                columns.Add("A" + char.ConvertFromUtf32(65 + x));
            }
            for (int x = 0; x < 26; x++)
            {
                columns.Add("B" + char.ConvertFromUtf32(65 + x));
            }

            return columns;

        }
    }
}
