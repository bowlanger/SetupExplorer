using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System.Windows.Forms;

namespace SetupExplorerUI
{
	public class RichTextBoxLogger : ILogger
	{
		private readonly RichTextBox _richTextBox;

		public RichTextBoxLogger(RichTextBox richTextBox)
		{
			_richTextBox = richTextBox;
		}

		private void Log(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			_richTextBox.Text += message + "\r\n";
		}

		public void Debug(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			Log("DEBUG | " + message);
		}

		public void Info(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			Log("INFO | " + message);
		}

		public void Notice(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			Log("NOTICE | " + message);
		}

		public void Warn(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			Log("WARNING | " + message);
		}

		public void Error(string message, ELogLevel eLogLevel = ELogLevel.L5)
		{
			Log("ERROR | " + message);
		}
	}
}