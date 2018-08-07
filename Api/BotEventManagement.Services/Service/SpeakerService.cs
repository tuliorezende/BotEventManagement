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
    public class SpeakerService : ICrudElementsWIthEventFilter<Speaker>
    {
        private BotEventManagementContext _botEventManagementContext;
        private readonly string _accountName;
        private readonly string _accessKey;

        public SpeakerService(BotEventManagementContext botEventManagementContext, string accountName, string accessKey)
        {
            _botEventManagementContext = botEventManagementContext;
            _accountName = accountName;
            _accessKey = accessKey;
        }

        public void Create(Speaker element)
        {
            _botEventManagementContext.Speaker.Add(element);
            _botEventManagementContext.SaveChanges();
        }


        public void Delete(string eventId, string elementId)
        {
            Speaker element = _botEventManagementContext.Speaker.Where(x => x.EventId == eventId && x.SpeakerId == elementId).First();
            _botEventManagementContext.Speaker.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<Speaker> GetAll(string eventId)
        {
            List<Speaker> elements = _botEventManagementContext.Speaker.Where(x => x.EventId == eventId).ToList();
            return elements;

        }

        public Speaker GetById(string elementId, string eventId)
        {
            Speaker element = _botEventManagementContext.Speaker.Where(x => x.SpeakerId == elementId && x.EventId == eventId).First();
            return element;

        }

        public void Update(Speaker element)
        {
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
        }

    }
}
