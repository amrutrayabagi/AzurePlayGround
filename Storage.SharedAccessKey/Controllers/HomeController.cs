using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace Storage.SharedAccessKey.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        static void GetBLobs()
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageAccountKey"));
            var blobStorageClient = storageAccount.CreateCloudBlobClient();
            var imageContainer = blobStorageClient.GetContainerReference("images");
            //imageContainer.DeleteIfExists();
            imageContainer.CreateIfNotExists(BlobContainerPublicAccessType.Blob);
            blobStorageClient.ListContainers().ToList().ForEach(data => Console.WriteLine(data.Name));
        }

    }
}