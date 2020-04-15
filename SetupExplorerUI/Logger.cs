using SetupExplorerLibrary.Interfaces;
using System;
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

		public void Log(string message)
		{
			Console.WriteLine(message);
			_richTextBox.Text += message + "\r\n";
		}

		public void Debug(string message)
		{
			Log("DEBUG | " + message);
		}

		public void Info(string message)
		{
			Log("INFO | " + message);
		}

		public void Notice(string message)
		{
			Log("NOTICE | " + message);
		}

		public void Warn(string message)
		{
			Log("WARNING | " + message);
		}

		public void Error(string message)
		{
			Log("ERROR | " + message);
		}
	}
}