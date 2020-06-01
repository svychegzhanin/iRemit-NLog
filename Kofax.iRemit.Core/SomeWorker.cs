using System;
using NLog;

namespace Kofax.iRemit.Core
{
    public class SomeWorker
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private bool _isWorking;

        public bool IsWorking
        {
            get
            {
                _logger.Debug($"{nameof(_isWorking)}: {_isWorking}");
                return _isWorking;
            }
        }

        public bool? PropertyWithException
        {
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e, $"Exception in {nameof(PropertyWithException)}.");
                }
            }
        }

        public void DoWork()
        {
            _isWorking = true;
            _logger.Info("Work started.");

            Array array = null;
            if (array == null)
            {
                _logger.Warn($"{nameof(array)} is not defined.");
            }

            try
            {
                array.Initialize();
            }
            catch (Exception e)
            {
                _logger.Error(e, "Couldn't finish work properly.");
            }
            finally
            {
                _isWorking = false;
            }
        }
    }
}
