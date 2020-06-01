using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using NLog;
using NLog.Targets;

namespace Kofax.iRemit.Web.WebApp
{
    public partial class About : Page
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Info("About page load event.");

            var fileTarget = LogManager.Configuration.AllTargets.FirstOrDefault(x => x is FileTarget) as FileTarget;
            if (fileTarget != null)
            {
                var fileName = fileTarget.FileName.Render(new LogEventInfo {Level = LogLevel.Info});

                MyBox.Items.Clear();
                foreach (var line in File.ReadAllLines(fileName))
                {
                    MyBox.Items.Add(line);
                }
            }
        }
    }
}