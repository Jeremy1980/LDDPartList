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

using System.Xml;

namespace LDDPartsList
{
    class FileTypes
    {
        private string extension;
        private int    id;
        private string description;
        private bool   XSLEnabled;
        private IFileTypeHandler handler;

        public static FileTypes TEXT  = new FileTypes(0, "csv",  "Formatted Text", true, new XSLTransformer("txt"));
        public static FileTypes XML   = new FileTypes(1, "xml",  "XML Document", true, new XSLTransformer("xml"));
        public static FileTypes HTML  = new FileTypes(2, "html", "Web Page", true, new XSLTransformer("html"));

        private static FileTypes[] types = new FileTypes[3];

        /// <summary>
        /// The static constructor creates a predefiend set of known file types.
        /// These types will handle the save actions.
        /// </summary>
        static FileTypes()
        {
            types[0] = TEXT;
            types[1] = XML;
            types[2] = HTML;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Reference identifier</param>
        /// <param name="extension">File extension</param>
        /// <param name="description">Describe what is this file.</param>
        /// <param name="CanXSL">Can you transform to this by XSL from XML? If yes, then true.</param>
        /// <param name="handler">Save action handler object</param>
        public FileTypes(int id, string extension, string description, bool CanXSL, IFileTypeHandler handler)
        {
            this.id = id;
            this.extension = extension;
            this.description = description;
            this.XSLEnabled = CanXSL;
            this.handler = handler;
        }

        /// <summary>
        /// Returns if the given Filetype can work from XML.
        /// </summary>
        /// <param name="ft">The filetype under questioning</param>
        /// <returns>Can you transform to this by XSL from XML? If yes, then true.</returns>
        public static bool IsXSLTEnabled(FileTypes ft)
        {
            return false;
        }

        /// <summary>
        /// Return the filetype identified by its ID.
        /// </summary>
        /// <param name="id">Reference ID</param>
        /// <returns>The filetype with the matching ID.</returns>
        public static FileTypes GetByID(int id)
        {
            return types[id];
        }

        public int GetID()
        {
            return id;
        }

        /// <summary>
        /// Returns the extension associated with this filetype.
        /// </summary>
        /// <returns>The extension as string.</returns>
        public string GetExtension()
        {
            return extension;
        }

        /// <summary>
        /// Returns the summary of this filetype.
        /// </summary>
        /// <returns>The descrioption.</returns>
        public string GetDescription()
        {
            return description;
        }

        public bool CanXSL()
        {
            return XSLEnabled;
        }

        public static string[] GetAllDescription()
        {
            string[] res = new string[types.Length];
            foreach (FileTypes f in types)
                res[f.GetID()] = f.GetDescription();
            return res;
        }

        /// <summary>
        /// Calls the Save method for this handler.
        /// </summary>
        /// <param name="xml">The XmlDocument to save by the handler.</param>
        /// <param name="filename">Absolute path of a file.</param>
        /// <returns>Success?</returns>
        public bool Save(XmlDocument xml, string filename)
        {
            return handler.Save(xml, filename);
        }

        /// <summary>
        /// Call the Save method for the specified handler.
        /// </summary>
        /// <param name="xml">The XmlDocument to save by the handler.</param>
        /// <param name="filename">Absolute path of a file.</param>
        /// <param name="typeID">The filetype reference ID.</param>
        /// <returns>Success?</returns>
        public static bool Save(XmlDocument xml, string filename, int typeID)
        {
            return FileTypes.GetByID(typeID).Save(xml, filename);
        }
    }
}
