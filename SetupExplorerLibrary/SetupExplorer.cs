using Newtonsoft.Json;
using SetupExplorerLibrary.Components.Handlers;
using SetupExplorerLibrary.Components.Managers;
using SetupExplorerLibrary.Components.Parsers;
using SetupExplorerLibrary.Entities.SetupEntity;
using SetupExplorerLibrary.Entities.TemplateEntity;
using SetupExplorerLibrary.Enum;
using SetupExplorerLibrary.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetupExplorerLibrary
{
	public class SetupExplorer
	{
		public static Container Container = new Container();

		private readonly ILogger _logger;
		private readonly Config _cfg;
		
		private readonly SetupFileHelper _sfHp;

		private readonly SetupManager _sM;

		public SetupExplorer(Action<IConfigLibrary> actionConfig)
		{
			// config
			_cfg = new Config();
			actionConfig?.Invoke(_cfg);

			// registering the services
			Container.Register<Config>(() => _cfg, Lifestyle.Singleton);
			Container.Register<ILogger>(() => _cfg.Logger, Lifestyle.Singleton);
			// Container.Register(() => _logger, Lifestyle.Singleton);
			Container.Register<XPathHandler>(Lifestyle.Singleton);
			Container.Register<SetupFileHelper>();
			Container.Register<SetupManager>();

			_logger = Container.GetInstance<ILogger>();
			_logger.Log(ELogLevel.Debug, $@"{this.GetType().Name} > Constructor(logger)");

			_sfHp = Container.GetInstance<SetupFileHelper>();

			_sM = Container.GetInstance<SetupManager>();
		}

		public void OpenSetupFile(string setupFileName)
		{
			if (!_sfHp.Open(setupFileName))
			{
				throw new Exception();
			}

			Setup setup = new Setup(setupFileName)
			{

				// get setup notes
				Notes = _sfHp.GetSetupNotes(),

				// get setup summary
				Summary = _sfHp.GetSetupSummary(),
			};

			// get template from carName
			setup.Template = _sfHp.GetTemplate(setup.Summary.CarName);

			// get setup properties
			setup.Sheets = _sfHp.GetSetupProperties(setup.Template);

			// dump setup object
			var setupJson = JsonConvert.SerializeObject(setup, Formatting.Indented);
			_logger.Log(ELogLevel.DebugVV, setupJson);

			// save setup object in our library of loaded
			_sM.Register(setup);
		}

		public Setup GetSetup(string setupFileName)
		{
			return _sM.GetSetup(setupFileName);
		}
	}
}
