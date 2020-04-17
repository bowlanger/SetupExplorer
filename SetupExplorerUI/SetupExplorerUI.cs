using SetupExplorerLibrary;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using SetupExplorerUI.Components.Loggers;
using System;
using System.Windows.Forms;

namespace SetupExplorerUI
{
	public partial class SetupExplorerForm : Form
	{
		//private readonly RichTextBoxLogger _logger;
		private readonly Logger _logger = new Logger();

		private readonly SetupExplorer _se;

		public SetupExplorerForm()
		{
			InitializeComponent();

			var richTextBoxLogger = new RichTextBoxLogger(tbConsole);
			var consoleLogger = new ConsoleLogger();

			_logger.Loggers.Add(richTextBoxLogger);
			_logger.Loggers.Add(consoleLogger);

			_se = new SetupExplorer((c) =>
			{
				c.Debug = true;
				c.BaseFolder = @"C:\";
				c.OutputFolder = Config.OutputFolder;
				c.UseLogger(_logger);
			});

			// TODO
			// setupExplorer.LookForSetup() // Find setups in default directory
			// _setupList = _se.GetSetupList()

			// Display list of setups with tickbox "select" "compare1" "compare2" "compare3"
			//		list must be filterable by car name and custom string
			// Button Open -> Open selected setups
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (seOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				_se.OpenSetupFile(seOpenFileDialog.FileName);

				/*setup = setupHandler.Setup;

				seHeaderReadOnlyTextBox.Text = String.Format("car : {0}\ttrack : {1} - {2}\r\nsetup : {3}",
																setup.SetupSummary.CarName,
																setup.SetupSummary.TrackName,
																setup.SetupSummary.TrackCfg,
																setup.SetupSummary.SetupName);
				seToolStripStatusLabel.Text = String.Format("Setup File : {0}", setupHandler.GetSetupFileName());
				*/
			}
		}

		private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_logger.Log(ELogLevel.Info, "Version: Ta mèèèèèèèère");
		}
	}
}