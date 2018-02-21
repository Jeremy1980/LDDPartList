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
            outputtype.Items.Clear();
            outputtype.Items.AddRange(FileTypes.GetAllDescription());
            outputtype.Refresh();
        }

        /// <summary>
        /// Opens an opendialog to select a file.
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void openbutton_Click(object sender, EventArgs e)
        {
            opendialog.InitialDirectory = modelDirectory;
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                lxfName.Text = opendialog.FileName;
                outputtype.Enabled = true;
                modelDirectory = Path.GetDirectoryName(opendialog.FileName);

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
            if (outputtype.SelectedIndex != -1)
            {
                LType.Text = outputtype.SelectedItem.ToString();
                savebutton.Enabled = true;
                savename.Enabled = true;

                if (savename.Text.Length > 4)
                    savename.Text = savename.Text.Remove(savename.Text.LastIndexOf('.') + 1) + FileTypes.GetByID(outputtype.SelectedIndex).GetExtension();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The invoker object.</param>
        /// <param name="e">Event parameters.</param>
        private void savebutton_Click(object sender, EventArgs e)
        {
            savedialog.Filter = FileTypes.GetByID(outputtype.SelectedIndex).GetDescription() + "|*." + FileTypes.GetByID(outputtype.SelectedIndex).GetExtension();

            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                savename.Text = savedialog.FileName;
                gobutton.Enabled = true;
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

            if (!FileTypes.Save(partsxml, savename.Text, outputtype.SelectedIndex))
            {
                progress(20, "Can't save the output. Sorry. Maybe I can't write there?");
            }
            else
            {
                progress(20, "Output formatted and saved. Done.");
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
