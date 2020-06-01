using System;
using System.Web.UI;
using Kofax.iRemit.Core;
using NLog;

namespace Kofax.iRemit.Web.WebApp
{
    public partial class Contact : Page
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly SomeWorker _worker = new SomeWorker();

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Info("Contact page load event.");
        }

        protected void WorkButtonClick(object sender, EventArgs e)
        {
            if (!_worker.IsWorking)
            {
                _worker.DoWork();
            }

            _worker.PropertyWithException = null;
        }
    }
}