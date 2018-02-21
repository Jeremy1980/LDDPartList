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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace LDDPartsList
{
    /// <summary>
    /// UnZip implements the pkunzip provided by SharpZipLib.
    /// </summary>
    class Unzip
    {
        private String filename;
        private String lxfml = null;

        /// <summary>
        /// This constructor sets the compressed filename.
        /// </summary>
        /// <param name="filename">The LXF file to unzip.</param>
        public Unzip(String filename)
        {
            this.filename = filename;

        }

        /// <summary>
        /// Returns the contents os IMAGE100.LXFML, as an XML string.
        /// </summary>
        /// <returns>Contents of IMAGE100.LXFML.</returns>
        public String GetLXFML()
        {
            if (lxfml == null)
                this.lxfml = Decompress();
            return this.lxfml;

        }

        /// <summary>
        /// Decompresses the given LXF.
        /// </summary>
        /// <returns>Contents of IMAGE100.LXFML.</returns>
        private String Decompress()
        {
            ZipInputStream zip = new ZipInputStream(File.OpenRead(filename));
            ZipEntry ze;
            StringBuilder sb = new StringBuilder();
            while ((ze = zip.GetNextEntry()) != null)
            {
                if (ze.Name.Equals("IMAGE100.LXFML"))
                {
                    int size = 4096;
                    byte[] data = new byte[4096];
                    while (true)
                    {
                        size = zip.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            sb.Append(new ASCIIEncoding().GetString(data, 0, size));
                         }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            zip.Close();
            return sb.ToString();
        }

        public String ExtractImage()
        {
            String asynResult = "";
            using (ZipFile zipFile = new ZipFile(filename))
            {
                foreach (ZipEntry entry in zipFile)
                {
                    if (entry.IsFile)
                    {
                        Stream stream = zipFile.GetInputStream(entry);
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            String filename = entry.Name;
                            if (filename.Contains("/"))
                                filename = Path.GetFileName(filename);
                            if (filename.Equals("IMAGE100.PNG"))
                                {
                                asynResult = Path.GetTempFileName();
                                Image img = Image.FromStream(stream);
                                img.Save(asynResult, ImageFormat.Png);
                                break;
                            }
                        }
                    }
                }
            }
            return asynResult;
        }
    }
}
