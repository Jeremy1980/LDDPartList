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
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace LDDPartsList
{

    /// <summary>
    /// Lookup for designID&amp;materialID keys.
    /// </summary>
    class PartNameLookup
    {
        XPathDocument xp;
        XPathNavigator xn;
        XmlNamespaceManager ns;

        /// <summary>
        /// Constructor of PartNameLookup.
        /// </summary>
        /// <param name="partnamesfile">File containing the part descriptions.</param>
        public PartNameLookup(string partnamesfile)
        {
            xp = new XPathDocument(partnamesfile);
            xn = xp.CreateNavigator();
            ns = new XmlNamespaceManager(xn.NameTable);
        }

        /// <summary>
        /// Get the name from the part description XML.
        /// </summary>
        /// <param name="designID">The designID form the LXFML Part</param>
        /// <param name="materialID">The materialID form the LXFML Part</param>
        /// <returns>The name of the part, or "Unknown".</returns>
        public String GetNameOfPart(int designID, int materialID)
        {
            XPathNodeIterator xi = xn.Select("//part[@designID='" + designID + "' and @materialID='" + materialID + "']");
            if (xi.Count > 0)
            {
                xi.MoveNext();
                return xi.Current.GetAttribute("name", ns.DefaultNamespace);
            } else {
                xi = xn.Select("//part[@designID='" + designID + "' and @materialID='-1']");
                if (xi.Count > 0)
                {
                    xi.MoveNext();
                    return xi.Current.GetAttribute("name", ns.DefaultNamespace);
                }
            }
            return "Unknown";
        }

        /// <summary>
        /// Get the name from the part description XML.
        /// </summary>
        /// <param name="hash">The hash from the SortedDictionary&lt;int, Brick&gt;.</param>
        /// <returns>The name of the part or "Unknown".</returns>
        public String GetNameOfPart(int hash)
        {
            int[] h = UnHash(hash);
            return GetNameOfPart(h[0], h[1]);
        }

        /// <summary>
        /// Hash splitter.
        /// </summary>
        /// <param name="hash">The hash from the SortedDictionary&lt;int, Brick&gt;.</param>
        /// <returns>Array. [0] is designID, [1] is materialID.</returns>
        private int[] UnHash(int hash)
        {
            int[] res = new int[2];
            res[0] = hash / 1000;
            res[1] = hash % 1000;
            return res;
        }
    }
}
