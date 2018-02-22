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
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace LDDPartsList
{
    /// <summary>
    /// Main class.
    /// </summary>
    public partial class LDDPartsListForm : Form
    {

        List<string> thumblist = new List<string>(new string[] { });
        string modelDirectory = "";

        /// <summary>
        /// Constructor.
        /// 
        /// Fills the outputtype ComboBox with the known filetypes.
        /// </summary>
        public LDDPartsListForm()
        {
            InitializeComponent();
            outputType.Items.Clear();
            outputType.Items.AddRange(FileTypes.GetAllDescription());
            outputType.Refresh();
        }

        /// <summary>
        /// Opens an opendialog to select a file.
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void openbutton_Click(object sender, EventArgs e)
        {
            openDialog.InitialDirectory = modelDirectory;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                lxfName.Text = openDialog.FileName;
                saveName.Text = "";
                outputType.Enabled = true;
                
                modelDirectory = Path.GetDirectoryName(openDialog.FileName);

                Unzip z = new Unzip(lxfName.Text);
                String thumbnailPath = "";
                try
                {
                    thumbnailPath = z.ExtractImage();
                } finally {
                    if (File.Exists(thumbnailPath))
                    {
                        pictureBox.Load(url: thumbnailPath);
                        thumblist.Add(thumbnailPath);
                    } else {
                        pictureBox.ImageLocation = @"checkimagelocalion";
                    }

                }
                z = null;
            }
        }

        /// <summary>
        /// If the output type is changed, change the savename's extension.
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void outputtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputType.SelectedIndex != -1)
            {
                saveButton.Enabled = true;
                saveName.Enabled = true;

                if (saveName.Text.Length > 4)
                    saveName.Text = saveName.Text.Remove(saveName.Text.LastIndexOf('.') + 1) + FileTypes.GetByID(outputType.SelectedIndex).GetExtension();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void savebutton_Click(object sender, EventArgs e)
        {
            if (saveName.Text.Trim().Length == 0)
                saveDialog.FileName = Path.GetFileNameWithoutExtension(lxfName.Text).Trim();

            saveDialog.Filter = FileTypes.GetByID(outputType.SelectedIndex).GetDescription() + "|*." + FileTypes.GetByID(outputType.SelectedIndex).GetExtension();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveName.Text = saveDialog.FileName;
                goButton.Enabled = true;
            }

        }

        /// <summary>
        /// If the textbox is changed, re-evaluate the other controls accessibility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lxfName_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// If the textbox is changed, re-evaluate the other controls accessibility.
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void savename_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// If "Go!" is pressed, start processing the input to the output.
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void gobutton_Click(object sender, EventArgs e)
        {
            progress(0, "");
            if (Directory.Exists(Path.GetDirectoryName(saveName.Text)))
            {
                progress(10, "Started...");

                Unzip z = new Unzip(lxfName.Text);
                String lxfml = z.GetLXFML();
                z = null;

                progress(10, "LXFML unzipped.");

                PartsReader pr = new PartsReader(lxfml);

                progress(20, "LXFML loaded.");

                SortedDictionary<int, Brick> partslist = pr.Extract();

                progress(20, "LXFML extracted.");

                XMLCreator xc = new XMLCreator(partslist);
                XmlDocument partsxml = xc.GetXML();

                progress(20, "XML generated.");

                if (!FileTypes.Save(partsxml, saveName.Text, outputType.SelectedIndex))
                {
                    progress(20, "Can't save the output. Sorry. Maybe I can't write there?");
                }
                else
                {
                    progress(20, "Output formatted and saved. Done.");
                }
            } else {
                progress(0, "Can't save the output. Directory is not exist or accessible for me.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.ComponentModel.CancelEventArgs ev = new System.ComponentModel.CancelEventArgs(true);
            Application.Exit(ev);
        }

        private void progress(int increment, string msg)
        {
            progressBar.Increment(increment);
            progressText.Text = msg;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }

        private void LDDPartsListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (string current in thumblist)
                {
                    if (File.Exists(current) && !thumblist[thumblist.Count - 1].Equals(value: current))
                    {
                        File.Delete(current);
                    }
                }
            }
            catch { }
            this.exitToolStripMenuItem_Click(this, e);
        }

        private void outputtype_TextChanged(object sender, EventArgs e)
        {
            progressText.Text = "";
        }
    }
}
