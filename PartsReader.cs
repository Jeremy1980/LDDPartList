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
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace LDDPartsList
{
    /// <summary>
    /// PartsReader processes an LXFML stream, and count every part, and resolvesits name (if known).
    /// </summary>
    class PartsReader
    {
        XmlDocument xd;
        XPathNavigator xn;
        XmlNamespaceManager ns;
        PartNameLookup lookup;

        /// <summary>
        /// Creates the lookup, and initiates the process.
        /// </summary>
        /// <param name="lxfml">LXFML XML string</param>
        public PartsReader(String lxfml)
        {
            xd = new XmlDocument();
            xd.LoadXml(lxfml);
            xn = xd.CreateNavigator();
            ns = new XmlNamespaceManager(xn.NameTable);
            lookup = new PartNameLookup(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\partnames.xml");
         }

        /// <summary>
        /// Extract iterates through the LXFML, and counts every part.
        /// </summary>
        /// <returns>A dictionary with the part informations.</returns>
        public SortedDictionary<int, Brick> Extract()
        {
            SortedDictionary<int, Brick> dict = new SortedDictionary<int, Brick>();
            XPathNodeIterator xi              = xn.Select("//Brick");

            // Manual says, one extre MoveNext() must be done, to move to the first Node.
            while (xi.MoveNext())
            {
                int element = -1;
                int design = -1;
                int material = -1;

                try
                {
                    element = Int32.Parse(xi.Current.GetAttribute("itemNos", ns.DefaultNamespace));
                } catch {
                    element = -1;
                }

                try
                {
                    design = Int32.Parse(xi.Current.GetAttribute("designID", ns.DefaultNamespace));
                }
                catch {
                    design = -1;
                }
                try
                {
                    xi.Current.MoveToFirstChild();
                    string materialID = xi.Current.GetAttribute("materialID", ns.DefaultNamespace);
                    string materials  = xi.Current.GetAttribute("materials", ns.DefaultNamespace);

                    if (materialID.Trim().Length == 0)
                        material = Int32.Parse(materials.Split(new char[] { ',', ';' })[0]);
                    else
                        material = Int32.Parse(materialID.Trim());
                }
                catch {
                    material = -1;
                }
                int hash         = Brick.HashCodeCompute(design, material);
                string brickname = lookup.GetNameOfPart(design, material);

                Brick b;
                if (dict.TryGetValue(hash, out b))
                {
                    b.Increment();
                } else {
                    dict.Add(hash, new Brick(element ,design, material, brickname));
                }
                
            }

            return dict;
        }

        ~PartsReader() // destructor
        {
            // Nothing. For now...
        }
    }
}
