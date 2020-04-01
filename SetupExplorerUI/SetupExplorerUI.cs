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
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                setupParser = new SetupParser(openOpenFileDialog.FileName);

                testTextBox.Text = setupParser.h2cartrack;
            }
        }
    }
}
