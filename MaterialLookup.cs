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
using System.Xml;
using System.Xml.XPath;

namespace LDDPartsList
{
    class MaterialLookup
    {
        XPathDocument xp;
        XPathNavigator xn;
        XmlNamespaceManager ns;

        public MaterialLookup(string filepath)
        {
            xp = new XPathDocument(filepath);
            xn = xp.CreateNavigator();
            ns = new XmlNamespaceManager(xn.NameTable);
        }

        public String GetNameOf(int materialID)
        {
            XPathNodeIterator xi = xn.Select("//material[@materialID='" + materialID + "']");
            if (xi.Count > 0)
            {
                xi.MoveNext();
                return xi.Current.GetAttribute("name", ns.DefaultNamespace);
            }
            return "Unknown";
        }

        public String GetCodeOf(int materialID)
        {
            XPathNodeIterator xi = xn.Select("//material[@materialID='" + materialID + "']");
            if (xi.Count > 0)
            {
                xi.MoveNext();
                return xi.Current.GetAttribute("code", ns.DefaultNamespace);
            }
            return "";
        }
    }
}