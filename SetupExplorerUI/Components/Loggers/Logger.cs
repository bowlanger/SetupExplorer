using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Windows.Forms;

namespace SetupExplorerUI
{
	// TODO : https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top

	public class RichTextBoxLogger : ILogger

	{
		private readonly RichTextBox _richTextBox;

		public RichTextBoxLogger(RichTextBox richTextBox)
		{
			_richTextBox = richTextBox;
		}

		private void Log(string message, ELogLevel level)
		{
			if (level < ConfigUI.ELogLevel)
			{
				Console.WriteLine(message);
				_richTextBox.Text += message + "\r\n";
			}
		}

		public void Debug(string message, ELogLevel level = ELogLevel.L0)
		{
			Log("DEBUG | " + message, level);
		}

		public void Info(string message, ELogLevel level = ELogLevel.L0)
		{
			Log("INFO | " + message, level);
		}

		public void Notice(string message, ELogLevel level = ELogLevel.L0)
		{
			Log("NOTICE | " + message, level);
		}

		public void Warn(string message, ELogLevel level = ELogLevel.L0)
		{
			Log("WARNING | " + message, level);
		}

		public void Error(string message, ELogLevel level = ELogLevel.L0)
		{
			Log("ERROR | " + message);
		}
	}
}