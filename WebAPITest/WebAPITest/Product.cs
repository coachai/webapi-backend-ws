using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest
{
    public class Product:TableEntity
    {
       
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Product(string Name,string Category,double Price)
        {           
            this.PartitionKey = Name;
            this.RowKey = Category;
            this.Price = Price;
        }
      


    }
}