using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageAccountKey"));
            var blobStorageClient = storageAccount.CreateCloudBlobClient();
            var imageContainer = blobStorageClient.GetContainerReference("images");
            //imageContainer.DeleteIfExists();
            imageContainer.CreateIfNotExists(BlobContainerPublicAccessType.Blob);
            blobStorageClient.ListContainers().ToList().ForEach(data => Console.WriteLine(data.Name));


            //Uplaod a file to container
            //DirectoryInfo dirDetails = new DirectoryInfo(@"C:\Users\GEN_Colos\Pictures\Saved Pictures\");
            //foreach (FileInfo file in dirDetails.GetFiles())
            //{
            //    var blobref = imageContainer.GetBlockBlobReference(file.Name);
            //    using (var stream = File.OpenRead(@"C:\Users\GEN_Colos\Pictures\Saved Pictures\" + file.Name))
            //    {
            //        blobref.DeleteIfExists();
            //        blobref.UploadFromStream(stream);
            //    }
            //}



            ////List all files from container reference.
            //var newDirectory = Directory.CreateDirectory(@"C:\Users\GEN_Colos\Pictures\Saved Pictures\DownloadedFiles\");
            //var fileList = imageContainer.ListBlobs().Cast<CloudBlockBlob>();
            //foreach (var file in fileList)
            //{
            //    Console.WriteLine(file.Uri);
            //    var getBlobReference = imageContainer.GetBlobReference(file.Name); ;
            //    using (var stream = File.OpenWrite(newDirectory.FullName + file.Name))
            //    {
            //        getBlobReference.DownloadToStream(stream);
            //    }
            //}


            //Implement asynch copy operation.
            var existingBlobRef = imageContainer.GetBlockBlobReference("Navigation.png");
            var newBlobRef = imageContainer.GetBlockBlobReference("Navigation_1.png");

            newBlobRef.BeginStartCopy(existingBlobRef.Uri, (x) =>
            {
                Console.WriteLine("File Operation completed!");
            }, null);


            //Get all blobs from container.
            SetMetaData(imageContainer);

            Console.ReadKey();
        }

        static void SetMetaData(CloudBlobContainer container)
        {
            container.Metadata.Clear();
            container.Metadata.Add("Owner", "Dover");
            container.Metadata["updated"] = DateTime.Now.ToString();
            container.SetMetadata();
        }
    }
}
