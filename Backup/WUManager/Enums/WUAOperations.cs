namespace WUManager.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal enum WUAOperations
    {
        WUA_Starting,
        WUA_IsBusy,
        WUA_FindingUpdates,
        WUA_NoApplicableUpdates,
        WUA_UpdateItem,
        WUA_DownloadingStarted,
        WUA_DownloadingProgress,
        WUA_DownloadingCompleted,
        WUA_InstallationStarted,
        WUA_InstallationProgress,
        WUA_InstallationCompleted,
        WUA_InstallationResult,
        WUA_Finish,
        WUA_InternalError
    }
}
