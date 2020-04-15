using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Interfaces
{
	public interface ILogger
	{
		void Log(string message);

		void Debug(string message);
		void Error(string message);
		void Warn(string message);
		void Notice(string message);
		void Info(string message);
	}
}
