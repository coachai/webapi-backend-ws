using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITest.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        Product product1 = new Product("Jacket", "Clothes", 23.3);
        Product product2 = new Product("Tomato Soup", "Groceries", 1);
        Product product3 = new Product("Yo-yo","Toys", 3.75);
        Product product4 = new Product("Hammer", "Hardware", 16.99);
     

        Review []review = new Review[]
            {
              new Review { Id = 1, ProductId= 1,     Rating= 5,   Text= "first" },
           new Review { Id = 2, ProductId = 2, Rating = 3, Text = "Second" },
            new Review { Id = 3, ProductId = 3, Rating = 6, Text = "Third" },
            new Review { Id = 4, ProductId = 4, Rating = 2, Text = "Fourth" }

            };
        private IEnumerable<Product> products;

        public IEnumerable<Product>  GetAllProducts()
        { return products;
        }

        //public Product GetProduct(int Id)
        //    {
            
        // //   var product = products.FirstOrDefault((p) => p.Id == Id);
        //    if (product==null)
        //        throw new NotFoundException();
        //    return product;

            
        //   }

        [Route("{productId}/reviews")]
        [HttpGet]
        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return review.Where((r) => r.ProductId == productId);

        }

        private CloudTableClient CreateTableClient()
        { CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
         
            return tableClient;
        }

        public void InitializeSampleData()
        {
            CloudTable table = CreateTableClient().GetTableReference("Products");
            table.CreateIfNotExists();

            var op1 = TableOperation.InsertOrReplace(product1);
            table.Execute(op1);

            var op2 = TableOperation.InsertOrReplace(product2);
            table.Execute(op2);

            var op3 = TableOperation.InsertOrReplace(product3);
            table.Execute(op3);

            var op4 = TableOperation.InsertOrReplace(product4);
            table.Execute(op4);

        }
    }
}
