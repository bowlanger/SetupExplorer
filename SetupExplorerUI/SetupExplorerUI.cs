using SetupExplorerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupExplorerUI
{
    public partial class mainForm : Form
    {
        //private readonly SetupParser setupParser = new SetupParser();
        private SetupParser setupParser;

        public mainForm()
        {
            InitializeComponent();
            // Prevent blinking cursor in scHeaderTextBox
            //scHeaderTextBox.Enter += (s, e) => { scHeaderTextBox.Parent.Focus(); };
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                setupParser = new SetupParser(openOpenFileDialog.FileName);

                //scHeaderTextBox.Text = setupParser.h2cartrack;
                scHeaderTextBox.Text = String.Format("car : {0} \t track : {1} \r\n setup : {2}", setupParser.CarName, setupParser.TrackName, setupParser.SetupName);
                mainToolStripStatusLabel.Text = String.Format("Setup File : {0}", setupParser.InputFile);
            }
        }
    }
}
