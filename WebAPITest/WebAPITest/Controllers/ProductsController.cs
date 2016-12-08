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

        Product[] products = new Product[]
        {
           new Product { Id = 1, Name= "Jacket",     Category= "Clothes",   Price= 23.3M },
           new Product { Id = 2, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 3, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 4, Name = "Hammer", Category = "Hardware", Price = 16.99M }

        };

        Review []review = new Review[]
            {
              new Review { Id = 1, ProductId= 1,     Rating= 5,   Text= "first" },
           new Review { Id = 2, ProductId = 2, Rating = 3, Text = "Second" },
            new Review { Id = 3, ProductId = 3, Rating = 6, Text = "Third" },
            new Review { Id = 4, ProductId = 4, Rating = 2, Text = "Fourth" }

            };


        public IEnumerable<Product>  GetAllProducts()
        { return products;
        }

        public Product GetProduct(int Id)
            {
            
            var product = products.FirstOrDefault((p) => p.Id == Id);
            if (product==null)
                throw new NotFoundException();
            return product;

            
           }

        [Route("{productId}/reviews")]
        [HttpGet]
        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return review.Where((r) => r.ProductId == productId);

        }
    }
}
