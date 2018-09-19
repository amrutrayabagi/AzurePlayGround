using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up Azure connection.
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageAccount"));

            //Table Client 
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Get the table Refereene to be created
            CloudTable table = tableClient.GetTableReference("Customers");

            //Create if not exist
            table.CreateIfNotExists();

            //Insert
            CreateCustomer(table, new Customer("amrut", "amrut@amrut.com", "India"));
            CreateCustomer(table, new Customer("amrut1", "amrut_1@amrut.com", "India"));
            CreateCustomer(table, new Customer("amrut_2", "amrut_2@amrut.com", "US"));
            CreateCustomer(table, new Customer("amrut_3", "amrut_3@amrut.com", "India"));
            CreateCustomer(table, new Customer("amrut_4", "amrut_4@amrut.com", "US"));

            //Retrive
            GetAllCustomers(table, "India");
            GetAllCustomers(table, "US");

            //Update

            //Retreive

            //Delete

            //Retrieve

            //Batch Update


            Console.ReadKey();
        }

        static void CreateCustomer(CloudTable table, Customer entity)
        {
            TableOperation insert = TableOperation.Insert(entity);
            table.Execute(insert);
        }
        static void GetAllCustomers(CloudTable table, string partitionKey)
        {
            TableQuery<Customer> query =
                new TableQuery<Customer>().Where(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            foreach (var customer in table.ExecuteQuery(query))
            {
                Console.WriteLine(customer.Name + "==========" + customer.Email);
            }
        }

        static Customer GetCustomers(CloudTable table, string partitionKey, string email)
        {
            TableOperation retrieve = TableOperation.Retrieve<Customer>(partitionKey, email);
            TableResult result = table.Execute(retrieve);
            return (Customer)result.Result;
        }

        static void UpdateCustomer(CloudTable table, string email, Customer entity)
        {
            var existingCustomer = GetCustomers(table, "US", email);
            existingCustomer.Name = entity.Name;
            TableOperation update = TableOperation.Replace(existingCustomer);
            table.Execute(update);
        }

        static void Delete(CloudTable table, Customer entity)
        {
            TableOperation update = TableOperation.Delete(entity);
            table.Execute(update);
        }

        public class Customer : TableEntity
        {
            public Customer()
            {

            }

            public Customer(string name, string email)
            {
                this.Name = Name;
                this.Email = email;
                this.PartitionKey = "US";
                this.RowKey = email;
            }

            public Customer(string name, string email, string partitionKey)
            {
                this.Name = Name;
                this.Email = email;
                this.PartitionKey = partitionKey;
                this.RowKey = email;
            }


            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
