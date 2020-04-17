using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using System;
using System.Windows.Forms;

namespace SetupExplorerUI.Components.Loggers
{
	// TODO : https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top

	public class RichTextBoxLogger : ILogger
	{
		private readonly RichTextBox _richTextBox;

		public RichTextBoxLogger(RichTextBox richTextBox)
		{
			_richTextBox = richTextBox;
		}

		public void Log(ELogLevel level, string message)
		{
			if (level <= Config.ELogLevel)
			{
				_richTextBox.Text += level + " | " + message + "\r\n";
			}
		}
	}
}