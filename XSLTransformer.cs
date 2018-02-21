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
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace LDDPartsList
{
    class XSLTransformer:IFileTypeHandler
    {
        private string cfgdir;
        private string extension;
        private string xslfile;

        public XSLTransformer(string extension)
        {
            this.extension = extension;
            cfgdir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\";
            xslfile = cfgdir + "xml2" + extension + ".xsl";
            if (!File.Exists(xslfile))
            {
                System.Windows.Forms.MessageBox.Show(xslfile + " can not be found in the installation directory.\nIt means, that converting to " + extension + " will not work, and will result in a saving error.", "Notice");
            }
        }

        public bool Save(XmlDocument xml, string filename)
        {
            if (File.Exists(xslfile))
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xslfile); // Loads the XSLT
                XmlTextWriter xtw = new XmlTextWriter(filename, Encoding.UTF8);
                XmlTextReader xtr = new XmlTextReader(new StringReader(xml.OuterXml));
                xslt.Transform(xtr, xtw);
                xtw.Close();
                xtr.Close();
                
                return true;
            }
            return false;
        }

    }
}
