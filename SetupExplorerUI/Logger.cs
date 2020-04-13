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

		public void Log(string message)
		{
			_richTextBox.Text += message + "\r\n";
		}
	}
}