using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeTube.Services
{
    public class VideoUploader : IVideoUploader
    {
        private readonly string _bucketName;
        private readonly StorageClient _storageClient;
        private readonly string _projectId;

        public VideoUploader(string bucketName, string projectId)
        {
            _bucketName = bucketName;
            _projectId = projectId;
            _storageClient = StorageClient.Create();
        }

        public async Task<string> Upload(IFormFile file, long id)
        {
            var videoAcl = PredefinedObjectAcl.PublicRead;

            using (var reader = file.OpenReadStream())
            {
                var videoObject = await _storageClient.UploadObjectAsync(
                    bucket: _bucketName,
                    objectName: id.ToString(),
                    contentType: file.ContentType,
                    source: reader,
                    options: new UploadObjectOptions { PredefinedAcl = videoAcl }
                    );

                return videoObject.MediaLink;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _storageClient.DeleteObjectAsync(_bucketName, id.ToString());
            }
            catch (Google.GoogleApiException exception)
            {
                // A 404 error is ok.  The image is not stored in cloud storage.
                if (exception.Error.Code != 404)
                    throw exception;
            }
        }
    }
}
