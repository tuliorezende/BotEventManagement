using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class SpeakerService : ICrudElements<Speaker>
    {
        private BotEventManagementContext _botEventManagementContext;
        private readonly string _accountName;
        private readonly string _accessKey;

        public SpeakerService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(Speaker element)
        {
            if (element.PhotoArray != null)
                element.UploadedPhoto = GetImageUrl(element.PhotoArray);

            _botEventManagementContext.Speaker.Add(element);
            _botEventManagementContext.SaveChanges();
        }


        public void Delete(string elementId)
        {
            int speakerId = int.Parse(elementId);

            Speaker element = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == speakerId).First();
            _botEventManagementContext.Speaker.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<Speaker> GetAll()
        {
            List<Speaker> elements = _botEventManagementContext.Speaker.ToList();
            return elements;

        }

        public Speaker GetById(string elementId)
        {
            int speakerId = int.Parse(elementId);

            Speaker element = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == speakerId).First();
            return element;

        }

        public void Update(Speaker element)
        {
            if (element.PhotoArray != null)
                element.UploadedPhoto = GetImageUrl(element.PhotoArray);

            _botEventManagementContext.Entry(element).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }

        private string GetImageUrl(byte[] photoArray)
        {
            StorageCredentials credentials = new StorageCredentials(_accountName, _accessKey);
            CloudStorageAccount account = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = account.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("speakers");
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            cloudBlockBlob.UploadFromByteArrayAsync(photoArray, 0, photoArray.Length);

            cloudBlockBlob.Properties.ContentType = "image/jpg";
            cloudBlockBlob.SetPropertiesAsync();

            return cloudBlockBlob.Uri.ToString();

            return string.Empty;
        }

    }
}
