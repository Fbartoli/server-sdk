﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Morph.Server.Sdk.Events;
using Morph.Server.Sdk.Model;
using Morph.Server.Sdk.Model.Commands;

namespace Morph.Server.Sdk.Client
{
    public interface IMorphServerApiClient
    {
        event EventHandler<FileEventArgs> FileProgress;

        Task<SpaceBrowsingInfo> BrowseSpaceAsync(ApiSession apiSession, string folderPath, CancellationToken cancellationToken);
        Task CloseSession(ApiSession apiSession, CancellationToken cancellationToken);
        Task DeleteFileAsync(ApiSession apiSession, string serverFolder, string fileName, CancellationToken cancellationToken);
        Task DownloadFileAsync(ApiSession apiSession, string remoteFilePath, Func<DownloadFileInfo, bool> handleFile, Stream streamToWriteTo, CancellationToken cancellationToken);
        Task<DownloadFileInfo> DownloadFileAsync(ApiSession apiSession, string remoteFilePath, Stream streamToWriteTo, CancellationToken cancellationToken);
        Task<bool> FileExistsAsync(ApiSession apiSession, string serverFolder, string fileName, CancellationToken cancellationToken);
        Task<ServerStatus> GetServerStatusAsync(CancellationToken cancellationToken);
        Task<Model.TaskStatus> GetTaskStatusAsync(ApiSession apiSession, Guid taskId, CancellationToken cancellationToken);        
        Task<ApiSession> OpenSessionAsync(string spaceName, string password, CancellationToken cancellationToken);
        Task<RunningTaskStatus> StartTaskAsync(ApiSession apiSession, Guid taskId, CancellationToken cancellationToken, IEnumerable<TaskBaseParameter> taskParameters = null);
        Task StopTaskAsync(ApiSession apiSession, Guid taskId, CancellationToken cancellationToken);
        Task UploadFileAsync(ApiSession apiSession, Stream inputStream, string fileName, long fileSize, string destFolderPath, CancellationToken cancellationToken, bool overwriteFileifExists = false);
        Task UploadFileAsync(ApiSession apiSession, string localFilePath, string destFolderPath, CancellationToken cancellationToken, bool overwriteFileifExists = false);
        Task<ValidateTasksResult> ValidateTasksAsync(ApiSession apiSession, string projectPath, CancellationToken cancellationToken);
        Task<SpacesList> GetSpacesListAsync(CancellationToken cancellationToken);
    }
}