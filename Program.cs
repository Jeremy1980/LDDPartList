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

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LDDPartsList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            Boolean interactiveMode = true;
            switch (args.Length)
            {
                case 2:
                    args[1] = Path.GetExtension(args[1]).ToLower().EndsWith(".lxf") ? args[1] : "";
                    break;
                case 3:
                    interactiveMode = false;
                    break;
                default:
                    args = new string[] { Application.ExecutablePath, "", "" };
                    break;
            }
            if (interactiveMode)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LDDPartsListForm(args));
            } else {
                try
                {
                    string commandLineModelArg = Path.GetExtension(args[1]).ToLower().EndsWith(".lxf") ? args[1] : args[2];
                    string commandLineSchemeArg = Path.GetExtension(args[1]).ToLower().EndsWith(".xsl") ? args[1] : args[2];

                    string saveName = Path.Combine( Path.GetDirectoryName(Application.ExecutablePath) ,"partslist" );
                    string outputType = Path.GetFileNameWithoutExtension(commandLineSchemeArg);
                           outputType = outputType.Split(new char[] { '2' })[1];

                    Unzip z = new Unzip(commandLineModelArg);
                    String lxfml = z.GetLXFML();

                    PartsReader pr = new PartsReader(lxfml);
                    SortedDictionary<int, Brick> partslist = pr.Extract();

                    XMLCreator xc = new XMLCreator(partslist);

                    new XSLTransformer(outputType).Save(xc.GetXML(), saveName);
                }
                catch (Exception ex ) { MessageBox.Show(ex.ToString() ,Application.ProductName); }

            }
        }
    }
}
