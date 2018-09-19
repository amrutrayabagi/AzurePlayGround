using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Storage.Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            //storage Account
            CloudStorageAccount account =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageAccount"));

            // Queue Client
            CloudQueueClient client = account.CreateCloudQueueClient();

            //Create Queue.
            CloudQueue queue = client.GetQueueReference("message");
            queue.CreateIfNotExists();

            //Add Message
            for (int i = 1; i < 100; i++)
            {
                queue.AddMessage(new CloudQueueMessage("Message_" + i), new TimeSpan(0, 0, 30), null, null, null);
            }

            //Get Messages
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(queue.PeekMessage().AsString);
            }

            Console.ReadKey();
        }
    }
}
