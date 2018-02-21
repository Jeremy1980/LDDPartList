/*
    This file is part of LDDPartsList.

    LDDPartsList is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LDDPartsList is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LDDPartsList. If not, see <http://www.gnu.org/licenses/>.
*/

using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace LDDPartsList
{
    class ExcelWriter:IFileTypeHandler
    {
        private string cfgdir;
        private object NA = System.Reflection.Missing.Value;

        public ExcelWriter()
        {
            cfgdir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\";
        }

        public bool Save(XmlDocument xml, string filename)
        {
            Excel.Application xls = null;
            Excel.Workbook wb = null;
            Excel.Worksheet sheet = null;

            try
            {
                xls = new Excel.Application();
                xls.Visible = true;
                xls.UserControl = false;
                wb = (Excel.Workbook)(xls.Workbooks.Add(Missing.Value));
                sheet = (Excel.Worksheet)wb.ActiveSheet;
                xls.DisplayAlerts = true;

                sheet.Cells[1, 1] = "Brick name";
                sheet.Cells[1, 2] = "Count (pcs)";

                sheet.get_Range("A1", "B1").Font.Bold = true;

                int xlspointer = 2;
                XmlNodeList xnl = xml.GetElementsByTagName("part");
                foreach (XmlNode x in xnl)
                {
                    sheet.Cells[xlspointer, 1] = x.Attributes.GetNamedItem("name").InnerText;
                    sheet.Cells[xlspointer, 2] = x.Attributes.GetNamedItem("count").InnerText;
                    xlspointer++;
                }

                sheet.get_Range("A1", "A" + xlspointer).EntireColumn.AutoFit();
                sheet.get_Range("B1", "B" + xlspointer).EntireColumn.AutoFit();

                sheet.SaveAs(filename, NA, NA, NA, NA, NA, NA, NA, NA, NA);
                xls.UserControl = true;
            }
            catch (System.Exception theException)
            {
                string errorMessage;
                errorMessage = "Error: ";
                errorMessage = string.Concat(errorMessage, theException.Message);
                errorMessage = string.Concat(errorMessage, " Line: ");
                errorMessage = string.Concat(errorMessage, theException.Source);

                System.Windows.Forms.MessageBox.Show(errorMessage, "ERROR");
                return false;

            }

            return true;
        }
    }
}
