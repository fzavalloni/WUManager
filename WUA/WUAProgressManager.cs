using System;
using WUApiLib;

namespace WUA
{
    internal class WUAProgressManager : IDownloadProgressChangedCallback, IInstallationProgressChangedCallback, IDownloadCompletedCallback, IInstallationCompletedCallback
    {
        private bool showProgress;
        public bool ShowProgress
        {
            set { this.showProgress = value; }
        }

        #region IDownloadProgressChangedCallback Members

        void IDownloadProgressChangedCallback.Invoke(IDownloadJob downloadJob, IDownloadProgressChangedCallbackArgs callbackArgs)
        {
            if (this.showProgress)
            {
                IDownloadProgress progress = callbackArgs.Progress;
                Console.WriteLine("WUA_DownloadingProgress:{0}|{1}|{2}",
                    progress.CurrentUpdateIndex + 1,
                    progress.CurrentUpdatePercentComplete,
                    progress.PercentComplete);
            }
        }

        #endregion

        #region IInstallationProgressChangedCallback Members

        void IInstallationProgressChangedCallback.Invoke(IInstallationJob installationJob, IInstallationProgressChangedCallbackArgs callbackArgs)
        {
            if (this.showProgress)
            {
                IInstallationProgress progress = callbackArgs.Progress;
                Console.WriteLine("WUA_InstallationProgress:{0}|{1}|{2}",
                    progress.CurrentUpdateIndex + 1,
                    progress.CurrentUpdatePercentComplete,
                    progress.PercentComplete);
            }

        }

        #endregion

        #region IDownloadCompletedCallback Members

        void IDownloadCompletedCallback.Invoke(IDownloadJob downloadJob, IDownloadCompletedCallbackArgs callbackArgs)
        {
        }

        #endregion

        #region IInstallationCompletedCallback Members

        void IInstallationCompletedCallback.Invoke(IInstallationJob installationJob, IInstallationCompletedCallbackArgs callbackArgs)
        {
        }

        #endregion
    }
}
