using System;
using WUApiLib;

namespace WUA
{
    class WUAManager : WUAProgressManager
    {
        public void Start(bool showProgress)
        {
            this.ShowProgress = showProgress;

            Console.WriteLine("WUA_Starting");

            IUpdateSession updateSession = new UpdateSessionClass();

            IUpdateSearcher updateSearcher = updateSession.CreateUpdateSearcher();
            IUpdateDownloader updateDownloader = updateSession.CreateUpdateDownloader();
            IUpdateInstaller updateInstaller = updateSession.CreateUpdateInstaller();

            if (updateInstaller.IsBusy)
            {
                Console.WriteLine("WUA_IsBusy");
                return;
            }

            // SEARCHING

            Console.WriteLine("WUA_FindingUpdates");

            ISearchResult searchResult = updateSearcher.Search("IsInstalled=0 and Type='Software'");

            if (searchResult.Updates.Count.Equals(0))
            {
                Console.WriteLine("WUA_NoApplicableUpdates");
                return;
            }

            // LISTING

            UpdateCollection updateToDownload = new UpdateCollectionClass();

            for (int i = 0; i < searchResult.Updates.Count; i++)
            {
                IUpdate update = searchResult.Updates[i];

                Console.WriteLine("WUA_UpdateItem:{0}|{1}", i + 1, update.Title);

                if (!update.IsDownloaded)
                {
                    updateToDownload.Add(update);
                }
            }

            // DOWNLOADING

            if (!updateToDownload.Count.Equals(0))
            {
                Console.WriteLine("WUA_DownloadingStarted");

                updateDownloader.Updates = updateToDownload;
                updateDownloader.IsForced = true;
                updateDownloader.Priority = DownloadPriority.dpHigh;

                IDownloadJob job = updateDownloader.BeginDownload(this, this, updateDownloader);
                IDownloadResult downloaderResult = updateDownloader.EndDownload(job);

                Console.WriteLine("WUA_DownloadingCompleted:{0}", downloaderResult.ResultCode);
            }

            // INSTALLATION

            updateInstaller.Updates = searchResult.Updates;
            updateInstaller.IsForced = true;

            Console.WriteLine("WUA_InstallationStarted");

            IInstallationJob installationJob = updateInstaller.BeginInstall(this, this, updateInstaller);
            IInstallationResult result = updateInstaller.EndInstall(installationJob);

            Console.WriteLine("WUA_InstallationCompleted:{0}|{1}", result.ResultCode, result.RebootRequired);

            // RESULT

            for (int i = 0; i < searchResult.Updates.Count; i++)
            {
                IUpdateInstallationResult resultItem = result.GetUpdateResult(i);
                Console.WriteLine("WUA_InstallationResult:{0}|{1}|{2}",
                    i + 1, resultItem.ResultCode, resultItem.RebootRequired);
            }

            Console.WriteLine("WUA_Finish");
        }
    }
}
