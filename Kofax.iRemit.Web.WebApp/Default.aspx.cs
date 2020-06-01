using System;
using System.Web.UI;
using NLog;

namespace Kofax.iRemit.Web.WebApp
{
    public partial class _Default : Page
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Info("Default page load event.");
        }
    }
}