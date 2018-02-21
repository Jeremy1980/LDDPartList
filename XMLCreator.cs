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

using System.Collections.Generic;
using System.Xml;

namespace LDDPartsList
{
    /// <summary>
    /// XMLCreator transforms a SortedDictionary&lt;int, Brick&gt; to XML.
    /// </summary>
    class XMLCreator
    {
        private SortedDictionary<int, Brick> dict;

        /// <summary>
        /// Constructor for XMLCreator. Sets the dictionary.
        /// </summary>
        /// <param name="dictionary">the dictionary containing the Brick informations</param>
        public XMLCreator(SortedDictionary<int, Brick> dictionary)
        {
            this.dict = new SortedDictionary<int, Brick>(dictionary);
        }

        /// <summary>
        /// This method converts the SortedDictionary to XML.
        /// </summary>
        /// <returns>The XML.</returns>
        public XmlDocument GetXML()
        {
            XmlDocument xd = new XmlDocument();
            xd.PreserveWhitespace = true;
            XmlElement parts = xd.CreateElement("parts");
            xd.AppendChild(parts);

            foreach (KeyValuePair<int, Brick> kvp in dict)
            {
                XmlElement p = xd.CreateElement("part");
                p.SetAttribute("itemNos",    kvp.Value.GetItemNo().ToString());
                p.SetAttribute("designID",   kvp.Value.GetDesignID().ToString());
                p.SetAttribute("materialID", kvp.Value.GetMaterialID().ToString());
                p.SetAttribute("count",      kvp.Value.GetCount().ToString());
                p.SetAttribute("name",       kvp.Value.GetName());
                p.Normalize();
                parts.AppendChild(p);
            }
            xd.Normalize();
            xd.InsertBefore(xd.CreateXmlDeclaration("1.0", "UTF-8", "no"), xd.DocumentElement);
            return xd;
        }

        ~XMLCreator()
        {
            dict.Clear();
        }
    }
}
